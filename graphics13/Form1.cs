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
