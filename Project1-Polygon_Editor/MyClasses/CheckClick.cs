
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Project1_Polygon_Editor
{
    public static class CheckClick
    {
        public static bool Vertex(Vertex vertex, int mouseX, int mouseY)
        {
            return Math.Sqrt((float)((mouseX - vertex.X) * (mouseX - vertex.X) + (mouseY - vertex.Y) * (mouseY - vertex.Y))) <= Constants.tol;
        }

        public static bool Edge((Vertex p1, Vertex p2) edge, double mouseX, double mouseY)
        {
            double x1 = edge.p1.X, x2 = edge.p2.X, y1 = edge.p1.Y, y2 = edge.p2.Y;
            double a2 = (x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2);
            double b2 = (mouseX - x2) * (mouseX - x2) + (mouseY - y2) * (mouseY - y2);
            double c2 = (x1 - mouseX) * (x1 - mouseX) + (y1 - mouseY) * (y1 - mouseY);
            //Jeśli długości boków tworzą trójkąt rozwartokątny i AB nie jest najdłuższym bokiem trójkąta,
            //to rzut punktu P na prostą zawierającą odcinek jest poza nim
            if ((a2 > b2 + c2 || b2 > a2 + c2 || c2 > a2 + b2) && !(a2 > b2 && a2 > c2))
                return false;
            double d = (x1 != x2 ? Math.Abs((y2 - y1) / (x2 - x1) * mouseX - mouseY + (x2 * y1 - x1 * y2) / (x2 - x1)) / Math.Sqrt(Math.Pow((y2 - y1) / (x2 - x1), 2) + 1) : Math.Abs(mouseX - x1));
            if (d <= Constants.tol)
                return true;
            return false;
        }

        public static bool Polygon(Polygon polygon, int mouseX, int mouseY)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            List<Point> vertices = new List<Point>();
            foreach (var vertex in polygon.vertices)
                vertices.Add(new Point(vertex.X, vertex.Y));
            graphicsPath.AddPolygon(vertices.ToArray());
            if (graphicsPath.IsVisible(mouseX, mouseY))
                return true;
            return false;
        }
    }
}
