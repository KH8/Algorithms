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
            var graph = new Graph();

            graph.AddVertex(new Vertex(1));
            graph.AddVertex(new Vertex(2));
            graph.AddVertex(new Vertex(3));
            graph.AddVertex(new Vertex(4));
            graph.AddVertex(new Vertex(5));

            graph.AddEdge(graph.ReturnVortex(1),graph.ReturnVortex(2));
            graph.AddEdge(graph.ReturnVortex(2), graph.ReturnVortex(3));
            graph.AddEdge(graph.ReturnVortex(3), graph.ReturnVortex(4));
            graph.AddEdge(graph.ReturnVortex(1), graph.ReturnVortex(4));
            graph.AddEdge(graph.ReturnVortex(1), graph.ReturnVortex(4));
            graph.AddEdge(graph.ReturnVortex(2), graph.ReturnVortex(4));
            graph.AddEdge(graph.ReturnVortex(3), graph.ReturnVortex(5));
            graph.AddEdge(graph.ReturnVortex(3), graph.ReturnVortex(5));
            graph.AddEdge(graph.ReturnVortex(3), graph.ReturnVortex(5));

            Console.WriteLine("A minCut found is: " + RandomizedContraction(graph, graph.NumberOfVertices^2));
            Console.ReadKey();
        }

        private static int RandomizedContraction(Graph graph)
        {
            while (true)
            {
                if (graph.NumberOfVertices <= 2) return graph.Vertices.PickRandom().NunberOfedges;

                var vertexSelected = graph.Vertices.PickRandom();
                graph.ContractVertices(vertexSelected, vertexSelected.EdgesList.PickRandom());
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
            }

            return minCut;
        }
    }
}
