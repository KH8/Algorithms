using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizedContraction
{
    class Program
    {
        static void Main()
        {
            var graph = BuiltGraph();

            Console.WriteLine("A minCut found is: " + RandomizedContraction(graph, graph.NumberOfVertices^2));
            Console.ReadKey();
        }

        private static int RandomizedContraction(Graph graph)
        {
            while (true)
            {
                if (graph.NumberOfVertices <= 2) return graph.Edges.Count;

                var vertexSelected = graph.Edges.PickRandom();
                graph.ContractVertices(vertexSelected.Key, vertexSelected.Value);
            }
        }

        private static int RandomizedContraction(Graph graph, int numberOfRepetitions)
        {
            var minCut = 999999;

            for (var i = 0; i < numberOfRepetitions; i++)
            {
                var newGraph = (Graph)graph.Clone();
                var actualCut = RandomizedContraction(newGraph);
                if (actualCut < minCut) minCut = actualCut;

                Console.WriteLine(i + " : " + minCut);
            }

            return minCut;
        }

        private static Graph BuiltGraph()
        {
            var graph = new Graph();

            string line;

            var verticesList = new List<string[]>();

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("kargerMinCut.txt");

            while ((line = file.ReadLine()) != null) verticesList.Add(line.Split('\t'));
            foreach (var stringse in verticesList) graph.AddVertex(Convert.ToInt16(stringse[0]));

            foreach (var stringse in verticesList)
            {
                for (var i = 1; i < stringse.Length; i++)
                {
                    if (stringse[i] == "x" || stringse[i].Trim().Length == 0) continue;

                    var actualVortexId = Convert.ToInt32(stringse[0]);
                    var actualEdgeId = Convert.ToInt32(stringse[i]);

                    graph.AddEdge(graph.ReturnVortex(actualVortexId), graph.ReturnVortex(actualEdgeId));

                    for (var j = 1; j < verticesList[actualEdgeId - 1].Length; j++)
                    {
                        if (verticesList[actualEdgeId - 1][j] != stringse[0]) continue;
                        verticesList[actualEdgeId - 1][j] = "x";
                        break;
                    }
                }
            }

            return graph;
        }
    }
}
