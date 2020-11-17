
using System;
using System.Drawing;
using System.Linq;
using Project1_Polygon_Editor.Properties;

namespace Project1_Polygon_Editor
{
    public interface IRelation
    {
        RelationTypes RelationType { get; set; }
        void DrawRelationImage(Graphics graphics);
        bool IsEdgeInRelation((Vertex p1, Vertex p2) edge);
        bool IsRelationClicked(int mouseX, int mouseY);
        Vertex[] CorrectRelation(Vertex vertex, int dX, int dY);
        void CalculateRelationImageLocation();
    }

    public class AngleRelation : IRelation
    {
        public RelationTypes RelationType { get; set; }
        public Vertex vertex;
        Vertex v1;
        Vertex v2;
        public double angle;

        double edge1Length;
        double edge2Length;
        int midEdge1_X;
        int midEdge1_Y;
        int midEdge2_X;
        int midEdge2_Y;

        public AngleRelation(Vertex vertex, Vertex v1, Vertex v2, double angle)
        {
            RelationType = RelationTypes.Angle;
            this.vertex = vertex;
            this.v1 = v1;
            this.v2 = v2;
            this.angle = angle;

            edge1Length = CalculateLength((v1, vertex));
            edge2Length = CalculateLength((vertex, v2));
            CalculateRelationImageLocation();
        }

        public void DrawRelationImage(Graphics graphics)
        {
            CalculateRelationImageLocation();
            graphics.FillRectangle(Brushes.Red, midEdge1_X - Constants.backSize, midEdge1_Y - Constants.backSize, 2 * Constants.backSize, 2 * Constants.backSize);
            graphics.DrawImage(Resources.angle, midEdge1_X - Constants.imgSize, midEdge1_Y - Constants.imgSize, 2 * Constants.imgSize, 2 * Constants.imgSize);
            graphics.FillRectangle(Brushes.Red, midEdge2_X - Constants.backSize, midEdge2_Y - Constants.backSize, 2 * Constants.backSize, 2 * Constants.backSize);
            graphics.DrawImage(Resources.angle, midEdge2_X - Constants.imgSize, midEdge2_Y - Constants.imgSize, 2 * Constants.imgSize, 2 * Constants.imgSize);
            graphics.FillRectangle(Brushes.Red, vertex.X - Constants.tol, vertex.Y - Constants.tol, 2 * Constants.tol, 2 * Constants.tol);
            graphics.DrawEllipse(Pens.Red, vertex.X - 3 * Constants.tol - 1, vertex.Y - 3 * Constants.tol - 1, 6 * Constants.tol + 1, 6 * Constants.tol + 1);
        }

        public bool IsEdgeInRelation((Vertex p1, Vertex p2) edge)
        {
            return (Polygon_Editor.EdgesComparison(edge, (v1, vertex)) || Polygon_Editor.EdgesComparison(edge, (vertex, v2)));
        }

        public bool IsRelationClicked(int mouseX, int mouseY)
        {
            Vertex[] img1vertices = { new Vertex(midEdge1_X - Constants.backSize, midEdge1_Y - Constants.backSize), new Vertex(midEdge1_X + Constants.backSize, midEdge1_Y - Constants.backSize), new Vertex(midEdge1_X + Constants.backSize, midEdge1_Y + Constants.backSize), new Vertex(midEdge1_X - Constants.backSize, midEdge1_Y + Constants.backSize) };
            Polygon img1 = new Polygon(img1vertices.ToList());
            Vertex[] img2vertices = { new Vertex(midEdge2_X - Constants.backSize, midEdge2_Y - Constants.backSize), new Vertex(midEdge2_X + Constants.backSize, midEdge2_Y - Constants.backSize), new Vertex(midEdge2_X + Constants.backSize, midEdge2_Y + Constants.backSize), new Vertex(midEdge2_X - Constants.backSize, midEdge2_Y + Constants.backSize) };
            Polygon img2 = new Polygon(img2vertices.ToList());
            return (CheckClick.Vertex(vertex, mouseX, mouseY) || CheckClick.Polygon(img1, mouseX, mouseY) || CheckClick.Polygon(img2, mouseX, mouseY));
        }

        public Vertex[] CorrectRelation(Vertex vertex, int dX, int dY)
        {
            if (vertex == this.vertex)
            {
                if (dX == 0 && dY == 0)
                    return new Vertex[] { };
                Polygon_Editor.ChangeVertexLocation(v1, dX, dY);
                Polygon_Editor.ChangeVertexLocation(v2, dX, dY);
                return new Vertex[] { v1, v2 };
            }
            Vertex newV = (vertex == v1 ? new Vertex(v1.X, v1.Y) : new Vertex(v2.X, v2.Y));
            Vertex selectedV = (vertex == v1 ? v1 : v2);
            double tmpAngle = (vertex == v1 ? angle : (360 - angle));

            newV.X -= this.vertex.X;
            newV.Y -= this.vertex.Y;
            (newV.X, newV.Y) = ((int)(newV.X * Math.Cos(tmpAngle / 360 * 2 * Math.PI) - newV.Y * Math.Sin(tmpAngle / 360 * 2 * Math.PI)), (int)(newV.X * Math.Sin(tmpAngle / 360 * 2 * Math.PI) + newV.Y * Math.Cos(tmpAngle / 360 * 2 * Math.PI)));
            newV.X += this.vertex.X;
            newV.Y += this.vertex.Y;

            if (selectedV == v1)
            {
                edge1Length = CalculateLength((v1, this.vertex));
                v2.X = this.vertex.X + (int)((newV.X - this.vertex.X) * edge2Length / edge1Length);
                v2.Y = this.vertex.Y + (int)((newV.Y - this.vertex.Y) * edge2Length / edge1Length);
                CalculateRelationImageLocation();
                return new Vertex[] { v2 };
            }
            else
            {
                edge2Length = CalculateLength((this.vertex, v2));
                v1.X = this.vertex.X + (int)((newV.X - this.vertex.X) * edge1Length / edge2Length);
                v1.Y = this.vertex.Y + (int)((newV.Y - this.vertex.Y) * edge1Length / edge2Length);
                CalculateRelationImageLocation();
                return new Vertex[] { v1 };
            }
        }

        public void CalculateRelationImageLocation()
        {
            midEdge1_X = Math.Max(v1.X, vertex.X) - Math.Abs(v1.X - vertex.X) / 2;
            midEdge1_Y = Math.Max(v1.Y, vertex.Y) - Math.Abs(v1.Y - vertex.Y) / 2;
            midEdge2_X = Math.Max(vertex.X, v2.X) - Math.Abs(vertex.X - v2.X) / 2;
            midEdge2_Y = Math.Max(vertex.Y, v2.Y) - Math.Abs(vertex.Y - v2.Y) / 2;
        }

        private double CalculateLength((Vertex p1, Vertex p2) edge)
        {
            return Math.Sqrt((edge.p1.X - edge.p2.X) * (edge.p1.X - edge.p2.X) + (edge.p1.Y - edge.p2.Y) * (edge.p1.Y - edge.p2.Y));
        }
    }

    public class HorizontalRelation : IRelation
    {
        public RelationTypes RelationType { get; set; }
        Vertex v1;
        Vertex v2;

        int midEdge_X;
        int midEdge_Y;

        public HorizontalRelation((Vertex p1, Vertex p2) edge)
        {
            RelationType = RelationTypes.Horizontal;
            v1 = edge.p1;
            v2 = edge.p2;
            CalculateRelationImageLocation();
        }

        public void DrawRelationImage(Graphics graphics)
        {
            CalculateRelationImageLocation();
            graphics.FillRectangle(Brushes.Green, midEdge_X - Constants.backSize, midEdge_Y - Constants.backSize, 2 * Constants.backSize, 2 * Constants.backSize);
            graphics.DrawImage(Resources.horizontal, midEdge_X - Constants.imgSize, midEdge_Y - Constants.imgSize, 2 * Constants.imgSize, 2 * Constants.imgSize);
        }

        public bool IsEdgeInRelation((Vertex p1, Vertex p2) edge)
        {
            return Polygon_Editor.EdgesComparison(edge, (v1, v2));
        }

        public bool IsRelationClicked(int mouseX, int mouseY)
        {
            Vertex[] imgVertices = { new Vertex(midEdge_X - Constants.backSize, midEdge_Y - Constants.backSize), new Vertex(midEdge_X + Constants.backSize, midEdge_Y - Constants.backSize), new Vertex(midEdge_X + Constants.backSize, midEdge_Y + Constants.backSize), new Vertex(midEdge_X - Constants.backSize, midEdge_Y + Constants.backSize) };
            Polygon img = new Polygon(imgVertices.ToList());
            return CheckClick.Polygon(img, mouseX, mouseY);
        }

        public Vertex[] CorrectRelation(Vertex vertex, int dX, int dY)
        {
            if (vertex == v1)
            {
                v2.Y = vertex.Y;
                CalculateRelationImageLocation();
                return new Vertex[] { v2 };
            }
            v1.Y = vertex.Y;
            CalculateRelationImageLocation();
            return new Vertex[] { v1 };
        }

        public void CalculateRelationImageLocation()
        {
            midEdge_X = Math.Max(v1.X, v2.X) - Math.Abs(v1.X - v2.X) / 2;
            midEdge_Y = Math.Max(v1.Y, v2.Y) - Math.Abs(v1.Y - v2.Y) / 2;
        }
    }

    public class VerticalRelation : IRelation
    {
        public RelationTypes RelationType { get; set; }
        Vertex v1;
        Vertex v2;

        int midEdge_X;
        int midEdge_Y;

        public VerticalRelation((Vertex p1, Vertex p2) edge)
        {
            RelationType = RelationTypes.Vertical;
            v1 = edge.p1;
            v2 = edge.p2;
            CalculateRelationImageLocation();
        }

        public void DrawRelationImage(Graphics graphics)
        {
            CalculateRelationImageLocation();
            graphics.FillRectangle(Brushes.Yellow, midEdge_X - Constants.backSize, midEdge_Y - Constants.backSize, 2 * Constants.backSize, 2 * Constants.backSize);
            graphics.DrawImage(Resources.vertical, midEdge_X - Constants.imgSize, midEdge_Y - Constants.imgSize, 2 * Constants.imgSize, 2 * Constants.imgSize);
        }

        public bool IsEdgeInRelation((Vertex p1, Vertex p2) edge)
        {
            return Polygon_Editor.EdgesComparison(edge, (v1, v2));
        }

        public bool IsRelationClicked(int mouseX, int mouseY)
        {
            Vertex[] imgVertices = { new Vertex(midEdge_X - Constants.backSize, midEdge_Y - Constants.backSize), new Vertex(midEdge_X + Constants.backSize, midEdge_Y - Constants.backSize), new Vertex(midEdge_X + Constants.backSize, midEdge_Y + Constants.backSize), new Vertex(midEdge_X - Constants.backSize, midEdge_Y + Constants.backSize) };
            Polygon img = new Polygon(imgVertices.ToList());
            return CheckClick.Polygon(img, mouseX, mouseY);
        }

        public Vertex[] CorrectRelation(Vertex vertex, int dX, int dY)
        {
            if (vertex == v1)
            {
                v2.X = vertex.X;
                CalculateRelationImageLocation();
                return new Vertex[] { v2 };
            }
            v1.X = vertex.X;
            CalculateRelationImageLocation();
            return new Vertex[] { v1 };
        }

        public void CalculateRelationImageLocation()
        {
            midEdge_X = Math.Max(v1.X, v2.X) - Math.Abs(v1.X - v2.X) / 2;
            midEdge_Y = Math.Max(v1.Y, v2.Y) - Math.Abs(v1.Y - v2.Y) / 2;
        }
    }
}
