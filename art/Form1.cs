using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace art
{
    public partial class Form1 : Form
    {
        public bool status = true;
        private readonly Bitmap bmp;
        public Graphics ariaG;
        public bool changeBegin = false;
        public int rectenglNumer;
        public Line lineForChng; // линия, которая изменяется
        public int lineI; // какой из концов линии в квадрате

        public Form1()
        {
            pictureBox1 = new PictureBox { Width = 500, Height = 500 };
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics graphics = Graphics.FromImage(bmp);
            ariaG = pictureBox1.CreateGraphics();
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
            ariaG = pictureBox1.CreateGraphics();
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
        }

        public void pictureBox1_MouseDown(object sender, MouseEventArgs e) //событие нажатия лкм
        {
            status = true;
            int X1 = e.X; //место нажатия
            int Y1 = e.Y;

            label1.Text = "" + X1 + "";
            label2.Text = "" + Y1 + "";

            if (radioButton2.Checked)
            {
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.RectenglChek(e.X, e.Y))
                    {
                        MessageBox.Show("В этом месте уже есть прямоугольник");
                    }
                }
            }
        }

        public void checkSecondRectangle(int X2, int Y2, Rectangle rectangle)
        {
            foreach (Rectangle rectangle2 in RectangleList)
            {
                if (rectangle2.RectenglChek(X2, Y2))
                {
                    Graphics g = Graphics.FromImage(bmp);
                    pictureBox1.Image = bmp;
                    var lineToDrow = new Line();
                    lineToDrow.LineDrowNew(g, rectangle, rectangle2);
                    LineList.Add(lineToDrow);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) //событие отпускание лкм
        {
            status = false;
            int X1 = Convert.ToInt32(label1.Text);
            int Y1 = Convert.ToInt32(label2.Text);
            int X2 = e.X;
            int Y2 = e.Y;


            if (radioButton1.Checked) //рисуем линию
            {
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.RectenglChek(X1, Y1))
                    {
                        checkSecondRectangle(X2, Y2, rectangle);
                    }
                }
            }

            if (radioButton2.Checked) //рисуем прямоугольники
            {
                bool i = true;
                Graphics g = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
                Rectangle rectangleToDrow = new Rectangle();
                int widthRectangle = X2 - X1;
                int heightRectangle = Y2 - Y1;
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.RectenglChek(e.X, e.Y))
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
                            rectangleToDrow.RectangleDrow(g, X2, Y1, X1 - X2, heightRectangle);
                        }
                        if (heightRectangle < 0)
                        {
                            rectangleToDrow.RectangleDrow(g, X1, Y2, widthRectangle, Y1 - Y2);
                        }
                        if (widthRectangle < 0 & heightRectangle < 0)
                        {
                            rectangleToDrow.RectangleDrow(g, X2, Y2, X1 - X2, Y1 - Y2);
                        }
                    }
                    else
                    {
                        rectangleToDrow.RectangleDrow(g, X1, Y1, widthRectangle, heightRectangle);
                    }
                }


                RectangleList.Add(rectangleToDrow);
            }
            if (radioButton3.Checked)
            {
                Rectangle rec = new Rectangle();
                rec = null;
                foreach (Rectangle rectangle in RectangleList)
                {
                    if (rectangle.RectenglChek(X1, Y1))
                    {
                        rec = rectangle;
                    }
                }
                if (rec != null)
                {
                    RectangleList.Remove(rec);
                    rec.positionX = X1 - (X1 - X2);
                    rec.positionY = Y1 - (Y1 - Y2);
                    Graphics g = Graphics.FromImage(bmp);
                    rec.RectangleDrow(g, rec.positionX, rec.positionY, rec.widthRectangle, rec.heightRectangle);
                    RectangleList.Add(rec);
                    g.Clear(Color.White);
                    ariaG = pictureBox1.CreateGraphics();
                    UpdatePictur.Update(LineList, RectangleList, g);
                    pictureBox1.Image = bmp;
                }
            }
        }
    }
}