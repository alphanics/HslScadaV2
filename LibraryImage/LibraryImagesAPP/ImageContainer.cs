using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace LibraryImagesAPP
{
   // [Designer(typeof(ImageContainerDesigner))]
    [ToolboxItem(true)]
    public partial class ImageContainer : UserControl
    {
        private Color hoverColor = Color.DodgerBlue;

        private Color normalColor = Color.Transparent;
        private bool normalMode = true;
        private ToolTip toolTip1 = new ToolTip();

        public ImageContainer()
        {
            InitializeComponent();
        }

        public bool IsNormalMode
        {
            get { return normalMode; }
        }

        public Color BorderColor
        {
            set { normalColor = value; }
            get { return normalColor; }
        }

        public Color HoverColor
        {
            set { hoverColor = value; }
            get { return hoverColor; }
        }

        public Image Image
        {
            set { pictureBox1.Image = value; }
            get { return pictureBox1.Image; }
        }

        private void ImageContainer_Paint(object sender, PaintEventArgs e)
        {
            if (normalMode)
                e.Graphics.DrawRectangle(new Pen(normalColor, 3), new Rectangle(0, 0, Width - 1, Height - 1));
            else
                e.Graphics.DrawRectangle(new Pen(hoverColor, 3), new Rectangle(0, 0, Width - 1, Height - 1));
        }

        private void ImageContainer_MouseHover(object sender, EventArgs e)
        {
            //normalMode = false;
            //Invalidate();
        }

        private void ImageContainer_MouseLeave(object sender, EventArgs e)
        {
            normalMode = true;
            Invalidate();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            normalMode = false;
            Invalidate();
            OnClick(e);
        }

        private void ImageContainer_MouseDown(object sender, MouseEventArgs e)
        {
            normalMode = false;

            Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }
    }

    internal class ImageContainerDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ImageContainerListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class ImageContainerListItem : DesignerActionList
    {
        private readonly ImageContainer _ImageContainer;

        public ImageContainerListItem(ImageContainerDesigner owner)
            : base(owner.Component)
        {
            _ImageContainer = (ImageContainer) owner.Component;
        }


        public Color BackColor
        {
            get { return _ImageContainer.BackColor; }
            set { _ImageContainer.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _ImageContainer.ForeColor; }
            set { _ImageContainer.ForeColor = value; }
        }

        public Image ImageName
        {
            get { return _ImageContainer.Image; }
            set { _ImageContainer.Image = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("DXLibraryImages", "DXLibraryImages"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("BackColor", "BackColor"));
            items.Add(new DesignerActionPropertyItem("ForeColor", "ForeColor"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new FormMainDV(ImageName);
            frm.OnImagSelected_Clicked += ImageName1 => { SetProperty(_ImageContainer, "Image", ImageName1); };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}