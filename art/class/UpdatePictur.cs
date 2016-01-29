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
                    RectenglUpdate.ReDrowRectengl(g, rectangle);
                }
            if (lines.Count > 0)
                foreach (Line line in lines)
                {
                    LineUpdate.LineDrow(g, line.rectangle1, line.rectangle2);
                }
        }
    }
}