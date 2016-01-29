using System.Drawing;

namespace art
{
    public static class LineUpdate
    {
        public static void LineDrow(Graphics g, Rectangle rectangle1, Rectangle rectangle2)
        {
            int X1 = rectangle1.X + rectangle1.width/2;
            int X2 = rectangle2.X + rectangle2.width/2;
            int Y1 = rectangle1.Y + rectangle1.heigh/2;
            int Y2 = rectangle2.Y + rectangle2.heigh/2;
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, X1, Y1, X2, Y2);
        }
    }
}