namespace ColorQuantizationViewer
{
    partial class FrmColorQuantViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLoadImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageImageDisplay = new System.Windows.Forms.TabPage();
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBoxDisplay = new System.Windows.Forms.PictureBox();
            this.tabPageColorChart = new System.Windows.Forms.TabPage();
            this.chartColors = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.comboBoxImageDisplayed = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxUseCustomColorPalette = new System.Windows.Forms.CheckBox();
            this.buttonCustomPalette = new System.Windows.Forms.Button();
            this.checkBoxGrayScale = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownColorCount = new System.Windows.Forms.NumericUpDown();
            this.buttonPerformQuantization = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageImageDisplay.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).BeginInit();
            this.tabPageColorChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartColors)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorCount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemLoadImage,
            this.toolStripMenuItemSaveImage});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItemLoadImage
            // 
            this.toolStripMenuItemLoadImage.Name = "toolStripMenuItemLoadImage";
            this.toolStripMenuItemLoadImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItemLoadImage.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemLoadImage.Text = "Load Image";
            // 
            // toolStripMenuItemSaveImage
            // 
            this.toolStripMenuItemSaveImage.Name = "toolStripMenuItemSaveImage";
            this.toolStripMenuItemSaveImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveImage.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItemSaveImage.Text = "Save Image";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel2.Controls.Add(this.tabControlMain, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(715, 512);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageImageDisplay);
            this.tabControlMain.Controls.Add(this.tabPageColorChart);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(3, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(499, 506);
            this.tabControlMain.TabIndex = 8;
            // 
            // tabPageImageDisplay
            // 
            this.tabPageImageDisplay.AutoScroll = true;
            this.tabPageImageDisplay.Controls.Add(this.panelImage);
            this.tabPageImageDisplay.Location = new System.Drawing.Point(4, 22);
            this.tabPageImageDisplay.Name = "tabPageImageDisplay";
            this.tabPageImageDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImageDisplay.Size = new System.Drawing.Size(491, 480);
            this.tabPageImageDisplay.TabIndex = 0;
            this.tabPageImageDisplay.Text = "Image Display";
            this.tabPageImageDisplay.UseVisualStyleBackColor = true;
            // 
            // panelImage
            // 
            this.panelImage.AutoScroll = true;
            this.panelImage.AutoSize = true;
            this.panelImage.Controls.Add(this.pictureBoxDisplay);
            this.panelImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage.Location = new System.Drawing.Point(3, 3);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(485, 474);
            this.panelImage.TabIndex = 5;
            // 
            // pictureBoxDisplay
            // 
            this.pictureBoxDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxDisplay.Location = new System.Drawing.Point(8, 8);
            this.pictureBoxDisplay.Name = "pictureBoxDisplay";
            this.pictureBoxDisplay.Size = new System.Drawing.Size(701, 480);
            this.pictureBoxDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxDisplay.TabIndex = 3;
            this.pictureBoxDisplay.TabStop = false;
            // 
            // tabPageColorChart
            // 
            this.tabPageColorChart.Controls.Add(this.chartColors);
            this.tabPageColorChart.Location = new System.Drawing.Point(4, 22);
            this.tabPageColorChart.Name = "tabPageColorChart";
            this.tabPageColorChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColorChart.Size = new System.Drawing.Size(491, 480);
            this.tabPageColorChart.TabIndex = 1;
            this.tabPageColorChart.Text = "Color Chart";
            this.tabPageColorChart.UseVisualStyleBackColor = true;
            // 
            // chartColors
            // 
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chartColors.ChartAreas.Add(chartArea2);
            this.chartColors.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartColors.Legends.Add(legend2);
            this.chartColors.Location = new System.Drawing.Point(3, 3);
            this.chartColors.Name = "chartColors";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.Name = "Colors";
            series2.YValuesPerPoint = 2;
            this.chartColors.Series.Add(series2);
            this.chartColors.Size = new System.Drawing.Size(485, 474);
            this.chartColors.TabIndex = 4;
            this.chartColors.Text = "Histogram Display";
            title2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Colors Used in Quantization";
            this.chartColors.Titles.Add(title2);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBoxImage);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.buttonPerformQuantization);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(508, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(204, 506);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.comboBoxImageDisplayed);
            this.groupBoxImage.Location = new System.Drawing.Point(3, 3);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(198, 53);
            this.groupBoxImage.TabIndex = 6;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Displayed Image";
            // 
            // comboBoxImageDisplayed
            // 
            this.comboBoxImageDisplayed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxImageDisplayed.Enabled = false;
            this.comboBoxImageDisplayed.FormattingEnabled = true;
            this.comboBoxImageDisplayed.Location = new System.Drawing.Point(6, 19);
            this.comboBoxImageDisplayed.Name = "comboBoxImageDisplayed";
            this.comboBoxImageDisplayed.Size = new System.Drawing.Size(186, 21);
            this.comboBoxImageDisplayed.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxUseCustomColorPalette);
            this.groupBox1.Controls.Add(this.buttonCustomPalette);
            this.groupBox1.Controls.Add(this.checkBoxGrayScale);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericUpDownColorCount);
            this.groupBox1.Location = new System.Drawing.Point(3, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 131);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Colors";
            // 
            // checkBoxUseCustomColorPalette
            // 
            this.checkBoxUseCustomColorPalette.AutoSize = true;
            this.checkBoxUseCustomColorPalette.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUseCustomColorPalette.Location = new System.Drawing.Point(46, 68);
            this.checkBoxUseCustomColorPalette.Name = "checkBoxUseCustomColorPalette";
            this.checkBoxUseCustomColorPalette.Size = new System.Drawing.Size(146, 17);
            this.checkBoxUseCustomColorPalette.TabIndex = 15;
            this.checkBoxUseCustomColorPalette.Text = "Use Custom Color Palette";
            this.checkBoxUseCustomColorPalette.UseVisualStyleBackColor = true;
            // 
            // buttonCustomPalette
            // 
            this.buttonCustomPalette.Enabled = false;
            this.buttonCustomPalette.Location = new System.Drawing.Point(62, 91);
            this.buttonCustomPalette.Name = "buttonCustomPalette";
            this.buttonCustomPalette.Size = new System.Drawing.Size(130, 23);
            this.buttonCustomPalette.TabIndex = 14;
            this.buttonCustomPalette.Text = "Define Color Palette...";
            this.buttonCustomPalette.UseVisualStyleBackColor = true;
            // 
            // checkBoxGrayScale
            // 
            this.checkBoxGrayScale.AutoSize = true;
            this.checkBoxGrayScale.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxGrayScale.Location = new System.Drawing.Point(62, 45);
            this.checkBoxGrayScale.Name = "checkBoxGrayScale";
            this.checkBoxGrayScale.Size = new System.Drawing.Size(130, 17);
            this.checkBoxGrayScale.TabIndex = 13;
            this.checkBoxGrayScale.Text = "Quantize In Grayscale";
            this.checkBoxGrayScale.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Colors in Image:";
            // 
            // numericUpDownColorCount
            // 
            this.numericUpDownColorCount.Location = new System.Drawing.Point(135, 19);
            this.numericUpDownColorCount.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownColorCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColorCount.Name = "numericUpDownColorCount";
            this.numericUpDownColorCount.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownColorCount.TabIndex = 10;
            this.numericUpDownColorCount.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // buttonPerformQuantization
            // 
            this.buttonPerformQuantization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPerformQuantization.Enabled = false;
            this.buttonPerformQuantization.Location = new System.Drawing.Point(88, 199);
            this.buttonPerformQuantization.Name = "buttonPerformQuantization";
            this.buttonPerformQuantization.Size = new System.Drawing.Size(113, 23);
            this.buttonPerformQuantization.TabIndex = 12;
            this.buttonPerformQuantization.Text = "Perform Quantization";
            this.buttonPerformQuantization.UseVisualStyleBackColor = true;
            // 
            // FrmColorQuantViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 536);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmColorQuantViewer";
            this.Text = "Color Quantization Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageImageDisplay.ResumeLayout(false);
            this.tabPageImageDisplay.PerformLayout();
            this.panelImage.ResumeLayout(false);
            this.panelImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisplay)).EndInit();
            this.tabPageColorChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartColors)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBoxImage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLoadImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageImageDisplay;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBoxDisplay;
        private System.Windows.Forms.TabPage tabPageColorChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColors;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.ComboBox comboBoxImageDisplayed;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxUseCustomColorPalette;
        private System.Windows.Forms.Button buttonCustomPalette;
        private System.Windows.Forms.CheckBox checkBoxGrayScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownColorCount;
        private System.Windows.Forms.Button buttonPerformQuantization;
    }
}

