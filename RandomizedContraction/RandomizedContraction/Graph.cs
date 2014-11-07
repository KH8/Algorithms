using System.Collections.Generic;
using System.Linq;

namespace RandomizedContraction
{
    public class Graph
    {
        public List<Vertex> Vertices;

        public int NumberOfVertices
        {
            get { return Vertices.Count; }
        }

        public Graph()
        {
            Vertices = new List<Vertex>();
        }

        public Vertex ReturnVortex(int id)
        {
            return Vertices.FirstOrDefault(vertex => vertex.Id == id);
        }

        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public void RemoveVertex(Vertex vertex)
        {
            Vertices.Remove(vertex);
        }

        public void AddEdge(Vertex vertex1, Vertex vertex2)
        {
            vertex1.EdgesList.Add(vertex2);
            vertex2.EdgesList.Add(vertex1);
        }

        public void RemoveEdge(Vertex vertex1, Vertex vertex2)
        {
            vertex1.EdgesList.Remove(vertex2);
            vertex2.EdgesList.Remove(vertex1);
        }

        public void ContractVertices(Vertex vertex1, Vertex vertex2)
        {
            var verticesToBeRemoved = new List<Vertex>();
            foreach (var edge in vertex2.EdgesList)
            {
                if (edge.Id != vertex1.Id && edge.Id != vertex2.Id) AddEdge(vertex1,edge);
                verticesToBeRemoved.Add(edge);
            }
            foreach (var vertex in verticesToBeRemoved)
            {
                RemoveEdge(vertex2, vertex);
            } 
            RemoveVertex(vertex2);
        }
    }
}