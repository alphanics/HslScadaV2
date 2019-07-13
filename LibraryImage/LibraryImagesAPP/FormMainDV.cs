using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Resources;
using System.Text;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Brushes = System.Windows.Media.Brushes;
using Color = System.Windows.Media.Color;
using Image = System.Drawing.Image;
using Rectangle = System.Windows.Shapes.Rectangle;


namespace LibraryImagesAPP
{
    public delegate void EventImageSelected(Image ImageName);

    public partial class FormMainDV : XtraForm
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
        private string CurrentFile;
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

        public FormMainDV()
        {
            InitializeComponent();
        }

        public FormMainDV(Image tagNameSelected = null)
        {
            InitializeComponent();
            pic.Image = tagNameSelected;
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
                    var img = new ImageContainer();
                    img.Tag = file.Key;
                    img.Image = (Image) file.Value;

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
        }

        private void Img_Leave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private void ViewPicture(object sender, EventArgs e)
        {
            foreach (ImageContainer img in FpnlPictures.Controls)
                if (!img.IsNormalMode)
                {
                    var bmp = (Bitmap) img.Image;
                    pic.Image = img.Image;
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

        private void barButtonGIF_ItemClick(object sender, ItemClickEventArgs e)
        {
            var img = pic.Image;
            CurrentFile = pic.Tag.ToString();
            var newName = Path.GetFileNameWithoutExtension(CurrentFile);

            newName = newName + ".gif";

            try
            {
                saveFileDialog1.Filter = "Image Files(*.GIF)|*.GIF|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = newName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    img.Save(saveFileDialog1.FileName, ImageFormat.Gif);
            }
            catch
            {
                MessageBox.Show("Failed to save image to GIF format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Image file saved to " + newName,
                "Image Saved", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void barButtonPNG_ItemClick(object sender, ItemClickEventArgs e)
        {
            var img = pic.Image;
            CurrentFile = pic.Tag.ToString();
            var newName = Path.GetFileNameWithoutExtension(CurrentFile);

            newName = newName + ".PNG";

            try
            {
                saveFileDialog1.Filter = "Image Files(*.Png)|*.Png|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = newName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    img.Save(saveFileDialog1.FileName, ImageFormat.Png);
            }
            catch
            {
                MessageBox.Show("Failed to save image to PNG format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Image file saved to " + newName,
                "Image Saved", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void barButtonIcon_ItemClick(object sender, ItemClickEventArgs e)
        {
            var img = pic.Image;
            CurrentFile = pic.Tag.ToString();
            var newName = Path.GetFileNameWithoutExtension(CurrentFile);

            newName = newName + ".Ico";

            try
            {
                saveFileDialog1.Filter = "Image Files(*.Ico)|*.Ico|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = newName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    img.Save(saveFileDialog1.FileName, ImageFormat.Icon);
            }
            catch
            {
                MessageBox.Show("Failed to save image to Icon format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Image file saved to " + newName,
                "Image Saved", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //pic.Image = ImageFilter.barButtonItem1_ItemClick(ref pic, Text);
           
          
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


        private void barButtonDownload_ItemClick(object sender, ItemClickEventArgs e)
        {
            HttpWebRequest imageRequest = null;
            WebResponse serverResponse = null;
            try
            {
                //ارسال طلب
                imageRequest = (HttpWebRequest) WebRequest.Create(TextEditURL.NullText);
                //قراءة الجواب
                serverResponse = imageRequest.GetResponse();
                //التأكد من أن الملف المطلوب ملف صورة
                if (!serverResponse.ContentType.StartsWith("image/"))
                {
                    MessageBox.Show("Le fichier n'est pas une image valide!", string.Empty, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                //قراءة محتوى الجواب (مكتوب ببروتوكول ال Http)
                var responseStream = serverResponse.GetResponseStream();
                //يستعمل في قراءة محتويات الجواب
                var buffer = new byte[BufferSize + 1];
                //عدد البايتات المقروءة في مقطع ال Stream الحالي
                var read = 0;
                //عدد البايتات المقروءة
                var parsedBytes = 0;
                while (true)
                {
                    read = responseStream.Read(buffer, parsedBytes, BufferReadSize);
                    if (read == 0) //نهاية ال Stream
                        break;
                    parsedBytes += read;
                }

                //تحرير الذاكرة            
                responseStream.Close();
                //طريقة أخرى هي استعمال الفئة WebClient
                //Dim vb4arabClient As WebClient = New WebClient()
                //buffer = vb4arabClient.DownloadData(txtURL.Text)

                //تحويل المعطيات إلى Stream
                var pictureStream = new MemoryStream(buffer);
                //الصورة
                var logo = Image.FromStream(pictureStream);
                //اظهار الصورة
                pic.Image = logo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (serverResponse != null) serverResponse.Close();
            }
        }


        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            pic.Image = ImageFilter.InvertColors(pic.Image);
        }

        #endregion

        #region MyRegion

        private void pic_DoubleClick(object sender, EventArgs e)
        {
            ////following code resizes picture to fit
            //Bitmap bm = new Bitmap(pic.Image);
            //int x = 0; //variable for new width size
            //int y = 0; //variable for new height size
            //int width = Convert.ToInt32(x); //image width.
            //int height = Convert.ToInt32(y); //image height
            //Bitmap thumb = new Bitmap(width, height);
            //Graphics g = Graphics.FromImage(thumb);
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.DrawImage(bm, new Rectangle(0, 0, width, height), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
            //g.Dispose();

            ////image path. better to make this dynamic. I am hardcoding a path just for example sake
            //thumb.Save("C:\\newimage.bmp", System.Drawing.Imaging.ImageFormat.Bmp); //can use any image format
            //bm.Dispose();
            //thumb.Dispose();
        }

        private void barButtonAddImage_ItemClick(object sender, ItemClickEventArgs e)
        {
            var frm = new FormAddImage();
            frm.ShowDialog();
        }

        public static Canvas previewTarget;

        private void barButtonXaml_ItemClick(object sender, ItemClickEventArgs e)
        {
            var img = pic.Image;
            CurrentFile = pic.Tag.ToString();
            var newName = Path.GetFileNameWithoutExtension(CurrentFile);

            newName = newName + ".Xaml";
            try
            {
                var xamlOutputText = string.Empty;
                var xamlOutput = string.Empty;

                previewTarget = new Canvas();
                previewTarget.Background = Brushes.Transparent;
                Rectangle rectangle = null;
                var bitmap = new Bitmap(pic.Image);
                previewTarget.Height = bitmap.Height;
                previewTarget.Width = bitmap.Width;


                for (var y = 0; y < bitmap.Height; ++y)
                for (var x = 0; x < bitmap.Width; ++x)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    rectangle = new Rectangle();
                    rectangle.Fill = new SolidColorBrush(Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
                    rectangle.Height = rectangle.Width = 1.0;
                    rectangle.SetValue(Canvas.LeftProperty, (double) x);
                    rectangle.SetValue(Canvas.TopProperty, (double) y);
                    rectangle.SnapsToDevicePixels = true;
                    previewTarget.Children.Add(rectangle);
                    ProgressBar1.EditValue = Math.Floor(100 * x / (double) (bitmap.Width - 2)).ToString();
                    Application.DoEvents();
                }

                Application.DoEvents();
                ProgressBar1.EditValue = 0;
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.IndentChars = "\t";
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                var output = new StringBuilder();
                XamlWriter.Save(previewTarget, XmlWriter.Create(output, settings));
                xamlOutputText = output.ToString();
                saveFileDialog1.Filter = "Xaml Files(*.Xaml)|*.Xaml|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = newName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    TextWriter writeFile = new StreamWriter(saveFileDialog1.FileName);
                    writeFile.Write(xamlOutputText);
                    writeFile.Flush();
                    writeFile.Close();
                    writeFile = null;
                }
            }
            catch
            {
                MessageBox.Show("Failed to save Xaml to Xaml format.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Xaml file saved to " + newName,
                "Xaml Saved", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        #endregion

        private void barButtonItemExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}