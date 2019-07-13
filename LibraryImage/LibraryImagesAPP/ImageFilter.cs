using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace LibraryImagesAPP
{
    public class ImageFilter
    {
        #region Filed
        private Bitmap bmp;
        private Bitmap bmpZoom;
        static int i = 0;
        static int j = 0;
        static int red = 0;
        static int green = 0;
        static int blue = 0;
        static Bitmap img = null;
        #endregion
        #region MyRegion
        public void CreateBitmap()
        {
            bmp = new Bitmap(75, 75);
            Graphics g = Graphics.FromImage(bmp);

            SolidBrush BlueBrush = new SolidBrush(Color.Blue);
            SolidBrush RedBrush = new SolidBrush(Color.Red);

            Rectangle OuterRect = new Rectangle(0, 0, 200, 200);
            g.FillRectangle(BlueBrush, OuterRect);

            Rectangle InnerRect = new Rectangle(25, 25, 25, 25);
            g.FillRectangle(RedBrush, InnerRect);

            g.Dispose();
        }
        public void DefineZoom()
        {
            // Call this method after CreateBitmap
            // from the constructor of your form.
            bmpZoom = new Bitmap(bmp.Width, bmp.Height);
            Graphics g = Graphics.FromImage(bmpZoom);

            Rectangle srcRect = new Rectangle(Convert.ToInt32(bmp.Width / 4.0), Convert.ToInt32(bmp.Height / 4.0), Convert.ToInt32(bmp.Width / 2.0), Convert.ToInt32(bmp.Height / 2.0));
            Rectangle dstRect = new Rectangle(0, 0, bmpZoom.Width, bmpZoom.Height);
            g.DrawImage(bmp, dstRect, srcRect, GraphicsUnit.Pixel);
        }
        private enum FormatType
        {
            Xaml,
            Png,
            PngNative
        }
        public static Image InvertColors(Image Img)
        {
            ImageAttributes InvertAttributes;
            ColorMatrix InvertMatrix = new ColorMatrix();
            InvertMatrix.Matrix00 = -1;
            InvertMatrix.Matrix11 = -1;
            InvertMatrix.Matrix22 = -1;
            InvertMatrix.Matrix33 = 1;
            InvertMatrix.Matrix40 = 1;
            InvertMatrix.Matrix41 = 1;
            InvertMatrix.Matrix42 = 1;
            InvertMatrix.Matrix44 = 1;
            InvertAttributes = new ImageAttributes();
            InvertAttributes.SetColorMatrix(InvertMatrix, ColorMatrixFlag.Default, ColorAdjustType.Default);
            Bitmap FinalImg = new Bitmap(Img.Width, Img.Height);
            Graphics Graphics = System.Drawing.Graphics.FromImage(FinalImg);
            Graphics.DrawImage(Img, new Rectangle(0, 0, FinalImg.Width, FinalImg.Height), 0, 0, FinalImg.Width, FinalImg.Height, System.Drawing.GraphicsUnit.Pixel, InvertAttributes);
            return FinalImg;
        }
        public static Bitmap RotateImg(ref PictureBox pic, float angle)
        {
            img = new Bitmap(pic.Image);
            int w = img.Width;
            int h = img.Height;
            PixelFormat pf = img.PixelFormat;
            Bitmap tempImg = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tempImg);
            g.DrawImageUnscaled(img, 1, 1);
            g.Dispose();
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0.0F, 0.0F, w, h));
            Matrix mtrx = new Matrix();

            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);
            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf);
            g = Graphics.FromImage(newImg);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tempImg, 0, 0);
            g.Dispose();
            tempImg.Dispose();
            return newImg;
        }
        public Image ScaleImage(Image source, int MaxWidth, int MaxHeight)
        {
            float MaxRatio = MaxWidth / (float)MaxHeight;
            float ImgRatio = source.Width / (float)source.Height;
            if (source.Width > MaxWidth)
                return new Bitmap(source, new Size(MaxWidth, (int)Math.Round(MaxWidth /
                ImgRatio, 0)));
            if (source.Height > MaxHeight)
                return new Bitmap(source, new Size((int)Math.Round(MaxWidth * ImgRatio,
                0), MaxHeight));
            return source;
        }
        public bool PicsIdentical(Bitmap bmp1, Bitmap bmp2)
        {
            bool retVal = true;
            if (bmp1.Size != bmp2.Size)
            {
                retVal = false;
            }
            else
            {
                int x = 0;
                while (x < bmp1.Width)
                {
                    int y = 0;
                    while (y < bmp1.Height)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            retVal = false;
                            //TODO: Warning!!! break;If
                        }
                        y = (y + 1);
                    }
                    x = (x + 1);
                }
            }
            return retVal;
        }
        public static Image SetOpacity(Image original, float opacity)
        {
            Bitmap temp = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(temp);
            ColorMatrix cm = new ColorMatrix();
            cm.Matrix33 = opacity;
            ImageAttributes ia = new ImageAttributes();
            ia.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.DrawImage(temp, new Rectangle(0, 0, temp.Width, temp.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, ia);
            g.Dispose();
            return temp;
        }
        public void greyscale(Bitmap bmp, PictureBox picBox)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* imgPtr = (byte*)(data.Scan0);
                byte red, green, blue;
                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        blue = imgPtr[0];
                        green = imgPtr[1];
                        red = imgPtr[2];

                        imgPtr[0] = imgPtr[1] = imgPtr[2] =
                           (byte)(.299 * red
                            + .587 * green
                            + .114 * blue);
                        imgPtr += 3;
                    }
                    imgPtr += data.Stride - data.Width * 3;
                }

            }
            bmp.UnlockBits(data);
            picBox.Image = bmp;
        }
        public bool ConvertBMP(string BMPFullPath, ImageFormat imgFormat)
        {
            bool bAns = false;
            string sNewFile = null;
            try
            {
                //bitmap class in system.drawing.imaging
                Bitmap objBmp = new Bitmap(BMPFullPath);
                //below 2 functions in system.io.path
                sNewFile = Path.GetDirectoryName(BMPFullPath);
                sNewFile += Path.GetFileNameWithoutExtension(BMPFullPath);
                sNewFile += "." + imgFormat.ToString();
                objBmp.Save(sNewFile, imgFormat);
                bAns = true; //return true on success
            }
            catch
            {
                bAns = false; //return false on error
            }
            return bAns;
        }
        #endregion
        public ImageFilter()
        {

        }
        public ImageFilter(Bitmap img = null)
        {

        }

        public static Bitmap barButtonItem1_ItemClick(ref PictureBox pic, string Text)
        {
            Bitmap bmap = new Bitmap(pic.Image);

            int DispX = 1;
            int DispY = 1;
            int tempVar = bmap.Height - 2;
            for (i = 0; i <= tempVar; i++)
            {
                int tempVar2 = bmap.Width - 2;
                for (j = 0; j <= tempVar2; j++)
                {
                    Color pixel1 = new Color();
                    Color pixel2 = new Color();
                    pixel1 = bmap.GetPixel(j, i);
                    pixel2 = bmap.GetPixel(j + DispX, i + DispY);
                    red = Math.Min(Math.Abs((int)pixel1.R - (int)pixel2.R) + 128, 255);
                    green = Math.Min(Math.Abs((int)pixel1.G - (int)pixel2.G) + 128, 255);
                    blue = Math.Min(Math.Abs((int)pixel1.B - (int)pixel2.B) + 128, 255);
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pic.Invalidate();
                    pic.Refresh();
                    Text = Math.Floor(100 * i / (double)(pic.Image.Height - 2)).ToString() + "%";
                }
            }

            pic.Refresh();
            Text = "Done embossing image";
            return bmap;
        }

        public static void barButtonItem2_ItemClick(ref PictureBox pic, string Text)
        {
            Bitmap bmap = new Bitmap(pic.Image);
            pic.Image = bmap;
            Bitmap tempbmp = new Bitmap(pic.Image);

            int DX = 0;
            int DY = 0;

            int tempVar = tempbmp.Height - 9;
            for (i = 3; i <= tempVar; i++)
            {
                int tempVar2 = tempbmp.Width - 9;
                for (j = 3; j <= tempVar2; j++)
                {
                    DX = (int)Microsoft.VisualBasic.VBMath.Rnd() * 8 - 2;
                    DY = (int)Microsoft.VisualBasic.VBMath.Rnd() * 8 - 2;
                    red = tempbmp.GetPixel(j + DX, i + DY).R;
                    green = tempbmp.GetPixel(j + DX, i + DY).G;
                    blue = tempbmp.GetPixel(j + DX, i + DY).B;
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                Text = Math.Floor(100 * i / (double)(tempbmp.Height - 2)).ToString() + "%";
                if (i % 10 == 0)
                {
                    pic.Invalidate();

                    pic.Refresh();
                    // ProgressBar1.EditValue = Math.Floor(100 * i / (double)(pic.Image.Height - 2)).ToString();
                }
            }
            pic.Refresh();
            //   ProgressBar1.EditValue = false;

        }

        public static void barButtonItem3_ItemClick(ref PictureBox pic, string Text)
        {
            Bitmap bmap = new Bitmap(pic.Image);
            pic.Image = bmap;
            Bitmap tempbmp = new Bitmap(pic.Image);
            int DX = 1;
            int DY = 1;

            int tempVar = tempbmp.Height - DX;
            for (i = DX; i < tempVar; i++)
            {
                int tempVar2 = tempbmp.Width - DY;
                for (j = DY; j < tempVar2; j++)
                {
                    red = Convert.ToInt32(Convert.ToInt32(tempbmp.GetPixel(j, i).R) + 0.5 * Convert.ToInt32((tempbmp.GetPixel(j, i).R) - (int)(bmap.GetPixel(j - DX, i - DY).R)));
                    green = Convert.ToInt32(Convert.ToInt32(tempbmp.GetPixel(j, i).G) + 0.5 * Convert.ToInt32((tempbmp.GetPixel(j, i).G) - (int)(bmap.GetPixel(j - DX, i - DY).G)));
                    blue = Convert.ToInt32(Convert.ToInt32(tempbmp.GetPixel(j, i).B) + 0.5 * Convert.ToInt32((tempbmp.GetPixel(j, i).B - (int)(bmap.GetPixel(j - DX, i - DY).B))));
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pic.Invalidate();
                    pic.Refresh();
                    // ProgressBar1.EditValue = Math.Floor(100 * i / (double)(pic.Image.Height - 2)).ToString();
                }
            }
            pic.Refresh();
            // ProgressBar1.EditValue = false;

        }

        public static void barButtonItem4_ItemClick(ref PictureBox pic, string Text)
        {
            Bitmap bmap = new Bitmap(pic.Image);
            pic.Image = bmap;
            Bitmap tempbmp = new Bitmap(pic.Image);
            int DX = 1;
            int DY = 1;

            int tempVar = tempbmp.Height - DX;
            for (i = DX; i < tempVar; i++)
            {
                int tempVar2 = tempbmp.Width - DY;
                for (j = DY; j < tempVar2; j++)
                {
                    red = Convert.ToInt32((Convert.ToInt32(tempbmp.GetPixel(j - 1, i - 1).R) + Convert.ToInt32(tempbmp.GetPixel(j - 1, i).R) + Convert.ToInt32(tempbmp.GetPixel(j - 1, i + 1).R) + Convert.ToInt32(tempbmp.GetPixel(j, i - 1).R) + Convert.ToInt32(tempbmp.GetPixel(j, i).R) + Convert.ToInt32(tempbmp.GetPixel(j, i + 1).R) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i - 1).R) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i).R) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i + 1).R)) / 9.0);
                    green = Convert.ToInt32((Convert.ToInt32(tempbmp.GetPixel(j - 1, i - 1).G) + Convert.ToInt32(tempbmp.GetPixel(j - 1, i).G) + Convert.ToInt32(tempbmp.GetPixel(j - 1, i + 1).G) + Convert.ToInt32(tempbmp.GetPixel(j, i - 1).G) + Convert.ToInt32(tempbmp.GetPixel(j, i).G) + Convert.ToInt32(tempbmp.GetPixel(j, i + 1).G) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i - 1).G) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i).G) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i + 1).G)) / 9.0);
                    blue = Convert.ToInt32((Convert.ToInt32(tempbmp.GetPixel(j - 1, i - 1).B) + Convert.ToInt32(tempbmp.GetPixel(j - 1, i).B) + Convert.ToInt32(tempbmp.GetPixel(j - 1, i + 1).B) + Convert.ToInt32(tempbmp.GetPixel(j, i - 1).B) + Convert.ToInt32(tempbmp.GetPixel(j, i).B) + Convert.ToInt32(tempbmp.GetPixel(j, i + 1).B) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i - 1).B) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i).B) + Convert.ToInt32(tempbmp.GetPixel(j + 1, i + 1).B)) / 9.0);
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pic.Invalidate();
                    pic.Refresh();
                    //ProgressBar1.EditValue = Math.Floor(100 * i / (double)(pic.Image.Height - 2)).ToString();
                }
            }
            pic.Refresh();
            //ProgressBar1.EditValue = false;

        }

        public static void barButtonItem5_ItemClick(ref PictureBox pic, string Text)
        {
            Bitmap bmap = new Bitmap(pic.Image);
            pic.Image = bmap;
            Bitmap tempbmp = new Bitmap(pic.Image);
            int DX = 4;
            int DY = 4;

            int tempVar = tempbmp.Height - DX;
            for (i = DX; i < tempVar; i++)
            {
                int tempVar2 = tempbmp.Width - DY;
                for (j = DY; j < tempVar2; j++)
                {




                    red = (int)Math.Truncate(Convert.ToDouble(tempbmp.GetPixel(j, i).R) / 1) + tempbmp.GetPixel(j, i).R / 22;
                    green = (int)Math.Truncate(Convert.ToDouble(tempbmp.GetPixel(j, i).G) / 1) + tempbmp.GetPixel(j, i).G / 22;
                    blue = (int)Math.Truncate(Convert.ToDouble(tempbmp.GetPixel(j, i).B) / 1) + tempbmp.GetPixel(j, i).B / 22;


                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pic.Invalidate();
                    pic.Refresh();
                    Text = Math.Floor(100 * i / (double)(pic.Image.Height - 2)).ToString() + "%";
                }
            }
            pic.Refresh();
            Text = "Done sharpening image";

        }

        public static void barButtonItem6_ItemClick(ref PictureBox pic, string Text)
        {
            Bitmap bmap = new Bitmap(pic.Image);
            pic.Image = bmap;
            Bitmap tempbmp = new Bitmap(pic.Image);
            int DX = 1;
            int DY = 1;

            int tempVar = tempbmp.Height - DX;
            for (i = DX; i < tempVar; i++)
            {
                int tempVar2 = tempbmp.Width - DY;
                for (j = DY; j < tempVar2; j++)
                {


                    red = Convert.ToInt32(Convert.ToInt32(tempbmp.GetPixel(j, i).R) - 0.2 * Convert.ToInt32((tempbmp.GetPixel(j, i).R)) - (int)(bmap.GetPixel(DX, DY).R));
                    green = Convert.ToInt32(Convert.ToInt32(tempbmp.GetPixel(j, i).G) - 0.2 * Convert.ToInt32((tempbmp.GetPixel(j, i).G)) - (int)(bmap.GetPixel(DX, DY).G));
                    blue = Convert.ToInt32(Convert.ToInt32(tempbmp.GetPixel(j, i).B) - 0.2 * Convert.ToInt32((tempbmp.GetPixel(j, i).B)) - (int)(bmap.GetPixel(DX, DY).B));


                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pic.Invalidate();
                    pic.Refresh();
                    Text = Math.Floor(100 * i / (double)(pic.Image.Height - 2)).ToString() + "%";
                }
            }
            pic.Refresh();
            Text = "Done sharpening image";

        }

        public static void barButtonItem7_ItemClick(ref PictureBox pic, string Text)
        {
            Bitmap bmap = new Bitmap(pic.Image);
            pic.Image = bmap;
            Bitmap tempbmp = new Bitmap(pic.Image);
            int DX = 1;
            int DY = 1;

            int tempVar = tempbmp.Height - DX - 2;
            for (i = DX; i <= tempVar; i++)
            {
                int tempVar2 = tempbmp.Width - DY - 2;
                for (j = DY; j <= tempVar2; j++)
                {
                    red = (int)((Convert.ToInt32(tempbmp.GetPixel(j - 1, i - 1).R) + Convert.ToInt32(tempbmp.GetPixel(j + 2, i - 1).R)) / 33) + Convert.ToInt32(tempbmp.GetPixel(j, i).R);
                    green = (int)((Convert.ToInt32(tempbmp.GetPixel(j - 1, i - 1).G) + Convert.ToInt32(tempbmp.GetPixel(j + 2, i - 1).G)) / 33) + Convert.ToInt32(tempbmp.GetPixel(j, i).G);
                    blue = (int)((Convert.ToInt32(tempbmp.GetPixel(j - 1, i - 1).B) + Convert.ToInt32(tempbmp.GetPixel(j + 2, i - 1).B)) / 33) + Convert.ToInt32(tempbmp.GetPixel(j, i).B);
                    red = Math.Min(Math.Max(red, 0), 255);
                    green = Math.Min(Math.Max(green, 0), 255);
                    blue = Math.Min(Math.Max(blue, 0), 255);
                    bmap.SetPixel(j, i, Color.FromArgb(red, green, blue));
                }
                if (i % 10 == 0)
                {
                    pic.Invalidate();
                    pic.Refresh();
                    //ProgressBar1.EditValue = Math.Floor(100 * i / (double)(pic.Image.Height - 2)).ToString();
                }
            }
            pic.Refresh();
            //  ProgressBar1.EditValue = 0;

        }

        public static void barButtonItem9_ItemClick(ref PictureBox pic, string Text)
        {
            if (pic.Image == null)
            {
                string msgString = "Load the Colored Image";
                string msgCaption = "Error";

                MessageBox.Show(msgString, msgCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Image grayImage = pic.Image;
                Bitmap bm = new Bitmap(grayImage.Width, grayImage.Height);
                Graphics g = Graphics.FromImage(bm);
                ColorMatrix cm = new ColorMatrix(new float[][]
                {
                new float[] {0.3F, 0.3F, 0.3F, 0F, 0F},
                new float[] {0.59F, 0.59F, 0.59F, 0F, 0F},
                new float[] {0.11F, 0.11F, 0.11F, 0F, 0F},
                new float[] {0F, 0F, 0F, 1F, 0F},
                new float[] {0F, 0F, 0F, 0F, 1F}
                });

                ImageAttributes ia = new ImageAttributes();
                ia.SetColorMatrix(cm);
                g.DrawImage(grayImage, new Rectangle(0, 0, grayImage.Width, grayImage.Height), 0, 0, grayImage.Width, grayImage.Height, GraphicsUnit.Pixel, ia);
                g.Dispose();
                pic.Image = bm.GetThumbnailImage(pic.Width, pic.Height, null, System.IntPtr.Zero);

            }

        }



    }
}
