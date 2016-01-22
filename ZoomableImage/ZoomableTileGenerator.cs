using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Aurigma.GraphicsMill;
using Aurigma.GraphicsMill.Codecs;
using Aurigma.GraphicsMill.Transforms;


namespace ZoomableImage
{
	public enum TileImageFormat
	{
		JPEG,
		PNG
	}


	internal struct ZoomLevel
	{
		public int ImageWidth;
		public int ImageHeight;
		public int GridWidth;
		public int GridHeight;
	}


	public class ProgressEventArgs : EventArgs
	{
		public float Progress { get; set;  }


		public ProgressEventArgs(float progress)
		{
			Progress = progress;
		}
	}


	public class ZoomableImageGenerator
	{
		private string inputFilePath = null;

		public string InputFilePath {
			get
			{
				return inputFilePath;
			}
			set
			{
				if (value != null && !IsValidPath(value))
				{
					throw new ArgumentException("Invalid input file path.");
				}
				inputFilePath = value;
			}
		}


		private string outputDirPath = null;

		public string OutputDirPath
		{
			get
			{
				return outputDirPath;
			}
			set
			{
				if (value != null && !IsValidPath(value))
				{
					throw new ArgumentException("Invalid output directory path.");
				}
				outputDirPath = value;
			}
		}


		private string baseName = null;

		public string BaseName 
		{ 
			get
			{
				return baseName;
			}
			set
			{
				if (value != null && String.IsNullOrWhiteSpace(value) || 
					new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars())) + "]").IsMatch(value)) 
				{ 
					throw new ArgumentException("Invalid base name.");
				};

				baseName = value;
			}
		}


		private string fileStructure = "{z}-{x}-{y}.{ext}";

		public string FileStructure
		{ 
			get
			{
				return fileStructure;
			}
			set
			{
				if (!IsValidPath(value) || value.Contains(":"))
				{
					throw new ArgumentException("Invalid file structure.");
				}

				if (!value.Contains("{z}"))
				{
					throw new ArgumentException("Invalid file structure. It should contain '{z}' argument. Example: '{z}-{x}-{y}.{ext}' or '{z}/{x}-{y}.jpg'.");
				}

				if (!value.Contains("{x}"))
				{
					throw new ArgumentException("Invalid file structure. It should contain '{x}' argument. Example: '{z}-{x}-{y}.{ext}' or '{z}/{x}-{y}.jpg'.");
				}

				if (!value.Contains("{y}"))
				{
					throw new ArgumentException("Invalid file structure. It should contain '{y}' argument. Example: '{z}-{x}-{y}.{ext}' or '{z}/{x}-{y}.jpg'.");
				}

				fileStructure = value;
			}
		}
		

		private int tileSize = 256;

		public int TileSize {
			get
			{
				return tileSize;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException("Tile size should be greater than 0.");
				}

				tileSize = value;
			}
		}


		private TileImageFormat tileImageFormat = TileImageFormat.JPEG;

		public TileImageFormat TileImageFormat { 
			get
			{
				return tileImageFormat;
			}
			set
			{
				tileImageFormat = value;
			}
		}


		private int tileJpegQuality = 75;
		
		public int TileJpegQuality
		{
			get
			{
				return tileJpegQuality;
			}
			set
			{
				if (value < 0 || value > 100)
				{
					throw new ArgumentException("JPEG quality should be in range [0..100].");
				}

				tileJpegQuality = value;
			}
		}


		private bool viewerCreation;

		public bool ViewerCreation
		{
			get
			{
				return viewerCreation;
			}
			set
			{
				viewerCreation = value;
			}
		}


		int viewerWidth = 400;

		public int ViewerWidth 
		{ 
			get
			{
				return viewerWidth;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException("Viewer width should be greater than 0.");
				}

				viewerWidth = value;
			}
		}


		int viewerHeight = 300;

		public int ViewerHeight
		{
			get
			{
				return viewerHeight;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException("Viewer height should be greater than 0.");
				}

				viewerHeight = value;
			}
		}


		public event EventHandler<ProgressEventArgs> Progress;
		public event EventHandler<ErrorEventArgs> Error;


		private const string ViewerFileName = "viewer.htm";
		private const string ScriptFileName = "ZoomableImage.js";
		private const int MaxOpenFileCount = 2000;


		private string GetFileStructureFormat()
		{
			return FileStructure.Replace("{z}", "{0}").Replace("{x}", "{1}").
				Replace("{y}", "{2}").Replace("{ext}", "{3}"); 
		}


		private string GetTileOutputDirPath()
		{
			if (ViewerCreation)
			{
				return Path.Combine(OutputDirPath, BaseName);
			}
			else
			{
				return OutputDirPath;			
			}
		}


		private string GetTileFileExt()
		{
			switch (TileImageFormat)
			{
				case TileImageFormat.PNG:
					return "png";
				default:
					return "jpg";
			}			
		}


		private bool IsValidPath(string path)
		{
			return !String.IsNullOrWhiteSpace(path) && !new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]").IsMatch(path);
		}


		protected virtual void OnProgress(Aurigma.GraphicsMill.ProgressEventArgs e)
		{
			var t = ((float)tileProcessedTotal * 100f + (float)Math.Min(MaxOpenFileCount, tileTotal - tileProcessedTotal) * e.Progress) / 
				(float)tileTotal;

			if (Progress != null)
				Progress(this, new ProgressEventArgs(t ));
		}


		private int tileTotal;
		private int tileProcessedTotal;

		public void Generate()
		{
			if (InputFilePath == null)
			{
				throw new InvalidOperationException("Input file path is not specified.");
			}

			if (OutputDirPath == null)
			{
				throw new InvalidOperationException("Output directory path is not specified.");
			}

			if (ViewerCreation && BaseName == null)
			{
				throw new InvalidOperationException("Base name should be specified for viewer creation.");
			}

			var zoomLevels = new List<ZoomLevel>();
	
			ImageReader reader = null;

			try
			{
				reader = ImageReader.Create(InputFilePath);

				var d = 1f;

				ZoomLevel zoomLevel;

				do
				{
					zoomLevel.ImageWidth = (int)((float)reader.Width / d);
					zoomLevel.ImageHeight = (int)((float)reader.Height / d);
					zoomLevel.GridWidth = (zoomLevel.ImageWidth + TileSize - 1) / TileSize;
					zoomLevel.GridHeight = (zoomLevel.ImageHeight + TileSize - 1) / TileSize;

					zoomLevels.Add(zoomLevel);

					tileTotal += zoomLevel.GridWidth * zoomLevel.GridHeight;  

					d *= 2;

				} while (zoomLevel.ImageWidth > TileSize || zoomLevel.ImageHeight > TileSize);

				zoomLevels.Reverse();


				if (ViewerCreation)
				{
					var bd = AppDomain.CurrentDomain.BaseDirectory;

					try
					{
						if (!Directory.Exists(OutputDirPath))
						{
							Directory.CreateDirectory(OutputDirPath);
						}
					}
					catch (Exception e)
					{
						throw new IOException(String.Format("Can't create directory {0}.\r\n  {1}", OutputDirPath, e.Message));
					}

					File.Copy(Path.Combine(bd, ScriptFileName), Path.Combine(OutputDirPath, ScriptFileName), true);

					var viewer = File.ReadAllText(Path.Combine(bd, ViewerFileName)).
						Replace("{viewerwidth}", ViewerWidth.ToString()).
						Replace("{viewerheight}", ViewerHeight.ToString()).
						Replace("{imagewidth}", reader.Width.ToString()).
						Replace("{imageheight}", reader.Height.ToString()).
						Replace("{basename}", BaseName).
						Replace("{structure}", FileStructure.Replace("{ext}", GetTileFileExt()));

					if (TileSize != 256)
					{
						viewer = viewer.Replace("{tilesize}", TileSize.ToString());
					}
					else
					{
						var r = new Regex(@"^.*{tilesize}.*\r\n", RegexOptions.Multiline);
						viewer = r.Replace(viewer, "");
					}

					File.WriteAllText(Path.Combine(OutputDirPath, BaseName + ".htm"), viewer);
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Dispose();
				}
			}

			tileProcessedTotal = 0;

			//Application can't have more than 2048 file handlers. 
			//We can reach the limit with >~100 MP images
			for (int minTileIndex = 1; minTileIndex <= tileTotal; minTileIndex += MaxOpenFileCount)
			{
				int maxTileIndex = Math.Min(minTileIndex + MaxOpenFileCount - 1, tileTotal);
				int tileIndex = 0;				

				//Store reference to all pipeline elements for further correct object disposing
				var pipelineElements = new List<PipelineElement>();

				try
				{
					reader = ImageReader.Create(InputFilePath);

					pipelineElements.Add(reader);

					PipelineElement source;

					//Create progress tracker
					if (Progress != null)
					{
						var progress = new ProgressReporter();
						progress.Progress += (s, e) =>
						{
							OnProgress(e);
						};
						pipelineElements.Add(progress);
						reader.Receivers.Add(progress);

						source = progress;
					}
					else
					{
						source = reader;
					}

					for (int zoom = 0; zoom < zoomLevels.Count; zoom++)
					{
						PipelineElement resize;

						if (zoom == zoomLevels.Count)
						{
							resize = source;
						}
						else
						{
							resize = new Resize(zoomLevels[zoom].ImageWidth, zoomLevels[zoom].ImageHeight, ResizeInterpolationMode.Anisotropic9);
							pipelineElements.Add(resize);
							source.Receivers.Add(resize);
						}


						for (int tileX = 0; tileX < zoomLevels[zoom].GridWidth; tileX++)
						{
							for (int tileY = 0; tileY < zoomLevels[zoom].GridHeight; tileY++)
							{
								tileIndex++;

								if (tileIndex < minTileIndex)
								{
									continue;
								}

								int x = tileX * TileSize;
								int y = tileY * TileSize;
								int width = Math.Min((tileX + 1) * TileSize, zoomLevels[zoom].ImageWidth) - x;
								int height = Math.Min((tileY + 1) * TileSize, zoomLevels[zoom].ImageHeight) - y;

								var crop = new Crop(x, y, width, height);
								pipelineElements.Add(crop);
								resize.Receivers.Add(crop);

								var outputFilePath = Path.Combine(GetTileOutputDirPath(),
									String.Format(GetFileStructureFormat(), zoom, tileX, tileY, GetTileFileExt()));

								var p = Path.GetDirectoryName(outputFilePath);

								try
								{
									if (!Directory.Exists(p))
									{
										Directory.CreateDirectory(p);
									}
								}
								catch (Exception e)
								{
									throw new IOException(String.Format("Can't create directory {0}.\r\n  {1}", p, e.Message));
								}

								ImageWriter writer;

								switch (TileImageFormat)
								{
									case TileImageFormat.PNG:
										writer = new PngWriter(outputFilePath);
										break;
									default:
										writer = new JpegWriter(outputFilePath, TileJpegQuality);
										break;
								}

								pipelineElements.Add(writer);
								crop.Receivers.Add(writer);

								if (tileIndex == maxTileIndex)
								{
									//Remove resize elements without crop receivers
									for (var l = source.Receivers.Count - 1; l >= 0; l--)
									{
										if (source.Receivers[l].Receivers.Count == 0)
										{
											source.Receivers.RemoveAt(l);
										}
									}

									Pipeline.Run(reader);
	
									tileProcessedTotal = maxTileIndex;

									goto LoopOut;
								}
							}
						}
					}

					LoopOut:
					;
				}
				finally
				{
					for (var i = 0; i < pipelineElements.Count; i++)
					{
						pipelineElements[i].Dispose();
					}
				}
			}
		}
	}
}
