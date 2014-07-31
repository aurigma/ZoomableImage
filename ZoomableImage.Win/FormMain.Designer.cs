namespace ZoomableImage.Win
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ofdInput = new System.Windows.Forms.OpenFileDialog();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.pbGenerating = new System.Windows.Forms.ProgressBar();
			this.fbdOutput = new System.Windows.Forms.FolderBrowserDialog();
			this.tbcMain = new System.Windows.Forms.TabControl();
			this.tbpBasic = new System.Windows.Forms.TabPage();
			this.lblOutput = new System.Windows.Forms.Label();
			this.gbHtml = new System.Windows.Forms.GroupBox();
			this.txtBaseName = new System.Windows.Forms.TextBox();
			this.lblBaseName = new System.Windows.Forms.Label();
			this.chbOpenInWebBrowser = new System.Windows.Forms.CheckBox();
			this.lblViewerHeightPixels = new System.Windows.Forms.Label();
			this.lblViewerWidthPixels = new System.Windows.Forms.Label();
			this.nudViewerHeight = new System.Windows.Forms.NumericUpDown();
			this.lblViewerHeight = new System.Windows.Forms.Label();
			this.nudViewerWidth = new System.Windows.Forms.NumericUpDown();
			this.lblViewerWidth = new System.Windows.Forms.Label();
			this.chbViewerCreation = new System.Windows.Forms.CheckBox();
			this.btnOutput = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnSource = new System.Windows.Forms.Button();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.lblSource = new System.Windows.Forms.Label();
			this.tbpAdvanced = new System.Windows.Forms.TabPage();
			this.lblFileStructure = new System.Windows.Forms.Label();
			this.txtFileStructure = new System.Windows.Forms.TextBox();
			this.lblTileSize = new System.Windows.Forms.Label();
			this.nudTileSize = new System.Windows.Forms.NumericUpDown();
			this.gbCompression = new System.Windows.Forms.GroupBox();
			this.lblJpegQuality = new System.Windows.Forms.Label();
			this.nudJpegQuality = new System.Windows.Forms.NumericUpDown();
			this.lblImageFormat = new System.Windows.Forms.Label();
			this.cmbImageFormat = new System.Windows.Forms.ComboBox();
			this.tbcMain.SuspendLayout();
			this.tbpBasic.SuspendLayout();
			this.gbHtml.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudViewerHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudViewerWidth)).BeginInit();
			this.tbpAdvanced.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).BeginInit();
			this.gbCompression.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudJpegQuality)).BeginInit();
			this.SuspendLayout();
			// 
			// ofdInput
			// 
			this.ofdInput.FileName = "openFileDialog1";
			this.ofdInput.Filter = "Image Files (JPEG, PNG, TIFF, GIF, BMP, PSD)|*.bmp;*.gif;*.jpg;*.jpeg;*.png;*.psd" +
    ";*.tif;*.tiff;|All Files (*.*)|*.*";
			// 
			// btnGenerate
			// 
			this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnGenerate.Location = new System.Drawing.Point(379, 363);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(95, 23);
			this.btnGenerate.TabIndex = 14;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// pbGenerating
			// 
			this.pbGenerating.Location = new System.Drawing.Point(6, 363);
			this.pbGenerating.Name = "pbGenerating";
			this.pbGenerating.Size = new System.Drawing.Size(367, 23);
			this.pbGenerating.TabIndex = 15;
			this.pbGenerating.Visible = false;
			// 
			// tbcMain
			// 
			this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbcMain.Controls.Add(this.tbpBasic);
			this.tbcMain.Controls.Add(this.tbpAdvanced);
			this.tbcMain.Location = new System.Drawing.Point(6, 6);
			this.tbcMain.Name = "tbcMain";
			this.tbcMain.SelectedIndex = 0;
			this.tbcMain.Size = new System.Drawing.Size(472, 344);
			this.tbcMain.TabIndex = 18;
			// 
			// tbpBasic
			// 
			this.tbpBasic.Controls.Add(this.lblOutput);
			this.tbpBasic.Controls.Add(this.gbHtml);
			this.tbpBasic.Controls.Add(this.chbViewerCreation);
			this.tbpBasic.Controls.Add(this.btnOutput);
			this.tbpBasic.Controls.Add(this.txtOutput);
			this.tbpBasic.Controls.Add(this.btnSource);
			this.tbpBasic.Controls.Add(this.txtSource);
			this.tbpBasic.Controls.Add(this.lblSource);
			this.tbpBasic.Location = new System.Drawing.Point(4, 22);
			this.tbpBasic.Name = "tbpBasic";
			this.tbpBasic.Padding = new System.Windows.Forms.Padding(3);
			this.tbpBasic.Size = new System.Drawing.Size(464, 318);
			this.tbpBasic.TabIndex = 0;
			this.tbpBasic.Text = "Basic";
			this.tbpBasic.UseVisualStyleBackColor = true;
			// 
			// lblOutput
			// 
			this.lblOutput.AutoSize = true;
			this.lblOutput.Location = new System.Drawing.Point(15, 55);
			this.lblOutput.Name = "lblOutput";
			this.lblOutput.Size = new System.Drawing.Size(79, 13);
			this.lblOutput.TabIndex = 11;
			this.lblOutput.Text = "Output location";
			// 
			// gbHtml
			// 
			this.gbHtml.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbHtml.Controls.Add(this.txtBaseName);
			this.gbHtml.Controls.Add(this.lblBaseName);
			this.gbHtml.Controls.Add(this.chbOpenInWebBrowser);
			this.gbHtml.Controls.Add(this.lblViewerHeightPixels);
			this.gbHtml.Controls.Add(this.lblViewerWidthPixels);
			this.gbHtml.Controls.Add(this.nudViewerHeight);
			this.gbHtml.Controls.Add(this.lblViewerHeight);
			this.gbHtml.Controls.Add(this.nudViewerWidth);
			this.gbHtml.Controls.Add(this.lblViewerWidth);
			this.gbHtml.Location = new System.Drawing.Point(9, 136);
			this.gbHtml.Name = "gbHtml";
			this.gbHtml.Size = new System.Drawing.Size(446, 174);
			this.gbHtml.TabIndex = 13;
			this.gbHtml.TabStop = false;
			this.gbHtml.Text = "HTML viewer options";
			// 
			// txtBaseName
			// 
			this.txtBaseName.Location = new System.Drawing.Point(95, 20);
			this.txtBaseName.Name = "txtBaseName";
			this.txtBaseName.Size = new System.Drawing.Size(120, 20);
			this.txtBaseName.TabIndex = 13;
			// 
			// lblBaseName
			// 
			this.lblBaseName.AutoSize = true;
			this.lblBaseName.Location = new System.Drawing.Point(6, 23);
			this.lblBaseName.Name = "lblBaseName";
			this.lblBaseName.Size = new System.Drawing.Size(60, 13);
			this.lblBaseName.TabIndex = 12;
			this.lblBaseName.Text = "Base name";
			// 
			// chbOpenInWebBrowser
			// 
			this.chbOpenInWebBrowser.AutoSize = true;
			this.chbOpenInWebBrowser.Checked = true;
			this.chbOpenInWebBrowser.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbOpenInWebBrowser.Location = new System.Drawing.Point(9, 145);
			this.chbOpenInWebBrowser.Name = "chbOpenInWebBrowser";
			this.chbOpenInWebBrowser.Size = new System.Drawing.Size(126, 17);
			this.chbOpenInWebBrowser.TabIndex = 21;
			this.chbOpenInWebBrowser.Text = "Open in web browser";
			this.chbOpenInWebBrowser.UseVisualStyleBackColor = true;
			// 
			// lblViewerHeightPixels
			// 
			this.lblViewerHeightPixels.AutoSize = true;
			this.lblViewerHeightPixels.Location = new System.Drawing.Point(167, 106);
			this.lblViewerHeightPixels.Name = "lblViewerHeightPixels";
			this.lblViewerHeightPixels.Size = new System.Drawing.Size(33, 13);
			this.lblViewerHeightPixels.TabIndex = 19;
			this.lblViewerHeightPixels.Text = "pixels";
			// 
			// lblViewerWidthPixels
			// 
			this.lblViewerWidthPixels.AutoSize = true;
			this.lblViewerWidthPixels.Location = new System.Drawing.Point(167, 63);
			this.lblViewerWidthPixels.Name = "lblViewerWidthPixels";
			this.lblViewerWidthPixels.Size = new System.Drawing.Size(33, 13);
			this.lblViewerWidthPixels.TabIndex = 18;
			this.lblViewerWidthPixels.Text = "pixels";
			// 
			// nudViewerHeight
			// 
			this.nudViewerHeight.Location = new System.Drawing.Point(95, 104);
			this.nudViewerHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudViewerHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudViewerHeight.Name = "nudViewerHeight";
			this.nudViewerHeight.Size = new System.Drawing.Size(55, 20);
			this.nudViewerHeight.TabIndex = 17;
			this.nudViewerHeight.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
			// 
			// lblViewerHeight
			// 
			this.lblViewerHeight.AutoSize = true;
			this.lblViewerHeight.Location = new System.Drawing.Point(6, 106);
			this.lblViewerHeight.Name = "lblViewerHeight";
			this.lblViewerHeight.Size = new System.Drawing.Size(38, 13);
			this.lblViewerHeight.TabIndex = 16;
			this.lblViewerHeight.Text = "Height";
			// 
			// nudViewerWidth
			// 
			this.nudViewerWidth.Location = new System.Drawing.Point(95, 61);
			this.nudViewerWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudViewerWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.nudViewerWidth.Name = "nudViewerWidth";
			this.nudViewerWidth.Size = new System.Drawing.Size(55, 20);
			this.nudViewerWidth.TabIndex = 15;
			this.nudViewerWidth.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
			// 
			// lblViewerWidth
			// 
			this.lblViewerWidth.AutoSize = true;
			this.lblViewerWidth.Location = new System.Drawing.Point(6, 63);
			this.lblViewerWidth.Name = "lblViewerWidth";
			this.lblViewerWidth.Size = new System.Drawing.Size(35, 13);
			this.lblViewerWidth.TabIndex = 14;
			this.lblViewerWidth.Text = "Width";
			// 
			// chbViewerCreation
			// 
			this.chbViewerCreation.AutoSize = true;
			this.chbViewerCreation.Checked = true;
			this.chbViewerCreation.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chbViewerCreation.Location = new System.Drawing.Point(18, 94);
			this.chbViewerCreation.Name = "chbViewerCreation";
			this.chbViewerCreation.Size = new System.Drawing.Size(124, 17);
			this.chbViewerCreation.TabIndex = 46;
			this.chbViewerCreation.Text = "Create HTML viewer";
			this.chbViewerCreation.UseVisualStyleBackColor = true;
			this.chbViewerCreation.CheckedChanged += new System.EventHandler(this.chbViewerCreation_CheckedChanged);
			// 
			// btnOutput
			// 
			this.btnOutput.Location = new System.Drawing.Point(369, 50);
			this.btnOutput.Name = "btnOutput";
			this.btnOutput.Size = new System.Drawing.Size(80, 23);
			this.btnOutput.TabIndex = 11;
			this.btnOutput.Text = "Browse...";
			this.btnOutput.UseVisualStyleBackColor = true;
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(104, 52);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(259, 20);
			this.txtOutput.TabIndex = 9;
			// 
			// btnSource
			// 
			this.btnSource.Location = new System.Drawing.Point(369, 10);
			this.btnSource.Name = "btnSource";
			this.btnSource.Size = new System.Drawing.Size(80, 23);
			this.btnSource.TabIndex = 8;
			this.btnSource.Text = "Browse...";
			this.btnSource.UseVisualStyleBackColor = true;
			this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(104, 12);
			this.txtSource.Name = "txtSource";
			this.txtSource.Size = new System.Drawing.Size(259, 20);
			this.txtSource.TabIndex = 7;
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(15, 15);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(72, 13);
			this.lblSource.TabIndex = 6;
			this.lblSource.Text = "Source image";
			// 
			// tbpAdvanced
			// 
			this.tbpAdvanced.Controls.Add(this.lblFileStructure);
			this.tbpAdvanced.Controls.Add(this.txtFileStructure);
			this.tbpAdvanced.Controls.Add(this.lblTileSize);
			this.tbpAdvanced.Controls.Add(this.nudTileSize);
			this.tbpAdvanced.Controls.Add(this.gbCompression);
			this.tbpAdvanced.Location = new System.Drawing.Point(4, 22);
			this.tbpAdvanced.Name = "tbpAdvanced";
			this.tbpAdvanced.Padding = new System.Windows.Forms.Padding(3);
			this.tbpAdvanced.Size = new System.Drawing.Size(464, 318);
			this.tbpAdvanced.TabIndex = 1;
			this.tbpAdvanced.Text = "Advanced";
			this.tbpAdvanced.UseVisualStyleBackColor = true;
			// 
			// lblFileStructure
			// 
			this.lblFileStructure.AutoSize = true;
			this.lblFileStructure.Location = new System.Drawing.Point(15, 182);
			this.lblFileStructure.Name = "lblFileStructure";
			this.lblFileStructure.Size = new System.Drawing.Size(67, 13);
			this.lblFileStructure.TabIndex = 42;
			this.lblFileStructure.Text = "File structure";
			// 
			// txtFileStructure
			// 
			this.txtFileStructure.Location = new System.Drawing.Point(104, 179);
			this.txtFileStructure.Name = "txtFileStructure";
			this.txtFileStructure.Size = new System.Drawing.Size(189, 20);
			this.txtFileStructure.TabIndex = 41;
			this.txtFileStructure.Text = "{z}-{x}-{y}.{ext}";
			// 
			// lblTileSize
			// 
			this.lblTileSize.AutoSize = true;
			this.lblTileSize.Location = new System.Drawing.Point(15, 142);
			this.lblTileSize.Name = "lblTileSize";
			this.lblTileSize.Size = new System.Drawing.Size(73, 13);
			this.lblTileSize.TabIndex = 40;
			this.lblTileSize.Text = "Image tile size";
			// 
			// nudTileSize
			// 
			this.nudTileSize.Location = new System.Drawing.Point(104, 140);
			this.nudTileSize.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
			this.nudTileSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudTileSize.Name = "nudTileSize";
			this.nudTileSize.Size = new System.Drawing.Size(59, 20);
			this.nudTileSize.TabIndex = 39;
			this.nudTileSize.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
			// 
			// gbCompression
			// 
			this.gbCompression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbCompression.Controls.Add(this.lblJpegQuality);
			this.gbCompression.Controls.Add(this.nudJpegQuality);
			this.gbCompression.Controls.Add(this.lblImageFormat);
			this.gbCompression.Controls.Add(this.cmbImageFormat);
			this.gbCompression.Location = new System.Drawing.Point(9, 16);
			this.gbCompression.Name = "gbCompression";
			this.gbCompression.Size = new System.Drawing.Size(446, 98);
			this.gbCompression.TabIndex = 27;
			this.gbCompression.TabStop = false;
			this.gbCompression.Text = "Image tile compression";
			// 
			// lblJpegQuality
			// 
			this.lblJpegQuality.AutoSize = true;
			this.lblJpegQuality.Location = new System.Drawing.Point(6, 66);
			this.lblJpegQuality.Name = "lblJpegQuality";
			this.lblJpegQuality.Size = new System.Drawing.Size(67, 13);
			this.lblJpegQuality.TabIndex = 35;
			this.lblJpegQuality.Text = "JPEG quality";
			// 
			// nudJpegQuality
			// 
			this.nudJpegQuality.Location = new System.Drawing.Point(95, 64);
			this.nudJpegQuality.Name = "nudJpegQuality";
			this.nudJpegQuality.Size = new System.Drawing.Size(59, 20);
			this.nudJpegQuality.TabIndex = 34;
			this.nudJpegQuality.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
			// 
			// lblImageFormat
			// 
			this.lblImageFormat.AutoSize = true;
			this.lblImageFormat.Location = new System.Drawing.Point(6, 26);
			this.lblImageFormat.Name = "lblImageFormat";
			this.lblImageFormat.Size = new System.Drawing.Size(68, 13);
			this.lblImageFormat.TabIndex = 33;
			this.lblImageFormat.Text = "Image format";
			// 
			// cmbImageFormat
			// 
			this.cmbImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbImageFormat.FormattingEnabled = true;
			this.cmbImageFormat.Items.AddRange(new object[] {
            "JPEG",
            "PNG"});
			this.cmbImageFormat.Location = new System.Drawing.Point(95, 23);
			this.cmbImageFormat.Name = "cmbImageFormat";
			this.cmbImageFormat.Size = new System.Drawing.Size(59, 21);
			this.cmbImageFormat.TabIndex = 32;
			this.cmbImageFormat.SelectedIndexChanged += new System.EventHandler(this.cmbImageFormat_SelectedIndexChanged);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 401);
			this.Controls.Add(this.tbcMain);
			this.Controls.Add(this.pbGenerating);
			this.Controls.Add(this.btnGenerate);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMain";
			this.Text = "Zoomable Image ";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.tbcMain.ResumeLayout(false);
			this.tbpBasic.ResumeLayout(false);
			this.tbpBasic.PerformLayout();
			this.gbHtml.ResumeLayout(false);
			this.gbHtml.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudViewerHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudViewerWidth)).EndInit();
			this.tbpAdvanced.ResumeLayout(false);
			this.tbpAdvanced.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).EndInit();
			this.gbCompression.ResumeLayout(false);
			this.gbCompression.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudJpegQuality)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofdInput;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.ProgressBar pbGenerating;
		private System.Windows.Forms.FolderBrowserDialog fbdOutput;
		private System.Windows.Forms.TabControl tbcMain;
		private System.Windows.Forms.TabPage tbpBasic;
		private System.Windows.Forms.GroupBox gbHtml;
		private System.Windows.Forms.NumericUpDown nudViewerHeight;
		private System.Windows.Forms.Label lblViewerHeight;
		private System.Windows.Forms.NumericUpDown nudViewerWidth;
		private System.Windows.Forms.Label lblViewerWidth;
		private System.Windows.Forms.TextBox txtBaseName;
		private System.Windows.Forms.Label lblBaseName;
		private System.Windows.Forms.Label lblOutput;
		private System.Windows.Forms.Button btnOutput;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnSource;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.TabPage tbpAdvanced;
		private System.Windows.Forms.Label lblViewerHeightPixels;
		private System.Windows.Forms.Label lblViewerWidthPixels;
		private System.Windows.Forms.Label lblFileStructure;
		private System.Windows.Forms.TextBox txtFileStructure;
		private System.Windows.Forms.Label lblTileSize;
		private System.Windows.Forms.NumericUpDown nudTileSize;
		private System.Windows.Forms.GroupBox gbCompression;
		private System.Windows.Forms.Label lblJpegQuality;
		private System.Windows.Forms.NumericUpDown nudJpegQuality;
		private System.Windows.Forms.Label lblImageFormat;
		private System.Windows.Forms.ComboBox cmbImageFormat;
		private System.Windows.Forms.CheckBox chbOpenInWebBrowser;
		private System.Windows.Forms.CheckBox chbViewerCreation;
	}
}