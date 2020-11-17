
using System.Collections.Generic;
using System.Drawing;

namespace Project1_Polygon_Editor
{
    public static partial class MyDraw
    {
        public static Color defaultColor = Color.Black;

        public static void Vertex(Graphics graphics, Vertex vertex)
        {
            graphics.FillRectangle(Brushes.Black, vertex.X - Constants.tol, vertex.Y - Constants.tol, 2 * Constants.tol, 2 * Constants.tol);
        }

        public static void Edge(Graphics graphics, (Vertex p1, Vertex p2) edge)
        {
            BresenhamLine(graphics, edge.p1, edge.p2, defaultColor);
        }

        public static void Polygon(Graphics graphics, Polygon polygon)
        {
            for (int i = 0; i < polygon.vertices.Count; i++)
            {
                Vertex v = polygon.vertices[i];
                Vertex(graphics, v);
                graphics.DrawString($"{i}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(v.X, v.Y));
            }
            for (int i = 0; i < polygon.vertices.Count; i++)
                Edge(graphics, (polygon.vertices[i], polygon.vertices[(i + 1) % polygon.vertices.Count]));
            foreach (var relation in polygon.relations)
                relation.DrawRelationImage(graphics);
        }

        public static void AllPolygons(Graphics graphics, List<Polygon> polygons)
        {
            foreach (var polygon in polygons)
                Polygon(graphics, polygon);
        }
    }
}
