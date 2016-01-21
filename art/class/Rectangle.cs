using System;
using System.Collections.Generic;
using System.Drawing;
namespace art
{
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
