using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorQuantizationViewer
{
    public partial class FrmColorQuantViewer : Form
    {
        #region Members/Properties

        private Bitmap selectedImage;
        private ColorQuantization colorQuant;
        private Thread quantizationThread;
        private String[] comboBoxItems = new String[] { "Original Image", "Quantized Image", "Quantized/Dithered Image" };
        private String filename;
        private int colorCount;
        private List<Color> customPalette;
        private DisplayedAxes displayedAxis;

        private enum DisplayImage
        {
            OriginalImage,
            QuantizedImage,
            DitheredImage
        }

        private enum DisplayedAxes
        {
            RG,
            RB,
            GB
        }

        #endregion

        /// <summary>Construct the Color Quanitzation Viewer Instance
        /// </summary>
        public FrmColorQuantViewer()
        {
            InitializeComponent();
        }

        /// <summary>Initialize form components for the Color Quantization Viewer Instance
        /// </summary>
        public void Initialize()
        {
            this.toolStripMenuItemLoadImage.Click += toolStripMenuItemLoadImage_Click;
            this.buttonPerformQuantization.Click += buttonUpdateImage_Click;
            this.numericUpDownColorCount.KeyDown += numericUpDownColorCount_KeyDown;
            this.comboBoxImageDisplayed.SelectedIndexChanged += comboBoxImageDisplayed_SelectedIndexChanged;
            this.pictureBoxDisplay.MouseClick += pictureBoxDisplay_MouseClick;
            this.toolStripMenuItemSaveImage.Click += toolStripMenuItemSaveImage_Click;
            this.buttonCustomPalette.Click += buttonCustomPalette_Click;
            this.checkBoxUseCustomColorPalette.Click += checkBoxUseCustomColorPalette_Click;
            this.numericUpDownColorCount.ValueChanged += numericUpDownColorCount_ValueChanged;
            this.panelImage.Layout += panelImage_Layout;
            this.chartColors.Click += chartColors_Click;

            this.pictureBoxDisplay.BackColor = Color.LightGray;
            this.pictureBoxDisplay.SizeMode = PictureBoxSizeMode.Zoom;

            displayedAxis = DisplayedAxes.RG;
            BindComboBox();
        }

        /// <summary>Bind the combo box with 
        /// </summary>
        private void BindComboBox()
        {
            foreach(String s in comboBoxItems)
                comboBoxImageDisplayed.Items.Add(s);

            comboBoxImageDisplayed.SelectedIndex = (int) DisplayImage.OriginalImage;
        }

        #region Event Methods

        /// <summary>On panel Image layout change, update the size of the picture box
        /// Scroll bars only appear when the dock style is none, but it wont resize correctly like that
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelImage_Layout(object sender, EventArgs e)
        {
            this.pictureBoxDisplay.Size = this.panelImage.Size;
        }

        /// <summary>Color count changed so 'throw away' the old color palette
        /// Need to re-select custom color palette since color amount changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownColorCount_ValueChanged(object sender, EventArgs e)
        {
            if ( checkBoxUseCustomColorPalette.Checked )
            {
                buttonCustomPalette.Enabled = true;
                buttonPerformQuantization.Enabled = false;
            }
            else
            {
                buttonPerformQuantization.Enabled = selectedImage != null;
                buttonCustomPalette.Enabled = false;
            }
            this.customPalette = null;
        }

        /// <summary>Enable/Disble the custom palette button based on whether the use custom palette is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxUseCustomColorPalette_Click(object sender, EventArgs e)
        {
            buttonPerformQuantization.Enabled = !(buttonCustomPalette.Enabled = checkBoxUseCustomColorPalette.Checked) && selectedImage != null;
            this.customPalette = null;
        }

        /// <summary>Popup the Custom Palette Chooser form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCustomPalette_Click(object sender, EventArgs e)
        {
            using(FrmCustomPalette frmCustomPalette = (customPalette == null ? new FrmCustomPalette((int) numericUpDownColorCount.Value) : new FrmCustomPalette(customPalette)))
            {
                frmCustomPalette.Initialize();
                if(frmCustomPalette.ShowDialog() == DialogResult.OK)
                {
                    this.customPalette = frmCustomPalette.ColorPalette;
                    this.buttonPerformQuantization.Enabled = true;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemSaveImage_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Images|*.jpg";
                saveDialog.FileName = filename.Substring(0, filename.IndexOf('.')) + String.Format("_{0}", colorCount);
                
                if(saveDialog.ShowDialog() == DialogResult.OK)
                {
                    colorQuant.GeneratedImage.Save(saveDialog.FileName, ImageFormat.Jpeg);
                    colorQuant.DitheredImage.Save(saveDialog.FileName.Substring(0, saveDialog.FileName.IndexOf('.')) + "_Dithered.jpg", ImageFormat.Jpeg);
                }
            }
        }

        /// <summary>Increment/Decrement the combobox selected index on left/right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if(selectedImage != null && colorQuant != null && colorQuant.GeneratedImage != null && colorQuant.DitheredImage != null)
                comboBoxImageDisplayed.SelectedIndex = ((comboBoxImageDisplayed.SelectedIndex + 1) % comboBoxImageDisplayed.Items.Count);
        }

        /// <summary>Change the displayed image when the user changes the combobox selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxImageDisplayed_SelectedIndexChanged( object sender, EventArgs e )
        {
            switch ( comboBoxImageDisplayed.SelectedIndex )
            {
                case (int) DisplayImage.OriginalImage:
                    pictureBoxDisplay.Image = selectedImage;
                    break;
                case (int) DisplayImage.QuantizedImage:
                    pictureBoxDisplay.Image = colorQuant.GeneratedImage;
                    break;
                case (int) DisplayImage.DitheredImage:
                    pictureBoxDisplay.Image = colorQuant.DitheredImage;
                    break;
            }
        }

        /// <summary>Trigger Update Button on Enter pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownColorCount_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
            {
                buttonPerformQuantization.PerformClick();
                e.SuppressKeyPress = true; //Prevent from making the 'ding' noise
            }
        }

        /// <summary>Pop up an open file dialog to load the image to color quantize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemLoadImage_Click( object sender, EventArgs e )
        {
            using ( OpenFileDialog ofd = new OpenFileDialog() )
            {
                ofd.Filter = "Image Files (*.JPG)|*.jpg|All Files (*.*)|*.*";
                ofd.FilterIndex = 0;

                ofd.Multiselect = false;

                selectedImage = null;

                if ( ofd.ShowDialog() == DialogResult.OK )
                {
                    selectedImage = new Bitmap(ofd.FileName);
                    this.filename = ofd.FileName;
                }

                pictureBoxDisplay.Image = selectedImage;
                buttonPerformQuantization.Enabled = true;
            }
        }

        /// <summary>Update the display, first color quantize the image then show the generated image.
        /// Pops up a window to notify that the image is loading. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdateImage_Click( object sender, EventArgs e )
        {
            colorCount = (int) numericUpDownColorCount.Value;
            
            colorQuant = (!checkBoxUseCustomColorPalette.Checked ? new ColorQuantization(selectedImage, colorCount, checkBoxGrayScale.Checked) : new ColorQuantization(selectedImage, customPalette));

            quantizationThread = new Thread(new ThreadStart(ThreadMethod));

            quantizationThread.Start();

            //Popup loading form
            using ( FrmLoading frmLoad = new FrmLoading() )
            {
                //Close the form when the quantization is finished
                colorQuant.QuantizationCompleted += (nsender, ne) => 
                {
                    frmLoad.Invoke((MethodInvoker) delegate()
                    {
                        frmLoad.Close();
                        comboBoxImageDisplayed.Enabled = true;

                        if ( !checkBoxUseCustomColorPalette.Checked )
                            BindColorChart();
                    });
                };
                frmLoad.ShowDialog();
            }
        }

        /// <summary>Change the colors shown on the color chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chartColors_Click( object sender, EventArgs e )
        {
            int displayed = (((int) displayedAxis) + 1) % 3;

            switch ( displayed )
            {
                case 0: displayedAxis = DisplayedAxes.RG;
                    break;
                case 1: displayedAxis = DisplayedAxes.RB;
                    break;
                default: displayedAxis = DisplayedAxes.GB;
                    break;
            }

            //Show the wait cursor while the Color chart is being bound
            Cursor.Current = Cursors.WaitCursor;

            BindColorChart();

            Cursor.Current = Cursors.Default;
        }

        /// <summary>Method that will be executed in its own thread
        /// </summary>
        private void ThreadMethod()
        {
            colorQuant.BeginQuantization();

            //Used to safely change the selected index from another thread
            comboBoxImageDisplayed.Invoke((MethodInvoker)(() =>
            {
                comboBoxImageDisplayed.SelectedIndex = (int) DisplayImage.QuantizedImage;
            }));
        }

        /// <summary>Adds points to the display, based on the colors in the histogram
        /// </summary>
        /// <param name="colorQuant"></param>
        private void BindColorChart()
        {
            chartColors.Series[0].Points.Clear();
            for ( int i = 0; i < colorQuant.histogram.Length; i++ )
            {
                if ( colorQuant.histogram[i] >= 0 )
                {
                    if ( displayedAxis == DisplayedAxes.RB )
                        chartColors.Series[0].Points.AddXY(colorQuant.ColorMap[colorQuant.histogram[i], 0], colorQuant.ColorMap[colorQuant.histogram[i], 2]);
                    else if ( displayedAxis == DisplayedAxes.RG )
                        chartColors.Series[0].Points.AddXY(colorQuant.ColorMap[colorQuant.histogram[i], 0], colorQuant.ColorMap[colorQuant.histogram[i], 1]);
                    else
                        chartColors.Series[0].Points.AddXY(colorQuant.ColorMap[colorQuant.histogram[i], 1], colorQuant.ColorMap[colorQuant.histogram[i], 2]);
                }
            }

            if ( displayedAxis == DisplayedAxes.RB )
            {
                chartColors.ChartAreas[0].Axes[0].Title = "Red";
                chartColors.ChartAreas[0].Axes[1].Title = "Blue";
            }
            else if ( displayedAxis == DisplayedAxes.RG )
            {
                chartColors.ChartAreas[0].Axes[0].Title = "Red";
                chartColors.ChartAreas[0].Axes[1].Title = "Green";
            }
            else
            {
                chartColors.ChartAreas[0].Axes[0].Title = "Green";
                chartColors.ChartAreas[0].Axes[1].Title = "Blue";
            }
        }

        #endregion

        /// <summary>Abort the Quantization thread if the form is closed before the thread is finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClose( object sender, FormClosingEventArgs e )
        {
            if ( quantizationThread != null )
                quantizationThread.Abort();
        }
    }
}
