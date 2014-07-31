using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoomableImage.Cmd
{
	class Program
	{
		private static void ShowHelp()
		{
			Console.WriteLine("Usage: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name +
				" [INPUT FILE] [OUTPUT DIR] [OPTIONS]\r\n");
			Console.WriteLine("Available options:");
			Console.WriteLine("  -v       Create HTML viewer");
			Console.WriteLine("  -b       Base name (used only with HTML viewer)");
			Console.WriteLine("  -w       HTML viewer width");
			Console.WriteLine("  -h       HTML viewer height");
			Console.WriteLine("  -t       Tile size");
			Console.WriteLine("  -f       Tile image format (JPEG, PNG)");
			Console.WriteLine("  -q       Tile image JPEG Quality (0, 100)");
			Console.WriteLine("  -s       File structure (ex. {z}-{x}-{y}.{ext} or {z}/{x}-{y}.{ext})\r\n");
		}


		static void Main(string[] args)
		{
			if (args == null || args.Length < 2)
			{
				ShowHelp();
				return;
			}

			var tileGenerator = new ZoomableImageGenerator();
			
			tileGenerator.Progress += (s, e) => {
				Console.WriteLine("{0:F2}%", e.Progress);
			};


			try
			{
				tileGenerator.InputFilePath = args[0];
			}
			catch (Exception e)
			{
				Console.WriteLine("Incorrect [INPUT FILE]\r\n  {0}", e.Message);
				return;
			}


			try
			{
				tileGenerator.OutputDirPath = args[1];
			}
			catch (Exception e)
			{
				Console.Write("Incorrect [OUTPUT FILE]\r\n  {0}", e.Message);
				return;
			}
			

			int i = 2;

			while (i < args.Length)
			{
				//Only -v option can be passed without additional data
				if (args[i] != "-v" && i + 1 >= args.Length)
				{
					ShowHelp();
					return;
				}

				switch (args[i])
				{
					case "-v":
						tileGenerator.ViewerCreation = true;
						i--;
						break;
					case "-b":
						try
						{
							tileGenerator.BaseName = args[i + 1];
						}
						catch (Exception e)
						{
							Console.Write(e.Message);
							return;
						}
						break;
					case "-w":
						int viewerWidth;

						if (!Int32.TryParse(args[i + 1], out viewerWidth) || viewerWidth < 1)
						{
							ShowHelp();
							return;
						}

						tileGenerator.ViewerWidth = viewerWidth;
						break;
					case "-h":
						int viewerHeight;

						if (!Int32.TryParse(args[i + 1], out viewerHeight) || viewerHeight < 1)
						{
							ShowHelp();
							return;
						}

						tileGenerator.ViewerHeight = viewerHeight;
						break;
					case "-t":
						int tileSize;

						if (!Int32.TryParse(args[i + 1], out tileSize) || tileSize < 1)
						{
							ShowHelp();
							return;
						}

						tileGenerator.TileSize = tileSize;
						break;
					case "-f":
						switch (args[i + 1])
						{
							case "JPEG":
								tileGenerator.TileImageFormat = TileImageFormat.JPEG;
								break;
							case "PNG":
								tileGenerator.TileImageFormat = TileImageFormat.PNG;
								break;
							default:
								ShowHelp();
								return;
						}
						break;
					case "-q":
						int tileJpegQuality;

						if (!Int32.TryParse(args[i + 1], out tileJpegQuality) || tileJpegQuality < 0 || tileJpegQuality > 100)
						{
							ShowHelp();
							return;
						}

						tileGenerator.TileJpegQuality = tileJpegQuality;
						break;
					case "-s":
						try
						{
							tileGenerator.FileStructure = args[i + 1];
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
							return;
						}
						break;
					default:
						ShowHelp();
						return;
				}

				i += 2;
			}

			try
			{
				tileGenerator.Generate();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
