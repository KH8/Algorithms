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

            graph.AddEdge(graph.ReturnVortex(1),graph.ReturnVortex(2));
            graph.AddEdge(graph.ReturnVortex(2), graph.ReturnVortex(3));
            graph.AddEdge(graph.ReturnVortex(3), graph.ReturnVortex(4));
            graph.AddEdge(graph.ReturnVortex(1), graph.ReturnVortex(4));
            graph.AddEdge(graph.ReturnVortex(1), graph.ReturnVortex(4));
            graph.AddEdge(graph.ReturnVortex(2), graph.ReturnVortex(4));

            graph.ContractVertices(graph.ReturnVortex(1), graph.ReturnVortex(4));

            Console.ReadKey();
        }
    }
}
