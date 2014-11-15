using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCCs
{
    class Program
    {
        static void Main()
        {
            var graph = BuiltGraph();

        }

        private static Collection<Vertex> BuiltGraph()
        {
            var graph = new Collection<Vertex>();

            string line;

            var verticesList = new List<string[]>();

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("SCC.txt");

            while ((line = file.ReadLine()) != null) verticesList.Add(line.Split(' '));

            var lastVertex = new Vertex(0);

            foreach (var edge in verticesList)
            {
                var vertexId = Convert.ToInt32(edge[0]);
                var edgeId = Convert.ToInt32(edge[1]);

                if (vertexId == lastVertex.Id)
                {
                    lastVertex.Edges.Add(edgeId);
                    continue;
                }

                lastVertex = new Vertex(vertexId);
                lastVertex.Edges.Add(edgeId);
                graph.Add(lastVertex);
            }

            return graph;
        }
    }
}
