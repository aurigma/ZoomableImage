using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZoomableImage.Win
{
	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}


		private void FormMain_Load(object sender, EventArgs e)
		{
			cmbImageFormat.SelectedIndex = 0;
		}


		private void btnSource_Click(object sender, EventArgs e)
		{
			if (ofdInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtSource.Text = ofdInput.FileName;
				txtBaseName.Text = Path.GetFileNameWithoutExtension(ofdInput.FileName);
			}
		}


		private void btnOutput_Click(object sender, EventArgs e)
		{
			if (fbdOutput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				txtOutput.Text = fbdOutput.SelectedPath;
			}
		}


		private void chbViewerCreation_CheckedChanged(object sender, EventArgs e)
		{
			gbHtml.Enabled = chbViewerCreation.Checked;
		}


		private void cmbImageFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblJpegQuality.Enabled = nudJpegQuality.Enabled = (string)cmbImageFormat.SelectedItem == "JPEG";
		}


		private void btnGenerate_Click(object sender, EventArgs e)
		{
			if (!InputIsValid())
			{
				return;
			}

			StartGenerate();

			var generator = new ZoomableImageGenerator();

			generator.Progress += (s, ea) =>
			{
				pbGenerating.Value = (int)ea.Progress;
				Application.DoEvents();
			};

			try
			{
				generator.InputFilePath = txtSource.Text;
				generator.OutputDirPath = txtOutput.Text;
				generator.BaseName = txtBaseName.Text;
				generator.FileStructure = txtFileStructure.Text;
				generator.TileSize = (int)nudTileSize.Value;

				switch ((string)cmbImageFormat.SelectedItem)
				{
					case "PNG":
						generator.TileImageFormat = TileImageFormat.PNG;
						break;
					default:
						generator.TileImageFormat = TileImageFormat.JPEG;
						break;
				}

				generator.TileJpegQuality = (int)nudJpegQuality.Value;
				generator.TileSize = (int)nudTileSize.Value;

				generator.ViewerCreation = chbViewerCreation.Checked;
				generator.ViewerWidth = (int)nudViewerWidth.Value;
				generator.ViewerHeight = (int)nudViewerHeight.Value;

				generator.Generate();

				if (chbViewerCreation.Checked && chbOpenInWebBrowser.Checked)
				{
					System.Diagnostics.Process.Start(Path.Combine(txtOutput.Text, txtBaseName.Text + ".htm"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			EndGenerate();
		}


		private bool InputIsValid()
		{
			if (String.IsNullOrWhiteSpace(txtSource.Text))
			{
				MessageBox.Show("Please specify an image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtSource.Focus();
				return false;
			}

			if (String.IsNullOrWhiteSpace(txtOutput.Text))
			{
				MessageBox.Show("Please specify an output directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtOutput.Focus();
				return false;
			}

			if (chbViewerCreation.Checked && String.IsNullOrWhiteSpace(txtBaseName.Text))
			{
				MessageBox.Show("Please specify a base name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtBaseName.Focus();
				return false;
			}

			if (String.IsNullOrWhiteSpace(txtFileStructure.Text))
			{
				MessageBox.Show("Please specify a file structure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtFileStructure.Focus();
				return false;
			}

			return true;
		}


		private void StartGenerate()
		{
			foreach (var control in this.Controls)
			{
				var c = (Control)control;
				if (c != pbGenerating)
				{
					c.Enabled = false;
				}
			}

			pbGenerating.Visible = true;

			btnGenerate.Text = "Generating...";
		}


		private void EndGenerate()
		{
			foreach (var control in this.Controls)
			{
				((Control)control).Enabled = true;
			}

			pbGenerating.Visible = false;

			btnGenerate.Text = "Generate";
		}
	}
}
