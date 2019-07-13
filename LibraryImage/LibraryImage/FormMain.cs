using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using LibraryImage;
using Microsoft.Win32;
using LibraryImage.Properties;

namespace LibraryImages
{
    public delegate void EventImageSelected(Image ImageName);

    public partial class FormMain : XtraForm
    {
        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mg = ImageFilter.SetOpacity(pic.Image, 100);
            pic.Image = null;
            pic.Image = mg;
            pic.Invalidate();
            pic.Refresh();
        }

        public static void WriteKey(string keyName, string keyValue)
        {
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.CreateSubKey(@"Software\HMI");
                regKey.SetValue(keyName, keyValue);
                regKey.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void barButtonRegistry_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK) WriteKey("abdala", FBD.SelectedPath);
        }

        #region Fild

        public EventImageSelected OnImagSelected_Clicked = null;

        // Create a ResXResourceReader for the file items.resx.
        private ResXResourceReader rsxr;

        // local variable declarations
        public string CurrentFile = string.Empty;
        public string CategoryName = "Category_Files\\{0}.resx";
        public ResXResourceWriter rsxw = null;

        /// <summary>
        ///     The stream buffer size.
        /// </summary>
        public const int BufferSize = 512 * 1024;

        /// <summary>
        ///     The bloc reading size.
        /// </summary>
        public const int BufferReadSize = 1024;

        #endregion

        #region MyRegion

        public static string ReadKey(string keyName)
        {
            var result = string.Empty;
            try
            {
                RegistryKey regKey;
                regKey = Registry.CurrentUser.OpenSubKey(@"Software\HMI"); //HKEY_CURRENR_USER\Software\VSSCD
                if (regKey != null) result = (string) regKey.GetValue(keyName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public FormMain()
        {
            InitializeComponent();
        }

        public FormMain(Image tagNameSelected = null)
        {
            InitializeComponent();
            pic.Image = tagNameSelected;
            if (tagNameSelected == null) pic.Image = Resources.AddNewDataSource_32x32;
        }

        private void FormMainDV_Load(object sender, EventArgs e)
        {
            try
            {
                ListBoxCategoryName.Items.Clear();
                pnlPictures.AutoScroll = true;
                if (DesignMode == false)
                {
                    var SelectedPath = ReadKey("abdala");
                    //AppDomain.CurrentDomain.BaseDirectory + "Category_Files\\";
                    var dirs = Directory.GetFiles(SelectedPath);

                    foreach (var item2 in dirs)
                    {
                        var f = new FileInfo(item2);
                        var v = f.Name.Split('.');
                        ListBoxCategoryName.Items.Add(v[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Not Category_Files");
            }
        }

        private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pnlPictures.Controls.Clear();

                var CategoryName = string.Format(ReadKey("abdala") + "\\{0}.resx", ListBoxCategoryName.SelectedItem);
                rsxr = new ResXResourceReader(CategoryName);

                LoadPicturesResXResourceReade(ListBoxCategoryName.SelectedItem.ToString());
            }
            catch (Exception)
            {
            }
        }

        public void LoadPicturesResXResourceReade(string folder)
        {
            try
            {
                
             
                FpnlPictures.Controls.Clear();
                 var i = 0;
                foreach (DictionaryEntry file in rsxr)
                {
                    var img = new GraphicIndicatorBase();
                    img.Tag = file.Key;
                    img.BackgroundImage = (Image) file.Value;
                    img.Size = new Size(50, 50);
                   
                    img.Click += ViewPicture;
                    img.DoubleClick += Img_DoubleClick;
                    img.MouseLeave += Img_Leave;
                    FpnlPictures.Controls.Add(img);
                  


                    i++;
                }

                barStaticImageCount.Caption = Convert.ToString(i);
                //Close the reader.
                rsxr.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Img_DoubleClick(object sender, EventArgs e)
        {
            OnImagSelected_Clicked(pic.Image);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Img_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void ViewPicture(object sender, EventArgs e)
        {
            foreach (GraphicIndicatorBase img in FpnlPictures.Controls)
                if (!img.IsNormalMode)
                {
                    var bmp = (Bitmap) img.BackgroundImage;
                    pic.Image = img.BackgroundImage;
                    pic.Tag = img.Tag;
                    toolTip1.Active = true;
                    toolTip1.Show(pic.Tag.ToString(), pic);
                    toolTip1.SetToolTip(pic, pic.Tag.ToString());

                    if (bmp.Height <= 218 && bmp.Width <= 284)
                        pic.SizeMode = PictureBoxSizeMode.CenterImage;
                    else
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;

                    break;
                }
        }

        #endregion

        #region MyRegion

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            pic.Image = ImageFilter.barButtonItem1_ItemClick(ref pic, Text);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFilter.barButtonItem2_ItemClick(ref pic, Text);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFilter.barButtonItem3_ItemClick(ref pic, Text);
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFilter.barButtonItem4_ItemClick(ref pic, Text);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFilter.barButtonItem5_ItemClick(ref pic, Text);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFilter.barButtonItem6_ItemClick(ref pic, Text);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFilter.barButtonItem7_ItemClick(ref pic, Text);
        }

        private void barButtonRotate_ItemClick(object sender, ItemClickEventArgs e)
        {
            pic.Image = ImageFilter.RotateImg(ref pic, Convert.ToUInt64(90));
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            ImageFilter.barButtonItem9_ItemClick(ref pic, Text);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            pic.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pic.Refresh();
        }


        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            pic.Image = ImageFilter.InvertColors(pic.Image);
        }

        #endregion

        private void barButtonItemExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }
    }
}