using graphics13.Models;
using System;
using System.Collections.Generic;

namespace graphics13
{
    internal class Logic
    {
        public static void brezenhem(System.Drawing.Bitmap bmp, double x1, double y1, double x2, double y2, System.Drawing.Color color)
        {
            double Px = Math.Abs(x2 - x1);
            double Py = Math.Abs(y2 - y1);
            double signX = x1 < x2 ? 1 : -1;
            double signY = y1 < y2 ? 1 : -1;
            double E = Px - Py;
            bmp.SetPixel((int)x1, (int)y1, color);
            bmp.SetPixel((int)x2, (int)y2, color);
            while (x1 != x2 || y1 != y2)
            {
                bmp.SetPixel((int)x1, (int)y1, color);
                double E2 = E * 2;
                if (E2 > -Py)
                {
                    E -= Py;
                    x1 += signX;
                }
                if (E2 < Px)
                {
                    E += Px;
                    y1 += signY;
                }
            }
        }

        public static void SortByX(List<Point> vertices)
        {
            Point temp;
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i; j < vertices.Count; j++)
                {
                    if (vertices[i].X > vertices[j].X)
                    {
                        temp = vertices[i];
                        vertices[i] = vertices[j];
                        vertices[j] = temp;
                    }
                }
            }
        }
        public static void drawTrianlge(System.Drawing.Bitmap bmp, IEnumerable<ITriangle> triangles)
        {

            IEnumerator<ITriangle> enumeratorT = triangles.GetEnumerator();
            enumeratorT.MoveNext();
            ITriangle triangle = enumeratorT.Current;
            IEnumerator<IPoint> enumeratorP = triangle.Points.GetEnumerator();
            while (enumeratorT.MoveNext())
            {
                enumeratorP.MoveNext();
                IPoint pointprev = enumeratorP.Current;
                while (enumeratorP.MoveNext())
                {
                    IPoint pointcurr = enumeratorP.Current;
                    brezenhem(bmp, pointprev.X, pointprev.Y, pointcurr.X, pointcurr.Y, System.Drawing.Color.Black);
                    pointprev = pointcurr;
                }
                enumeratorP = enumeratorT.Current.Points.GetEnumerator();
            }
            
        }

        public static void DrawShape(System.Drawing.Bitmap bmp, List<IPoint> vertices)
        {
            for(int i = 0; i < vertices.Count - 1; i++)
            {
                brezenhem(bmp, vertices[i].X, vertices[i].Y, vertices[i + 1].X, vertices[i + 1].Y, System.Drawing.Color.Black);
            }
            brezenhem(bmp, vertices[0].X, vertices[0].Y, vertices[vertices.Count-1].X, vertices[vertices.Count - 1].Y, System.Drawing.Color.Black);
        }
    }
}
