
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Project1_Polygon_Editor
{
    public enum AppModes
    {
        Drawing,
        AddVertex,
        StartMoveVertex,
        MoveVertex,
        StartMoveEdge,
        MoveEdge,
        StartMovePolygon,
        MovePolygon,
        DeleteVertex,
        DeleteRelation,
        DeletePolygon,
        AddAngleRelation,
        AddHorizontalRelation,
        AddVerticalRelation,
        Default
    };
    public enum RelationTypes
    {
        Angle,
        Horizontal,
        Vertical
    };

    public partial class Polygon_Editor : Form
    {
        Graphics graphics;
        List<Polygon> polygons = new List<Polygon>();
        AppModes currentAppMode = AppModes.Default;
        Polygon shadowPolygon = null;

        Vertex startVertex;
        Vertex currentVertex;
        (Vertex p1, Vertex p2) currentEdge;
        Polygon currentPolygon;
        public double Angle { get; set; } = 90.0;
        public int Thickness { get; set; } = 1;

        public Polygon_Editor()
        {
            InitializeComponent();
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);

            Polygon predefined = new Polygon((new Vertex[] {
                new Vertex(194, 114),
                new Vertex(64, 194),
                new Vertex(43, 343),
                new Vertex(132, 419),
                new Vertex(137, 544),
                new Vertex(382, 455),
                new Vertex(566, 529),
                new Vertex(706, 273),
                new Vertex(573, 98),
                new Vertex(391, 175),
                new Vertex(300, 42),
                new Vertex(111, 122) }).ToList());
            predefined.AddRelation(RelationTypes.Angle, this, (null, null), predefined.vertices[4], predefined.vertices[3], predefined.vertices[5], 60);
            predefined.AddRelation(RelationTypes.Angle, this, (null, null), predefined.vertices[8], predefined.vertices[7], predefined.vertices[9], 135);
            predefined.AddRelation(RelationTypes.Horizontal, this, (predefined.vertices[10], predefined.vertices[11]));
            predefined.AddRelation(RelationTypes.Horizontal, this, (predefined.vertices[2], predefined.vertices[3]));
            predefined.AddRelation(RelationTypes.Vertical, this, (predefined.vertices[0], predefined.vertices[1]));
            predefined.AddRelation(RelationTypes.Vertical, this, (predefined.vertices[5], predefined.vertices[6]));
            polygons.Add(predefined);
            RedrawPolygons();
        }

        #region MouseHovers

        private void buttonAddVertex_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonAddVertex, "Add vertex");
        }

        private void buttonMoveVertex_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonMoveVertex, "Move vertex");
        }

        private void buttonMoveEdge_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonMoveEdge, "Move edge");
        }

        private void buttonMovePolygon_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonMovePolygon, "Move polygon");
        }

        private void buttonDeleteVertex_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonDeleteVertex, "Delete vertex");
        }

        private void buttonDeleteRelation_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonDeleteRelation, "Delete relation");
        }

        private void buttonDeletePolygon_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonDeletePolygon, "Delete polygon");
        }

        private void buttonAngle_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonAngle, "Add angle relation");
        }

        private void buttonHorizontal_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonHorizontal, "Add horizontal relation");
        }

        private void buttonVertical_MouseHover(object sender, EventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(this.buttonVertical, "Add vertical relation");
        }

        #endregion

        #region ToolStripMenuItemsClick

        private void drawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.Drawing);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveUnfinishedPoligon();
            polygons.Clear();
            RedrawPolygons();
            currentAppMode = AppModes.Default;
            drawingToolStripMenuItem.Checked = false;
            focusLabel.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ChangeModesAfterClick

        private void buttonAddVertex_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.AddVertex);
        }

        private void buttonMoveVertex_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.StartMoveVertex);
        }

        private void buttonMoveEdge_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.StartMoveEdge);
        }

        private void buttonMovePolygon_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.StartMovePolygon);
        }

        private void buttonDeleteVertex_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.DeleteVertex);
        }

        private void buttonDeleteRelation_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.DeleteRelation);
        }

        private void buttonDeletePolygon_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.DeletePolygon);
        }

        private void buttonAngle_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.AddAngleRelation);
        }

        private void buttonHorizontal_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.AddHorizontalRelation);
        }

        private void buttonVertical_Click(object sender, EventArgs e)
        {
            ChangeMode(AppModes.AddVerticalRelation);
        }

        #endregion

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            switch (currentAppMode)
            {
                case AppModes.Drawing:
                    NewPolygonDrawing(e);
                    break;
                case AppModes.DeleteVertex:
                    DeleteVertex(e);
                    break;
                case AppModes.DeleteRelation:
                    DeleteRelation(e);
                    break;
                case AppModes.DeletePolygon:
                    DeletePolygon(e);
                    break;
                case AppModes.AddVertex:
                    AddVertex(e);
                    break;
                case AppModes.AddAngleRelation:
                    AddAngleRelation(e);
                    break;
                case AppModes.AddHorizontalRelation:
                    AddHorizontalRelation(e);
                    break;
                case AppModes.AddVerticalRelation:
                    AddVerticalRelation(e);
                    break;
                case AppModes.Default:
                    {
                        ShowAngleTooltip(e);
                        DrawColorEdge(e);
                    }
                    break;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            switch (currentAppMode)
            {
                case AppModes.Drawing:
                    DrawingDynamicEdge(e);
                    break;
                case AppModes.MoveVertex:
                    MoveVertex(e);
                    break;
                case AppModes.MoveEdge:
                    MoveEdge(e);
                    break;
                case AppModes.MovePolygon:
                    MovePolygon(e);
                    break;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            switch (currentAppMode)
            {
                case AppModes.StartMoveVertex:
                    {
                        (currentPolygon, currentVertex) = GetVertexClicked(e.X, e.Y);
                        if (currentPolygon != null)
                        {
                            currentAppMode = AppModes.MoveVertex;
                            shadowPolygon = new Polygon();
                            foreach (var vertex in currentPolygon.vertices)
                                shadowPolygon.vertices.Add(new Vertex(vertex.X, vertex.Y));
                        }
                    }
                    break;
                case AppModes.StartMoveEdge:
                    {
                        (currentPolygon, currentEdge) = GetEdgeClicked(e.X, e.Y);

                        if (currentPolygon != null)
                        {
                            currentVertex = new Vertex(e.X, e.Y);
                            currentAppMode = AppModes.MoveEdge;
                            shadowPolygon = new Polygon();
                            foreach (var vertex in currentPolygon.vertices)
                                shadowPolygon.vertices.Add(new Vertex(vertex.X, vertex.Y));
                        }
                    }
                    break;
                case AppModes.StartMovePolygon:
                    {
                        currentPolygon = GetPolygonClicked(e.X, e.Y);
                        if (currentPolygon != null)
                        {
                            currentVertex = new Vertex(e.X, e.Y);
                            currentAppMode = AppModes.MovePolygon;
                            shadowPolygon = new Polygon();
                            foreach (var vertex in currentPolygon.vertices)
                                shadowPolygon.vertices.Add(new Vertex(vertex.X, vertex.Y));
                        }
                    }
                    break;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currentAppMode)
            {
                case AppModes.MoveVertex:
                    {
                        (currentPolygon, currentVertex) = (null, null);
                        shadowPolygon = null;
                        currentAppMode = AppModes.StartMoveVertex;
                        RedrawPolygons();
                    }
                    break;
                case AppModes.MoveEdge:
                    {
                        (currentPolygon, currentVertex) = (null, null);
                        currentEdge = (null, null);
                        shadowPolygon = null;
                        currentAppMode = AppModes.StartMoveEdge;
                        RedrawPolygons();
                    }
                    break;
                case AppModes.MovePolygon:
                    {
                        (currentPolygon, currentVertex) = (null, null);
                        shadowPolygon = null;
                        currentAppMode = AppModes.StartMovePolygon;
                        RedrawPolygons();
                    }
                    break;
            }
        }

        private void Polygon_Editor_SizeChanged(object sender, EventArgs e)
        {
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            graphics = Graphics.FromImage(pictureBox.Image);
            RedrawPolygons();
        }
    }
}
