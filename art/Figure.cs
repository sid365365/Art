using System;
using System.Collections.Generic;
using System.Drawing;


namespace art
{
    public class Line
    {
        private int positionX;
        private int positionY;
        private int positionX2;
        private int positionY2;
        public Rectangle rectangle1;
        public Rectangle rectangle2;


        public int ItLineInRectangle(List<Line> lines, Rectangle rectangle)
        {
            foreach (Line line in lines)
            {
                int lineX = line.positionX;
                int lineY = line.positionY;
                int lineX2 = line.positionX2;
                int lineY2 = line.positionY2;
                int recX = rectangle.positionX;
                int recY = rectangle.positionY;
                int recXX = recX + rectangle.heightRectangle;
                int recYY = recY + rectangle.widthRectangle;
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

        public void LineDrowNew(Graphics g, Rectangle _rectangle, Rectangle _rectangle2)
        {
            positionX = _rectangle.positionX + _rectangle.widthRectangle / 2; //координата середины прямоугольника
            positionY = _rectangle.positionY + _rectangle.heightRectangle / 2;
            positionX2 = _rectangle2.positionX + _rectangle2.widthRectangle / 2;
            positionY2 = _rectangle2.positionY + _rectangle2.heightRectangle / 2;
            rectangle1 = _rectangle;
            rectangle2 = _rectangle2;
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, positionX, positionY, positionX2, positionY2);
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

    public class Rectangle
    {
        public int positionX;
        public int positionY;
        public int widthRectangle;
        public int heightRectangle;

        public void RectangleDrow(Graphics g, Int32 _x1, Int32 _y1, Int32 _widthRectangl, Int32 _heightRectangl)
        {
            Pen pen = new Pen(Color.Black);

            positionX = _x1;
            positionY = _y1;
            widthRectangle = _widthRectangl;
            heightRectangle = _heightRectangl;
            g.DrawRectangle(pen, _x1, _y1, _widthRectangl, _heightRectangl);
        }

        public bool RectenglChek(int _x1, int _y1)
        {
            if (positionX < _x1 & _x1 < positionX + widthRectangle)
            {
                if (positionY < _y1 & _y1 < positionY + heightRectangle)
                {
                    return true;
                }
            }
            return false;
        }
    }
}