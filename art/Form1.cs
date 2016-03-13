using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace art
{
    public partial class Form1 : Form
    {
        private readonly Bitmap bmp;
        public Graphics ariaG;
        public XYkoord XY1;
        public XYkoord XY2;
        public List<Line> LineList = new List<Line>();
        public List<Rectangle> RectanglesList = new List<Rectangle>();
        public List<Rectangle> BlueRectanglesList = new List<Rectangle>();
        public Form1()
        {
            pictureBox1 = new PictureBox {Width = 500, Height = 500};
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics graphics = Graphics.FromImage(bmp);
            ariaG = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            InitializeComponent();
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e) //очистить
        {
            LineList.Clear();
            RectanglesList.Clear();
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
            XY1 = new XYkoord {X = e.X, Y = e.Y};
        }

        private void nextForeach(Graphics g, Rectangle rectangle11)
        {
            foreach (Rectangle rectangle22 in RectanglesList)
            {
                if (RectenglChek.RectenglCheked(XY2, rectangle22))
                {
                    Drowing.LineDrow(g, rectangle11, rectangle22, LineList);
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) //событие отпускание лкм
        {
            XY2 = new XYkoord {X = e.X, Y = e.Y};
            Graphics g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            if (radioButton1.Checked) //рисуем линию
            {
                foreach (Rectangle rectangle11 in RectanglesList)
                {
                    if (RectenglChek.RectenglCheked(XY1, rectangle11))
                    {
                        nextForeach(g, rectangle11);
                    }
                }
            }
            if (radioButton2.Checked) //рисуем прямоугольники
            {
                Rectangle rectangle = new Rectangle();
                Drowing.RectangleDrow(g, XY1, XY2, rectangle);
            }
            if (radioButton4.Checked) //рисуем прямоугольники синий
            {
                BlueRectangle rec = new BlueRectangle();
                Drowing.RectangleDrow(g, XY1, XY2, rec);
            }
            if (radioButton3.Checked)
            {
                Rectangle rec = new Rectangle();
                rec = null;
                foreach (Rectangle rectangle in RectanglesList)
                {
                    if (RectenglChek.RectenglCheked(XY1, rectangle))
                    {
                        rec = rectangle;
                    }
                }
                if (rec != null)
                {
                    RectanglesList.Remove(rec);
                    rec.koord1.X = XY1.X - (XY1.X - XY2.X);
                    rec.koord1.Y = XY1.Y - (XY1.Y - XY2.Y);
                    rec.koord2.X = rec.koord1.X + rec.width;
                    rec.koord2.Y = rec.koord1.Y + rec.heigh;
                    Drowing.RectangleDrow(g, rec.koord1, rec.koord2, rec);
                    foreach (Line line in LineList)
                    {
                        if (line.rectangle1 == rec)
                        {
                            line.rectangle1 = RectanglesList.Last();
                        }
                        if (line.rectangle2 == rec)
                        {
                            line.rectangle2 = RectanglesList.Last();
                        }
                    }
                    UpdatePictur.Update(LineList, RectanglesList, g);
                    pictureBox1.Image = bmp;
                }
            }
        }
    }
}