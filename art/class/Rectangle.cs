using System.Drawing;
using System.Windows.Forms;

namespace art
{
  
    public class Rectangle
    {
        public XYkoord koord1;
        public XYkoord koord2;
        public int X;
        public int Y;
        public int width;
        public int heigh;
        

        public virtual Pen pen()
        {
            Pen  pen = new Pen(Color.Black);
            return pen;
        }
    }
    
    public  class BlueRectangle : Rectangle
    {
        public override Pen pen()
        {
            Pen pen = new Pen(Color.Blue);
            return pen;
        }
    }

    
}