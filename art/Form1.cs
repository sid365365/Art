using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace art
{
    public partial class Form1 : Form
    {
        public bool status = true;
        private Bitmap bmp;
        public Graphics AriaG;
        public bool izmenenieNachato = false;
        public int rectenglNumer;
        public Line lineforChng; // линия, которая изменяется
        public int lineI; // какой из концов линии в квадрате
        public Form1()
        {
            pictureBox1 = new PictureBox {Width = 500, Height = 500};
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics graphics = Graphics.FromImage(bmp);
            AriaG = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);

            InitializeComponent();
            pictureBox1.Image = bmp;
        }

        private List<Line> LineList = new List<Line>();
        private List<Rectangle> RectangleList = new List<Rectangle>();

        private void button1_Click(object sender, EventArgs e) //очистить
        {
            LineList.Clear();
            RectangleList.Clear();
            Graphics graphics = Graphics.FromImage(bmp);
            AriaG = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) // событие движения курсора
        {
            label3.Text = "" + e.X + ""; //координата перемещения
            label4.Text = "" + e.Y + "";
            if (radioButton3.Checked)
            {
              
            }
        }

        public void pictureBox1_MouseDown(object sender, MouseEventArgs e) //событие нажатия лкм
        {
            status = true;
            int X1 = e.X; //место нажатия
            int Y1 = e.Y;

            label1.Text = "" + X1 + "";
            label2.Text = "" + Y1 + "";
            
            
            if (radioButton3.Checked)
            {
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.rectenglChek(X1, Y1))
                    {
                        izmenenieNachato = true;
                        foreach (Line line in LineList)
                        {
                            if (line.ItLineInRectangle(LineList, rectangle) > 0)
                            {
                              lineI =  line.ItLineInRectangle(LineList, rectangle);
                                izmenenieNachato = true;
                                lineforChng = line;
                            }
                        }
                    }
                }

            }
            if (radioButton2.Checked)
            {
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.rectenglChek(e.X, e.Y))
                    {
                        MessageBox.Show("В этом месте уже есть прямоугольник");
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) //событие отпускание лкм
        {
            status = false;
            var X1 = Convert.ToInt32(label1.Text);
            var Y1 = Convert.ToInt32(label2.Text);
            var X2 = e.X;
            var Y2 = e.Y;
            
            

            if (radioButton1.Checked) //рисуем линию
            {
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.rectenglChek(X1, Y1))
                    {
                        foreach (Rectangle rectangle2 in RectangleList)
                        {
                            if (rectangle2.rectenglChek(X2, Y2))
                            {
                                Graphics g = Graphics.FromImage(bmp);
                                pictureBox1.Image = bmp;
                                var lineToDrow = new Line();
                                lineToDrow.LineDrow(g, X1, Y1, X2, Y2, Color.Black);
                                LineList.Add(lineToDrow);
                            }
                        }
                    }
                }
            }
            if (radioButton2.Checked) //рисуем прямоугольники
            {
                bool i = true;
                Graphics g = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
                var rectangleToDrow = new Rectangle();
                var widthRectangle = X2 - X1;
                var heightRectangle = Y2 - Y1;
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.rectenglChek(e.X, e.Y))
                    {
                        MessageBox.Show("Попытка нарисовать прямоугольник на прямоугольнике");
                        i = false;
                    }
                }
                if (i)
                {
                    if (widthRectangle < 0 || heightRectangle < 0)
                    {
                        if (widthRectangle < 0)
                        {
                            rectangleToDrow.rectangleDrow(g, X2, Y1, X1 - X2, heightRectangle, Color.Black);
                        }
                        if (heightRectangle < 0)
                        {
                            rectangleToDrow.rectangleDrow(g, X1, Y2, widthRectangle, Y1 - Y2, Color.Black);
                        }
                        if (widthRectangle < 0 & heightRectangle < 0)
                        {
                            rectangleToDrow.rectangleDrow(g, X2, Y2, X1 - X2, Y1 - Y2, Color.Black);
                        }
                    }
                    else
                    {
                        rectangleToDrow.rectangleDrow(g, X1, Y1, widthRectangle, heightRectangle, Color.Black);
                    }
                }


                RectangleList.Add(rectangleToDrow);
            }
            if (radioButton3.Checked) //перерисовываем прямоугольник и линию
            {
                Rectangle rec = new Rectangle();
                rec = null;
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.rectenglChek(X1, Y1) == true)
                    {
                        
                        rec = rectangle;
                    }
                }
                if (rec != null)
                {
                     RectangleList.Remove(rec);
                rec.positionX = X1 -(X1 - X2);
                rec.positionY =Y1- (Y1 - Y2);
                    if (izmenenieNachato)
                    {
                        if (lineI == 1)
                        {
                            lineforChng.positionX = X1 - (X1 - X2);
                            lineforChng.positionY = Y1 - (Y1 - Y2);
                        }

                        if (lineI == 2)
                        {
                            lineforChng.positionX2 = X1 - (X1 - X2);
                            lineforChng.positionY2 = Y1 - (Y1 - Y2);
                        }

                    }
                Graphics g = Graphics.FromImage(bmp);
                rec.rectangleDrow(g, rec.positionX,rec.positionY,rec.widthRectangle,rec.heightRectangle,Color.Black);
                RectangleList.Add(rec);
                g.Clear(Color.White);
                AriaG = pictureBox1.CreateGraphics();
                UpdatePictur.Update(LineList, RectangleList, g);
                pictureBox1.Image = bmp;
                }
               
            }
        }
    }
}