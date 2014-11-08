using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomizedContraction
{
    public class Graph : ICloneable
    {
        public List<int> Vertices;
        public List<KeyValuePair<int, int>> Edges; 

        public int NumberOfVertices
        {
            get { return Vertices.Count; }
        }

        public Graph()
        {
            Vertices = new List<int>();
            Edges = new List<KeyValuePair<int, int>>();
        }

        public int ReturnVortex(int id)
        {
            return Vertices.FirstOrDefault(vertex => vertex == id);
        }

        public void AddVertex(int vertex)
        {
            Vertices.Add(vertex);
        }

        public void RemoveVertex(int vertex)
        {
            Vertices.Remove(ReturnVortex(vertex));
        }

        public void AddEdge(int vertex1, int vertex2)
        {
            Edges.Add(new KeyValuePair<int, int>(vertex1, vertex2));
        }

        public void ContractVertices(int vertex1, int vertex2)
        {
            var verticesToBeAdded = new List<KeyValuePair<int,int>>();
            var verticesToBeRemoved = new List<KeyValuePair<int, int>>();

            foreach (var keyValuePair in Edges)
            {
                if (keyValuePair.Key == vertex2 && keyValuePair.Value != vertex1)
                {
                    verticesToBeAdded.Add(new KeyValuePair<int, int>(vertex1, keyValuePair.Value));
                }
                if (keyValuePair.Value == vertex2 && keyValuePair.Key != vertex1)
                {
                    verticesToBeAdded.Add(new KeyValuePair<int, int>(keyValuePair.Key, vertex1));
                }
                if ((keyValuePair.Key == vertex2 || keyValuePair.Value == vertex2 ) || keyValuePair.Key == keyValuePair.Value)
                {
                    verticesToBeRemoved.Add(keyValuePair);
                }
            }

            foreach (var pair in verticesToBeRemoved)
            {
                Edges.Remove(pair);
            }
            foreach (var vertex in verticesToBeAdded)
            {
                AddEdge(vertex.Key, vertex.Value);
            }

            RemoveVertex(vertex2);
        }

        public object Clone()
        {
            var newGraph = new Graph();
            foreach (var vertex in Vertices)
            {
                newGraph.AddVertex(vertex);
            }
            foreach (var keyValuePair in Edges)
            {
                newGraph.AddEdge(newGraph.ReturnVortex(keyValuePair.Key), newGraph.ReturnVortex(keyValuePair.Value));
            }
            return newGraph;
        }
    }
}