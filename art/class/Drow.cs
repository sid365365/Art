using System.Collections.Generic;
using System.Drawing;

namespace art
{
    public static class Drowing
    {
        public static void RectangleDrow(Graphics g, XYkoord _koord1, XYkoord _koord2, List<Rectangle> rectangles)
        {
            if (_koord1.X > _koord2.X)
            {
                XYkoord _ykoord3 = new XYkoord();
                _ykoord3.X = _koord1.X;
                _koord1.X = _koord2.X;
                _koord2.X = _ykoord3.X;
            }
            if (_koord1.Y > _koord2.Y)
            {
                XYkoord ykoord3 = new XYkoord();
                ykoord3.Y = _koord1.Y;
                _koord1.Y = _koord2.Y;
                _koord2.Y = ykoord3.Y;
            }
            int widthRectangle = _koord1.X - _koord2.X;
            if (widthRectangle <= 0)
                widthRectangle = _koord2.X - _koord1.X;

            int heightRectangle = _koord1.Y - _koord2.Y;
            if (heightRectangle <= 0)
                heightRectangle = _koord2.Y - _koord1.Y;

            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, _koord1.X, _koord1.Y, widthRectangle, heightRectangle);
            Rectangle rectangle = new Rectangle
            {
                X = _koord1.X,
                Y = _koord1.Y,
                heigh = heightRectangle,
                width = widthRectangle,
                koord1 = _koord1,
                koord2 = _koord2
            };
            rectangles.Add(rectangle);
        }
        public static void LineDrow(Graphics g, Rectangle rectangle1, Rectangle rectangle2, List<Line> lines)
        {
            int X1 = rectangle1.X + rectangle1.width/2;
            int X2 = rectangle2.X + rectangle2.width/2;
            int Y1 = rectangle1.Y + rectangle1.heigh/2;
            int Y2 = rectangle2.Y + rectangle2.heigh/2;
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, X1, Y1, X2, Y2);
            Line line = new Line {rectangle1 = rectangle1, rectangle2 = rectangle2};
            lines.Add(line);
        }
    }
}