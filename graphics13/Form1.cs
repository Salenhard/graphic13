using graphics13.Models;
using System.Windows.Forms;
using System.Collections.Generic;
namespace graphics13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bmp = new System.Drawing.Bitmap(pictureBox1.Width, pictureBox1.Height);
            vertices = new List<IPoint>();
        }
        List<IPoint> vertices;
        System.Drawing.Bitmap bmp;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button== MouseButtons.Left)
            {
                vertices.Add(new Point(e.X, e.Y));
                bmp = new System.Drawing.Bitmap(bmp.Width, bmp.Height);
                if (vertices.Count > 3)
                {
                    Logic.brezenhem(bmp, vertices[0].X, vertices[0].Y, vertices[1].X, vertices[1].Y, System.Drawing.Color.Black);
                    Logic.brezenhem(bmp, vertices[0].X, vertices[0].Y, vertices[2].X, vertices[2].Y, System.Drawing.Color.Black);
                    Logic.brezenhem(bmp, vertices[2].X, vertices[2].Y, vertices[1].X, vertices[1].Y, System.Drawing.Color.Black);
                    Delaunator delaunator = new Delaunator(vertices.ToArray());
                    Logic.drawTrianlge(bmp, delaunator.GetTriangles());
                }
                Logic.DrawShape(bmp, vertices);
                pictureBox1.Image = bmp;
            }

            if(e.Button== MouseButtons.Right)
            {
                vertices.Clear();
                bmp = new System.Drawing.Bitmap(bmp.Width,bmp.Height);
                pictureBox1.Image = bmp;
            }
        }
    }
}
