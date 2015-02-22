using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sokoban
{
    public class Painter
    {
        private Graphics painter;

        public Image ResizeImg(Image b, int nWidth, int nHeight)
        {
            Image result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(b, 0, 0, nWidth, nHeight);
                g.Dispose();
            }
            return result;
        }

        public Painter(Graphics _painter)
        {
            painter = _painter;
        }

        public void DrawImage (Image img, int x, int y, int width, int height)
        {
            painter.DrawImage(img, x, y, width, height);
        }

        public void DrawLine(Pen pen, int x1, int y1, int x2, int y2)
        {
            painter.DrawLine(pen, x1, y1, x2, y2);
        }

        public int getWidth() { return (int) painter.ClipBounds.Width; }
        public int getHeight() { return (int) painter.ClipBounds.Height; }
    }
}
