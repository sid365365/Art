using System;
using System.Collections.Generic;
using System.Drawing;
namespace art
{
    public class UpdatePictur
    {
        public static void Update(List<Line> lines, List<Rectangle> rectangles, Graphics g)
        {
            g.Clear(Color.White);
            if (rectangles.Count > 0)
                foreach (Rectangle rectangle in rectangles)
                {
                    rectangle.RectangleDrow(g, rectangle.positionX, rectangle.positionY, rectangle.widthRectangle,
                        rectangle.heightRectangle);
                }
            if (lines.Count > 0)
                foreach (Line line in lines)
                {
                    line.LineDrowNew(g, line.rectangle1, line.rectangle2);
                }
        }
    }
}
