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
    public partial class FrmCustomPalette : Form
    {
        private int totalColors;
        private List<Color> colors;
        private List<PanelGridHelper> gridLabels;

        public List<Color> ColorPalette { get { return colors; } }

        private const int CELL_SIZE = 30;
        private const int PADDING = 5;

        #region Constructors / Initialization

        /// <summary>Construct a new Custom Palette form, which will have numColors
        /// to select in the grid
        /// </summary>
        /// <param name="numColors"></param>
        public FrmCustomPalette(int numColors)
        {
            InitializeComponent();

            panelGrid.Layout += panelGrid_Layout;
            buttonCancel.Click += buttonCancel_Click;
            buttonOkay.Click += buttonOkay_Click;
            buttonRandomize.Click += buttonRandomize_Click;

            totalColors = numColors;

            colors = new List<Color>();

            for ( int i = 0; i < numColors; i++ )
                colors.Add(Color.DimGray);
        }

        /// <summary>Construct a new Custom Palette form with the colors
        /// provided
        /// </summary>
        /// <param name="colors"></param>
        public FrmCustomPalette(List<Color> colors)
        {
            InitializeComponent();

            panelGrid.Layout += panelGrid_Layout;
            buttonCancel.Click += buttonCancel_Click;
            buttonOkay.Click += buttonOkay_Click;
            buttonRandomize.Click += buttonRandomize_Click;

            totalColors = colors.Count;
            this.colors = colors;
        }

        /// <summary>Initializes the Grid on the form
        /// </summary>
        public void Initialize()
        {
            gridLabels = new List<PanelGridHelper>();
            PanelGridHelper temp;
            int x, y;
            int numInRow = panelGrid.Width / (CELL_SIZE + PADDING);

            for(int i = 0; i < totalColors; i++)
            {
                temp = new PanelGridHelper(i, colors);

                gridLabels.Add(temp);

                x = i % numInRow;
                y = i / numInRow;

                temp.GridElement.Location = new Point((x * CELL_SIZE) + (PADDING * (x + 1)), (y * CELL_SIZE) + (PADDING * (y + 1)));
                this.panelGrid.Controls.Add(temp.GridElement);

                temp.GridElementClicked += GridElement_Click;
            }
        }

        #endregion

        #region Event Methods

        /// <summary>Open Color Dialog when color grid item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridElement_Click(object sender, PanelGridHelper.GridElementClickedEventArgs e)
        {
            using(ColorDialog cd = new ColorDialog())
            {
                if(cd.ShowDialog() == DialogResult.OK)
                {
                    gridLabels[e.ElementIndex].SetColor(true, cd.Color);
                    colors[e.ElementIndex] = cd.Color;
                }
            }
        }

        /// <summary>Event Fired when the layout changes 
        /// Used to detect when the vertical scrollbar appears and adjust the size 
        /// so that the scrollbar does not overlap the color grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelGrid_Layout(object sender, EventArgs e)
        {
            if(panelGrid.VerticalScroll.Visible)
            {
                this.Size = new Size(this.Width + SystemInformation.VerticalScrollBarWidth, this.Height);
                panelGrid.Layout -= panelGrid_Layout; //Remove the event because we wont need it anymore
            }
        }

        /// <summary>Exit the Form with Cancel Result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>Exit the form with OK result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRandomize_Click(object sender, EventArgs e)
        {
            var query = from label in gridLabels
                        where !label.ColorChanged
                        select label.ElementIndex;

            Color c;

            foreach(int i in query)
            {
                c = GetRandomColor();
                gridLabels[i].SetColor(false, c);
                colors[i] = c;
            }
        }

        #endregion

        /// <summary>Generates a random color.
        /// Ensures that the color has not already been used
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            Random r = new Random();
            Color c = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));

            while(colors.Contains(c))
            {
                c = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            }

            return c;
        }

        /// <summary>Helper class to create panels, which will all together function as a grid
        /// </summary>
        private class PanelGridHelper
        {
            #region Members / Properties

            private int elementIndex;
            private Panel gridElement;
            private List<Color> colors;
            private Boolean colorChanged = false;
            private Boolean isUserSet = false;

            public Boolean ColorChanged { get { return colorChanged; } }
            public Panel GridElement { get { return gridElement; } }
            public int ElementIndex { get { return elementIndex; } }

            #endregion

            #region Custom Event

            /// <summary>Grid Element Clicked event
            /// </summary>
            public event EventHandler<GridElementClickedEventArgs> GridElementClicked;

            /// <summary>Custom Event args to get element index
            /// </summary>
            public class GridElementClickedEventArgs : EventArgs
            {
                private int index;
                public int ElementIndex { get { return index; } }

                public GridElementClickedEventArgs(int elementIndex)
                {
                    this.index = elementIndex;
                }
            }

            /// <summary>Fire the click Event
            /// </summary>
            public void OnGridElementClicked(GridElementClickedEventArgs e)
            {
                if ( this.GridElementClicked != null )
                    GridElementClicked(this, e);
            }

            #endregion

            /// <summary>Construct new PanelGridHelper instance
            /// </summary>
            /// <param name="elementIndex"></param>
            /// <param name="colors"></param>
            public PanelGridHelper(int elementIndex, List<Color> colors)
            {
                this.elementIndex = elementIndex;
                this.colors = colors;

                ConstructGridElement();
            }

            /// <summary>Creates a new label to be added to the grid
            /// </summary>
            private void ConstructGridElement()
            {
                gridElement = new Panel();
                gridElement.Width = CELL_SIZE;
                gridElement.Height = CELL_SIZE;
                gridElement.BackColor = colors[elementIndex];
                gridElement.BackColorChanged += delegate( object sender, EventArgs e )
                {
                    if ( isUserSet )
                        colorChanged = true;
                };
                gridElement.BorderStyle = BorderStyle.Fixed3D;
                
                gridElement.Click += gridElement_Click;
            }

            /// <summary>Sets the color of the label
            /// </summary>
            /// <param name="isUserSet"></param>
            /// <param name="color"></param>
            public void SetColor(Boolean isUserSet, Color color)
            {
                this.isUserSet = isUserSet;
                gridElement.BackColor = color;
            }

            /// <summary>Event for when the panel is clicked
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void gridElement_Click(object sender, EventArgs e)
            {
                OnGridElementClicked(new GridElementClickedEventArgs(elementIndex));
            }
        }
    }
}
