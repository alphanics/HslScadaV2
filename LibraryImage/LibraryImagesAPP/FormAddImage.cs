using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Svg;

namespace LibraryImagesAPP
{
    public partial class FormAddImage : XtraForm
    {
        public string CategoryName = "Category_Files\\{0}.resx";
        private string[] dirs;
        private ResXResourceWriter rsxw;

        public FormAddImage()
        {
            InitializeComponent();
        }

        private void txtSelectedPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var SelectedPath = string.Empty;
            imageListBoxControl1.Items.Clear();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = fbd.SelectedPath;
                txtSelectedPath.Text = SelectedPath;
                dirs = Directory.GetFiles(SelectedPath);

                //foreach (string item2 in dirs)
                //{

                //        string newName = System.IO.Path.GetFileNameWithoutExtension(item2);
                //        imageListBoxControl1.Items.Add(item2);

                //}
                imageListBoxControl1.Items.AddRange(DirSearch(SelectedPath).ToArray());
                dirs = DirSearch(SelectedPath).ToArray();
            }
        }

        private List<string> DirSearch(string sDir)
        {
            var files = new List<string>();
            try
            {
                foreach (var f in Directory.GetFiles(sDir)) files.Add(f);
                foreach (var d in Directory.GetDirectories(sDir)) files.AddRange(DirSearch(d));
            }
            catch (Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        private void imageListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var newName = Path.GetExtension(imageListBoxControl1.SelectedItem.ToString());
                if (newName.EndsWith(".svg"))
                {
                    var svgDocument = SvgDocument.Open(imageListBoxControl1.SelectedItem.ToString());
                    var bitmap = svgDocument.Draw();

                    Pic.Image = bitmap;
                }
                else
                {
                    Pic.Image = Image.FromFile(imageListBoxControl1.SelectedItem.ToString());
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            rsxw = new ResXResourceWriter(string.Format(CategoryName, txtCategoryName.Text));

            foreach (var file in dirs)
            {
                if (file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".bmp") || file.EndsWith(".BMP") ||
                    file.EndsWith(".JPG") || file.EndsWith(".gif") || file.EndsWith(".wmf") || file.EndsWith(".svg"))
                {
                    var newName = Path.GetFileNameWithoutExtension(file);

                    var img = new ImageContainer();
                    img.Tag = newName;
                    if (file.EndsWith(".svg"))
                    {
                        try
                        {
                            var svgDocument = SvgDocument.Open(file);
                            var bitmap = svgDocument.Draw();
                            img.Image = bitmap;
                            Pic.Image = bitmap;
                            rsxw.AddResource(file, img.Image);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        img.Image = Image.FromFile(file);
                        Pic.Image = img.Image;
                        rsxw.AddResource(file, img.Image);
                    }
                }

                Application.DoEvents();
            }

            rsxw.Close();
            MessageBox.Show("تم");
        }

        private void btnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                imageListBoxControl1.Items.RemoveAt(imageListBoxControl1.SelectedIndex);
            }
            catch (Exception)
            {
            }
        }
    }
}