using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace art
{
    public enum Colors
    {
        Red,
        Black,
        Blue,
        Green
    }


    public class Line
    {
        public int positionX;
        public int positionY;
        public int positionX2;
        public int positionY2;

        public enum ParametrsLine
        {
            positionX,
            positionY,
            positionX2,
            positionY2
        }

        public int ItLineInRectangle(List<Line> lines, Rectangle rectangle)
        {
            foreach (Line line in lines)
            {
                var lineX = line.positionX;
                var lineY = line.positionY;
                var lineX2 = line.positionX2;
                var lineY2 = line.positionY2;
                var recX = rectangle.positionX;
                var recY = rectangle.positionY;
                var recXX = recX + rectangle.heightRectangle;
                var recYY = recY + rectangle.widthRectangle;
                if (lineX >= recX & lineX <= recXX)
                {
                    if (lineY >= recY & lineY <= recYY)
                    {
                        return 1;
                    }
                }

                if (lineX2 >= recX & lineX2 <= recXX)
                {
                    if (lineY2 >= recY & lineY2 <= recYY)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }


        public void ChekLine()
        {
        }

        public void LineDrow(Graphics g, Int32 x1, Int32 y1, Int32 x2, Int32 y2, Color color)
        {
            Pen pen = new Pen(color);
            g.DrawLine(pen, x1, y1, x2, y2);
            positionX = x1;
            positionY = y1;
            positionX2 = x2;
            positionY2 = y2;
        }
    }

    public class UpdatePictur
    {
        public static void Update(List<Line> lines, List<Rectangle> rectangles, Graphics g)
        {
            g.Clear(Color.White);
            if (rectangles.Count > 0)
                foreach (Rectangle rectangle in rectangles)
                {
                    rectangle.rectangleDrow(g, Convert.ToInt32(rectangle.positionX),
                        Convert.ToInt32(rectangle.positionY), Convert.ToInt32(rectangle.widthRectangle),
                        Convert.ToInt32(rectangle.heightRectangle), Color.Black);
                }
            if (lines.Count > 0)
                foreach (Line line in lines)
                {
                    line.LineDrow(g, line.positionX, line.positionY, line.positionX2, line.positionY2, Color.Black);
                }
        }
    }

    public class Rectangle
    {
        public int positionX;
        public int positionY;
        public int widthRectangle;
        public int heightRectangle;

        public void rectangleDrow(Graphics g, Int32 x1, Int32 y1, Int32 widthRectangl, Int32 heightRectangl, Color color)
        {
            Pen pen = new Pen(color);
            g.DrawRectangle(pen, x1, y1, widthRectangl, heightRectangl);
            positionX = x1;
            positionY = y1;
            widthRectangle = widthRectangl;
            heightRectangle = heightRectangl;
        }

        public bool rectenglChek(int xx1, int yy1)
        {
            if (positionX < xx1 & xx1 < positionX + widthRectangle)
            {
                if (positionY < yy1 & yy1 < positionY + heightRectangle)
                {
                    //MessageBox.Show("тут");
                    return true;
                }
            }

            return false;
        }
    }
}