using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorQuantizationViewer
{
    public partial class FrmLoading : Form
    {
        private int timeCount;
        private const int CP_NOCLOSE_BUTTON = 0x200;
        /// <summary>Property used to disable the close button of the form
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        /// <summary>Construct a new loading form instance
        /// </summary>
        public FrmLoading()
        {
            InitializeComponent();

            timeCount = 0;

            //Ensure that the label is still centered when the text changes
            this.label1.Location = new Point((this.Width - label1.Width) / 2, label1.Location.Y);
        }

        /// <summary>Tick event for timer, to update label text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerProgress_Tick( object sender, EventArgs e )
        {
            timeCount++;

            switch(timeCount % 4)
            {
                case 0: label1.Text = "Quantizing Image";
                    break;
                case 1: label1.Text = "Quantizing Image.";
                    break;
                case 2: label1.Text = "Quantizing Image..";
                    break;
                case 3: label1.Text = "Quantizing Image...";
                    break;
            }
        }
    }
}
