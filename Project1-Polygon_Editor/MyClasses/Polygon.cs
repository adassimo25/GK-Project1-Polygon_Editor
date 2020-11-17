
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project1_Polygon_Editor
{
    public class Polygon
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<IRelation> relations = new List<IRelation>();
        public int freeEdges { get; set; }

        public Polygon() { }

        public Polygon(List<Vertex> vertices)
        {
            this.vertices = new List<Vertex>(vertices);
            freeEdges = vertices.Count;
        }

        public (Vertex, Vertex)[] GetOuterEdges(Vertex vertex)
        {
            int vertexCount = vertices.Count;
            int vertexIndex = vertices.IndexOf(vertex);
            return new (Vertex, Vertex)[] { (vertex, vertices[(vertexIndex - 1 + vertexCount) % vertexCount]), (vertex, vertices[(vertexIndex + 1) % vertexCount]) };
        }

        public List<IRelation> GetVertexRelations(Vertex vertex, List<IRelation> relations)
        {
            List<IRelation> vertexRelations = new List<IRelation>();
            (Vertex, Vertex)[] vertexOuterEdges = GetOuterEdges(vertex);
            foreach (var edge in vertexOuterEdges)
                foreach (var relation in relations)
                    if (relation.IsEdgeInRelation(edge) && !vertexRelations.Contains(relation))
                        vertexRelations.Add(relation);
            return vertexRelations;
        }

        public IRelation GetEdgeRelation((Vertex p1, Vertex p2) edge)
        {
            foreach (var relation in relations)
                if (relation.IsEdgeInRelation(edge))
                    return relation;
            return null;
        }

        public bool HaveCloseEdgesRelations(RelationTypes relationToCheck, Vertex vertex)
        {
            foreach (var outerEdge in GetOuterEdges(vertex))
            {
                IRelation relation = GetEdgeRelation(outerEdge);
                if (relation != null)
                    if (relation.RelationType == relationToCheck)
                        return true;
            }
            return false;
        }

        public bool CanAddRelationToEdge(RelationTypes relationType, (Vertex p1, Vertex p2) edge)
        {
            switch (relationType)
            {
                case RelationTypes.Angle:
                    {
                        //relację można dodać do wielokąta jeśli krawędzie (v1, vertex) oraz (vertex, v2) nie mają ustawionych relacji
                        if (GetEdgeRelation(edge) != null)
                        {
                            MessageBox.Show("Some close edge(s) has/have relation(s) assigned!", "Cannot set angle", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (freeEdges < 3)
                        {
                            MessageBox.Show("There must be at least 3 edges without relation in polygon!", "Cannot add relation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
                case RelationTypes.Horizontal:
                    {
                        //relację można dodać do wielokąta, jeśli krawędź nie jest w żadnej relacji,
                        //a sąsiednie krawędzie nie mają relacji Horizontal;
                        if (GetEdgeRelation(edge) != null)
                        {
                            MessageBox.Show("Some relation is assigned to this edge!", "Cannot add horizontal relation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (HaveCloseEdgesRelations(RelationTypes.Horizontal, edge.p1) || HaveCloseEdgesRelations(RelationTypes.Horizontal, edge.p2))
                        {
                            MessageBox.Show("Some close edge has horizontal relation assigned!", "Cannot add horizontal relation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (freeEdges < 2)
                        {
                            MessageBox.Show("There must be at least 2 edges without relation in polygon!", "Cannot add relation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
                case RelationTypes.Vertical:
                    {
                        //relację można dodać do wielokąta, jeśli krawędź nie jest w żadnej relacji,
                        //a sąsiednie krawędzie nie mają relacji Vertical;
                        if (GetEdgeRelation(edge) != null)
                        {
                            MessageBox.Show("Some relation is assigned to this edge!", "Cannot add vertical relation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (HaveCloseEdgesRelations(RelationTypes.Vertical, edge.p1) || HaveCloseEdgesRelations(RelationTypes.Vertical, edge.p2))
                        {
                            MessageBox.Show("Some close edge has vertical relation assigned!", "Cannot add vertical relation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (freeEdges < 2)
                        {
                            MessageBox.Show("There must be at least 2 edges without relation in polygon!", "Cannot add relation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        return true;
                    }
            }
            return false;
        }

        public void AddRelation(RelationTypes relationType, Polygon_Editor polygon_Editor, (Vertex p1, Vertex p2) edge, Vertex vertex = null, Vertex v1 = null, Vertex v2 = null, double? angle = null)
        {
            switch (relationType)
            {
                case RelationTypes.Angle:
                    {
                        if (CanAddRelationToEdge(relationType, (v1, vertex)) && CanAddRelationToEdge(relationType, (vertex, v2)))
                        {
                            if (angle == null)
                            {
                                AddAngleForm addAngleForm = new AddAngleForm(polygon_Editor);
                                addAngleForm.ShowDialog();
                                relations.Add(new AngleRelation(vertex, v1, v2, polygon_Editor.Angle));
                                polygon_Editor.Angle = 90.0;
                            }
                            else
                                relations.Add(new AngleRelation(vertex, v1, v2, (double)angle));
                            freeEdges -= 2;
                            CorrectRelations(v1, relations);
                        }
                    }
                    break;
                case RelationTypes.Horizontal:
                    {
                        if (CanAddRelationToEdge(relationType, edge))
                        {
                            relations.Add(new HorizontalRelation(edge));
                            freeEdges--;
                            CorrectRelations(edge.p1, relations);
                        }
                    }
                    break;
                case RelationTypes.Vertical:
                    {
                        if (CanAddRelationToEdge(relationType, edge))
                        {
                            relations.Add(new VerticalRelation(edge));
                            freeEdges--;
                            CorrectRelations(edge.p1, relations);
                        }
                    }
                    break;
            }
        }

        public void CorrectRelations(Vertex vertex, List<IRelation> relations, int dX = 0, int dY = 0)
        {
            //warunek STOPu rekurencji
            if (relations.Count == 0)
                return;
            //wyznaczenie relacji zawierających wierzchołek
            List<IRelation> vertexRelations = GetVertexRelations(vertex, relations);
            //poprawienie relacji wierzchołka
            foreach (var relation in vertexRelations)
            {
                Vertex[] modifiedVertices = relation.CorrectRelation(vertex, dX, dY);
                //nowy zbiór relacji
                List<IRelation> nextStepRelations = new List<IRelation>();
                relations.ForEach(r => { nextStepRelations.Add(r); });
                nextStepRelations.Remove(relation);
                foreach (var modifiedVertex in modifiedVertices)
                    CorrectRelations(modifiedVertex, nextStepRelations); //rekurencja
            }
        }
    }
}
