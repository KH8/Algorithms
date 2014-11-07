using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RandomizedContraction
{
    public class Graph : ICloneable
    {
        public List<Vertex> Vertices;
        public List<KeyValuePair<int, int>> Edges; 

        public int NumberOfVertices
        {
            get { return Vertices.Count; }
        }

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<KeyValuePair<int, int>>();
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
            Edges.Add(new KeyValuePair<int, int>(vertex1.Id, vertex2.Id));
            vertex1.EdgesList.Add(vertex2);
            vertex2.EdgesList.Add(vertex1);
        }

        public void RemoveEdge(Vertex vertex1, Vertex vertex2)
        {
            var keyInitial = new KeyValuePair<int, int>();

            var keyToBeRemoved = keyInitial;
            foreach (var keyValuePair in Edges.Where(keyValuePair => keyValuePair.Key == vertex1.Id && keyValuePair.Value == vertex2.Id)) keyToBeRemoved = keyValuePair;
            if(!Equals(keyToBeRemoved, keyInitial)) Edges.Remove(keyToBeRemoved);

            keyToBeRemoved = keyInitial;
            foreach (var keyValuePair in Edges.Where(keyValuePair => keyValuePair.Key == vertex2.Id && keyValuePair.Value == vertex1.Id)) keyToBeRemoved = keyValuePair;
            if (!Equals(keyToBeRemoved, keyInitial)) Edges.Remove(keyToBeRemoved);

            vertex1.EdgesList.Remove(vertex2);
            vertex2.EdgesList.Remove(vertex1);
        }

        public void ContractVertices(Vertex vertex1, Vertex vertex2)
        {
            var verticesToBeRemoved = new List<Vertex>();

            foreach (var edge in vertex2.EdgesList)
            {
                if (edge.Id != vertex1.Id)
                {
                    AddEdge(vertex1, edge);
                }
                verticesToBeRemoved.Add(edge);
            }
            foreach (var vertex in verticesToBeRemoved)
            {
                RemoveEdge(vertex2, vertex);
            } 
            RemoveVertex(vertex2);
        }

        public object Clone()
        {
            var newGraph = new Graph();
            foreach (var vertex in Vertices)
            {
                newGraph.AddVertex(new Vertex(vertex.Id));
            }
            foreach (var keyValuePair in Edges)
            {
                newGraph.AddEdge(newGraph.ReturnVortex(keyValuePair.Key), newGraph.ReturnVortex(keyValuePair.Value));
            }
            return newGraph;
        }
    }
}