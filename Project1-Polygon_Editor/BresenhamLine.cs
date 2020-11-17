
using System.Drawing;

namespace Project1_Polygon_Editor
{
    public partial class MyDraw
    {
        // źródło: https://pl.wikipedia.org/wiki/Algorytm_Bresenhama#Rysowanie_odcinka_algorytmem_Bresenhama
        // Vertex Vertex1 - współrzędne początku odcinka
        // Vertex Vertex2 - współrzędne końca odcinka
        public static void BresenhamLine(Graphics graphics, Vertex Vertex1, Vertex Vertex2, Color color, int thickness = 1)
        {
            Pen pen = new Pen(color);
            // zmienne pomocnicze
            int d, dx, dy, ai, bi, xi, yi;
            int x = Vertex1.X, y = Vertex1.Y;
            // ustalenie kierunku rysowania
            if (Vertex1.X < Vertex2.X)
            {
                xi = 1;
                dx = Vertex2.X - Vertex1.X;
            }
            else
            {
                xi = -1;
                dx = Vertex1.X - Vertex2.X;
            }
            // ustalenie kierunku rysowania
            if (Vertex1.Y < Vertex2.Y)
            {
                yi = 1;
                dy = Vertex2.Y - Vertex1.Y;
            }
            else
            {
                yi = -1;
                dy = Vertex1.Y - Vertex2.Y;
            }
            // pierwszy piksel
            graphics.FillRectangle(pen.Brush, x - thickness / 2, y - thickness / 2, thickness, thickness);
            // oś wiodąca OX
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                // pętla po kolejnych x
                while (x != Vertex2.X)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    graphics.FillRectangle(pen.Brush, x - thickness / 2, y - thickness / 2, thickness, thickness);
                }
            }
            // oś wiodąca OY
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                // pętla po kolejnych y
                while (y != Vertex2.Y)
                {
                    // test współczynnika
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    graphics.FillRectangle(pen.Brush, x - thickness / 2, y - thickness / 2, thickness, thickness);
                }
            }
        }
    }
}
