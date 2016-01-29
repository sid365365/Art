using System.Drawing;

namespace art
{
    public static class RectenglUpdate
    {
        public static void ReDrowRectengl(Graphics g, Rectangle rectangle)
        {
            Pen pen = new Pen(Color.Black);
            g.DrawRectangle(pen, rectangle.X, rectangle.Y, rectangle.width, rectangle.heigh);
        }
    }
}