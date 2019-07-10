using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedScada.HMI
{
    public class Segment:Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SegmentDisplay.DrawTwoDigitSegmentNumber(e.Graphics, Color.Blue, DateTime.Now.Hour, 10, 10, 3, 25);
            SegmentDisplay.DrawTwoDigitSegmentNumber(e.Graphics, Color.Green, DateTime.Now.Minute, 100, 10, 3, 25);
            SegmentDisplay.DrawTwoDigitSegmentNumber(e.Graphics, Color.Orange, DateTime.Now.Second, 190, 10, 3, 25);
        }
    }
    static class SegmentDisplay
    {

        /// <summary>
        /// Use this method to draw segments.Use this to get a two digit number and
        /// extend to get any number of digits.(1 digit already availaible)
        /// </summary>
        /// <param name="gx">Graphics attribute
        /// <param name="clr">color of segment
        /// <param name="number">The number to display.
        /// <param name="x">x co-ordinate of segment
        /// <param name="y">y co-ordinate of segment
        /// <param name="thickness">Thickness of half segment
        /// <param name="width">width of each segment
        public static void DrawTwoDigitSegmentNumber(Graphics gx, Color clr, int number, int x, int y, int thickness, int width)
        {
            DrawSegments(gx, clr, number / 10, x, y, thickness, width);
            DrawSegments(gx, clr, number % 10, x + width + 10, y, thickness, width);

        }


        static void DrawHorizondalSegment(Graphics gx, Color clr, int x, int y, int l, int w)
        {
            gx.FillPolygon(new SolidBrush(clr), new Point[] {
                new Point(x, y), new Point(x + l, y-l), new Point(x+w-l, y - l),
                new Point(x +w, y),new Point(x+w-l,y+l) ,new Point(x+l,y+l)
            });
        }

        static void DrawVerticalSegment(Graphics gx, Color clr, int x, int y, int l, int w)
        {
            gx.FillPolygon(new SolidBrush(clr), new Point[] {
                new Point(x, y), new Point(x + l, y+l), new Point(x+l, y +w - l),
                new Point(x , y+w),new Point(x-l,y+w-l) ,new Point(x-l,y+l)
            });
        }

        /// <summary>
        /// Use this method to draw segments.Use this to get a One digit number and
        /// extend to get any number of digits.(2 digit already availaible)
        /// </summary>
        /// <param name="gx">Graphics attribute
        /// <param name="clr">color of segment
        /// <param name="n">The number to display.
        /// <param name="x">x co-ordinate of segment
        /// <param name="y">y co-ordinate of segment
        /// <param name="l">Thickness of half segment
        /// <param name="w">width of each segment
        public static void DrawSegments(Graphics gx, Color clr, int n, int x, int y, int l, int w)
        {

            ///<summary>
            /// Mapping of segment
            ///
            ///      3
            ///      __
            ///   1 |__| 4
            ///   2 |__| 5
            ///     
            ///      6
            /// </summary>
            ///
            ///


            byte[][] segment = new byte[10][];
            segment[0] = new byte[] { 1, 1, 1, 1, 1, 1, 0 }; ///Mapping of segment for number 0
            segment[1] = new byte[] { 1, 1, 0, 0, 0, 0, 0 }; ///Mapping of segment for number 1
            segment[2] = new byte[] { 0, 1, 1, 1, 0, 1, 1 }; ///Mapping of segment for number 2
            segment[3] = new byte[] { 0, 0, 1, 1, 1, 1, 1 }; ///Mapping of segment for number 3
            segment[4] = new byte[] { 1, 0, 0, 1, 1, 0, 1 }; ///Mapping of segment for number 4
            segment[5] = new byte[] { 1, 0, 1, 0, 1, 1, 1 }; ///Mapping of segment for number 5
            segment[6] = new byte[] { 1, 1, 1, 0, 1, 1, 1 }; ///Mapping of segment for number 6
            segment[7] = new byte[] { 0, 0, 1, 1, 1, 0, 0 }; ///Mapping of segment for number 7
            segment[8] = new byte[] { 1, 1, 1, 1, 1, 1, 1 }; ///Mapping of segment for number 8
            segment[9] = new byte[] { 1, 0, 1, 1, 1, 0, 1 }; ///Mapping of segment for number 9

            if (segment[n][0] == 1)
                DrawVerticalSegment(gx, clr, x + 2, y + 4, l, w);            ///1st segment (Refer to above mapping)
            if (segment[n][1] == 1)
                DrawVerticalSegment(gx, clr, x + 2, y + 8 + w, l, w);        ///2st segment (Refer to above mapping)
            if (segment[n][2] == 1)
                DrawHorizondalSegment(gx, clr, x + 2, y + 2, l, w);          ///3st segment (Refer to above mapping)
            if (segment[n][3] == 1)
                DrawVerticalSegment(gx, clr, x + 2 + w, y + 4, l, w);        ///4st segment (Refer to above mapping)
            if (segment[n][4] == 1)
                DrawVerticalSegment(gx, clr, x + 2 + w, y + 8 + w, l, w);    ///5st segment (Refer to above mapping)
            if (segment[n][5] == 1)
                DrawHorizondalSegment(gx, clr, x + 2, y + 10 + 2 * w, l, w); ///6st segment (Refer to above mapping)
            if (segment[n][6] == 1)
                DrawHorizondalSegment(gx, clr, x + 2, y + 6 + w, l, w);      ///7st segment (Refer to above mapping)


        }
    }
}
