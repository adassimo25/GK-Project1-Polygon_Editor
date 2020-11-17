
using System.Windows.Forms;
using System.Drawing;

namespace Project1_Polygon_Editor
{
    public partial class Polygon_Editor : Form
    {
        #region ClickEvents

        private void NewPolygonDrawing(MouseEventArgs e)
        {
            if (startVertex == null)
            {
                startVertex = new Vertex(e.X, e.Y);
                currentVertex = startVertex;
                currentPolygon = new Polygon();
                currentPolygon.vertices.Add(startVertex);
            }
            else if (CheckClick.Vertex(startVertex, e.X, e.Y))
            {
                if (currentPolygon.vertices.Count > 2)
                    polygons.Add(currentPolygon);
                startVertex = null;
                (currentPolygon, currentVertex) = (null, null);
            }
            else
            {
                bool uniqueVertex = true;
                foreach (var vertex in currentPolygon.vertices)
                    if (CheckClick.Vertex(vertex, e.X, e.Y))
                    {
                        uniqueVertex = false;
                        break;
                    }
                if (uniqueVertex)
                {
                    currentVertex = new Vertex(e.X, e.Y);
                    currentPolygon.vertices.Add(currentVertex);
                }
            }
            graphics.Clear(pictureBox.BackColor);
            MyDraw.AllPolygons(graphics, polygons);
            if (startVertex != null)
            {
                MyDraw.Vertex(graphics, startVertex);
                for (int i = 1; i < currentPolygon.vertices.Count; i++)
                {
                    MyDraw.BresenhamLine(graphics, currentPolygon.vertices[i - 1], currentPolygon.vertices[i], MyDraw.defaultColor);
                    MyDraw.Vertex(graphics, currentPolygon.vertices[i]);
                }
            }
            pictureBox.Refresh();
        }

        #region DeletingObjects

        private void DeleteVertex(MouseEventArgs e)
        {
            (currentPolygon, currentVertex) = GetVertexClicked(e.X, e.Y);
            if (currentPolygon != null)
            {
                foreach (var edge in currentPolygon.GetOuterEdges(currentVertex))
                {
                    IRelation r = currentPolygon.GetEdgeRelation(edge);
                    currentPolygon.relations.Remove(r);
                    if (r != null)
                        currentPolygon.freeEdges += (r.RelationType == RelationTypes.Angle ? 2 : 1);
                }
                currentPolygon.vertices.Remove(currentVertex);
                currentPolygon.freeEdges -= 1;
                if (currentPolygon.vertices.Count <= 2)
                    polygons.Remove(currentPolygon);
                (currentPolygon, currentVertex) = (null, null);
                RedrawPolygons();
            }
        }

        private void DeleteRelation(MouseEventArgs e)
        {
            Polygon p;
            IRelation r;
            foreach (var polygon in polygons)
                foreach (var relation in polygon.relations)
                    if (relation.IsRelationClicked(e.X, e.Y))
                    {
                        p = polygon;
                        r = relation;
                        p.relations.Remove(r);
                        p.freeEdges += (relation.RelationType == RelationTypes.Angle ? 2 : 1);
                        RedrawPolygons();
                        return;
                    }
        }

        private void DeletePolygon(MouseEventArgs e)
        {
            currentPolygon = GetPolygonClicked(e.X, e.Y);
            polygons.Remove(currentPolygon);
            currentPolygon = null;
            RedrawPolygons();
        }

        #endregion

        private void AddVertex(MouseEventArgs e)
        {
            (currentPolygon, currentVertex) = GetVertexClicked(e.X, e.Y);
            if (currentPolygon != null)
            {
                (currentPolygon, currentVertex) = (null, null);
                return;
            }
            (currentPolygon, currentEdge) = GetEdgeClicked(e.X, e.Y);
            if (currentPolygon != null)
            {
                Vertex newVertex = new Vertex(e.X, e.Y);
                IRelation relation = currentPolygon.GetEdgeRelation(currentEdge);
                currentPolygon.relations.Remove(relation);
                currentPolygon.freeEdges += relation != null ? (relation.RelationType == RelationTypes.Angle ? 3 : 2) : 1;
                currentPolygon.vertices.Insert(currentPolygon.vertices.IndexOf(currentEdge.p2), newVertex);
                polygons.Add(currentPolygon);
                currentPolygon = null;
                currentEdge = (null, null);
                RedrawPolygons();
            }
        }

        #region AddingRelations

        private void AddAngleRelation(MouseEventArgs e)
        {
            (currentPolygon, currentVertex) = GetVertexClicked(e.X, e.Y);
            if (currentPolygon != null)
            {
                (Vertex, Vertex)[] outerEdges = currentPolygon.GetOuterEdges(currentVertex);
                currentPolygon.AddRelation(RelationTypes.Angle, this, (null, null), currentVertex, outerEdges[0].Item2, outerEdges[1].Item2);
                (currentPolygon, currentVertex) = (null, null);
                RedrawPolygons();
            }
        }

        private void AddHorizontalRelation(MouseEventArgs e)
        {
            (currentPolygon, currentEdge) = GetEdgeClicked(e.X, e.Y);
            if (currentPolygon != null)
            {
                currentPolygon.AddRelation(RelationTypes.Horizontal, this, currentEdge);
                currentPolygon = null;
                currentEdge = (null, null);
                RedrawPolygons();
            }
        }

        private void AddVerticalRelation(MouseEventArgs e)
        {
            (currentPolygon, currentEdge) = GetEdgeClicked(e.X, e.Y);
            if (currentPolygon != null)
            {
                currentPolygon.AddRelation(RelationTypes.Vertical, this, currentEdge);
                currentPolygon = null;
                currentEdge = (null, null);
                RedrawPolygons();
            }
        }

        #endregion

        private void ShowAngleTooltip(MouseEventArgs e)
        {
            foreach (var polygon in polygons)
                foreach (var relation in polygon.relations)
                    if (relation.RelationType == RelationTypes.Angle)
                        if (CheckClick.Vertex(((AngleRelation)relation).vertex, e.X, e.Y))
                            (new ToolTip()).SetToolTip(this.pictureBox, $"Angle measure: {((AngleRelation)relation).angle}°");
        }

        private void DrawColorEdge(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                (currentPolygon, currentEdge) = GetEdgeClicked(e.X, e.Y);
                if (currentPolygon != null)
                {
                    Color color = MyDraw.defaultColor;
                    ColorDialog MyDialog = new ColorDialog();
                    MyDialog.AllowFullOpen = false;
                    if (MyDialog.ShowDialog() == DialogResult.OK)
                        color = MyDialog.Color;
                    ThicknessForm thicknessForm = new ThicknessForm(this);
                    thicknessForm.ShowDialog();
                    MyDraw.BresenhamLine(graphics, currentEdge.p1, currentEdge.p2, color, Thickness);
                    MyDraw.Vertex(graphics, currentEdge.p1);
                    MyDraw.Vertex(graphics, currentEdge.p2);
                    graphics.DrawString($"{currentPolygon.vertices.IndexOf(currentEdge.p1)}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(currentEdge.p1.X, currentEdge.p1.Y));
                    graphics.DrawString($"{currentPolygon.vertices.IndexOf(currentEdge.p2)}", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new Point(currentEdge.p2.X, currentEdge.p2.Y));
                    IRelation r = currentPolygon.GetEdgeRelation(currentEdge);
                    if (r != null)
                        r.DrawRelationImage(graphics);
                    currentPolygon = null;
                    currentEdge = (null, null);
                    pictureBox.Refresh();
                }
            }
        }

        #endregion

        #region MouseMoveEvents

        private void DrawingDynamicEdge(MouseEventArgs e)
        {
            graphics.Clear(pictureBox.BackColor);
            MyDraw.AllPolygons(graphics, polygons);
            if (startVertex != null)
            {
                MyDraw.Vertex(graphics, startVertex);
                for (int i = 1; i < currentPolygon.vertices.Count; i++)
                {
                    MyDraw.BresenhamLine(graphics, currentPolygon.vertices[i - 1], currentPolygon.vertices[i], MyDraw.defaultColor);
                    MyDraw.Vertex(graphics, currentPolygon.vertices[i]);
                }
                MyDraw.BresenhamLine(graphics, currentVertex, new Vertex(e.X, e.Y), MyDraw.defaultColor);
                pictureBox.Refresh();
            }
        }

        private void MoveVertex(MouseEventArgs e)
        {
            int dX = e.X - currentVertex.X, dY = e.Y - currentVertex.Y;
            int i = currentPolygon.vertices.IndexOf(currentVertex);
            ChangeVertexLocation(currentPolygon.vertices[i], dX, dY);
            currentPolygon.CorrectRelations(currentPolygon.vertices[i], currentPolygon.relations, dX, dY);
            currentVertex = currentPolygon.vertices[i];
            RedrawPolygons();
        }

        private void MoveEdge(MouseEventArgs e)
        {
            int dX = e.X - currentVertex.X, dY = e.Y - currentVertex.Y;
            ChangeVertexLocation(currentEdge.p1, dX, dY);
            ChangeVertexLocation(currentEdge.p2, dX, dY);
            currentPolygon.CorrectRelations(currentEdge.p1, currentPolygon.relations);
            currentPolygon.CorrectRelations(currentEdge.p2, currentPolygon.relations);
            currentVertex = new Vertex(e.X, e.Y);
            RedrawPolygons();
        }

        private void MovePolygon(MouseEventArgs e)
        {
            int dX = e.X - currentVertex.X, dY = e.Y - currentVertex.Y;
            for (int i = 0; i < currentPolygon.vertices.Count; i++)
                ChangeVertexLocation(currentPolygon.vertices[i], dX, dY);
            currentVertex = new Vertex(e.X, e.Y);
            RedrawPolygons();
        }

        #endregion

        #region GettingObjects

        private (Polygon, Vertex) GetVertexClicked(int mouseX, int mouseY)
        {
            foreach (var polygon in polygons)
                foreach (var vertex in polygon.vertices)
                    if (CheckClick.Vertex(vertex, mouseX, mouseY))
                        return (polygon, vertex);
            return (null, null);
        }

        private (Polygon, (Vertex, Vertex)) GetEdgeClicked(double mouseX, double mouseY)
        {
            foreach (var polygon in polygons)
                for (int i = 0; i < polygon.vertices.Count; i++)
                    if (CheckClick.Edge((polygon.vertices[i], polygon.vertices[(i + 1) % polygon.vertices.Count]), mouseX, mouseY))
                        return (polygon, (polygon.vertices[i], polygon.vertices[(i + 1) % polygon.vertices.Count]));
            return (null, (null, null));
        }

        private Polygon GetPolygonClicked(int mouseX, int mouseY)
        {
            foreach (var polygon in polygons)
                if (CheckClick.Polygon(polygon, mouseX, mouseY))
                    return polygon;
            return null;
        }

        #endregion

        #region RedrawingPolygons

        private void RedrawPolygons()
        {
            graphics.Clear(pictureBox.BackColor);
            if (shadowPolygon != null)
                MyDraw.Polygon(graphics, shadowPolygon);
            MyDraw.AllPolygons(graphics, polygons);
            pictureBox.Refresh();
        }

        #endregion

        #region ChangingVertexLocation

        public static void ChangeVertexLocation(Vertex vertex, int dX, int dY)
        {
            vertex.X += dX;
            vertex.Y += dY;
        }

        #endregion

        #region ComparingEdges

        public static bool EdgesComparison((Vertex p1, Vertex p2) edge1, (Vertex p1, Vertex p2) edge2)
        {
            return ((edge1.p1 == edge2.p1 && edge1.p2 == edge2.p2) || (edge1.p1 == edge2.p2 && edge1.p2 == edge2.p1));
        }

        #endregion

        #region ChangingModes

        private void RemoveUnfinishedPoligon()
        {
            if (currentAppMode == AppModes.Drawing && startVertex != null)
            {
                startVertex = null;
                currentVertex = null;
                currentPolygon = null;
                RedrawPolygons();
            }
        }

        private void ChangeMode(AppModes newMode)
        {
            RemoveUnfinishedPoligon();
            drawingToolStripMenuItem.Checked = false;
            if (currentAppMode != newMode)
            {
                currentAppMode = newMode;
                if (newMode == AppModes.Drawing)
                {
                    drawingToolStripMenuItem.Checked = true;
                    focusLabel.Focus();
                }
                return;
            }
            currentAppMode = AppModes.Default;
            focusLabel.Focus();
        }

        #endregion
    }
}
