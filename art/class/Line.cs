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
}
