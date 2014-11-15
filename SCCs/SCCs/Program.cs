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
        static int _finishingTime = 0;
        static int _actualLeader = 0;
        private static Dictionary<int, int> _leaderCounter = new Dictionary<int, int>();  

        static void Main()
        {
            var graphReversed = BuiltGraph(true);
            DfsLoop(graphReversed);

            var graph = BuiltGraph(false);
            var graphWithFinishingTimes = graphReversed.ToDictionary(vertex => vertex.Value.FinishingTime, vertex => graph[vertex.Key]);

            _finishingTime = 0;
            _actualLeader = 0;

            DfsLoop(graph, graphWithFinishingTimes);

            foreach (var i in _leaderCounter)
            {
                Console.WriteLine("A vertex: " + i.Key + " is a leader of " + i.Value + " vertices");
            }
            Console.ReadKey();
        }

        static void DfsLoop(Dictionary<int, Vertex> graph)
        {
            for (var i = graph.Count; i > 0; i--)
            {
                if (!graph[i].IsExplored)
                {
                    _actualLeader = i;
                    DFS(graph, i);
                }
            }
        }

        static void DfsLoop(Dictionary<int, Vertex> graph, Dictionary<int, Vertex> graphWithFinishingTimes)
        {
            for (var i = graphWithFinishingTimes.Count; i > 0; i--)
            {
                if (!graphWithFinishingTimes[i].IsExplored)
                {
                    _actualLeader = graphWithFinishingTimes[i].Id;
                    _leaderCounter.Add(_actualLeader, 0);

                    DFS(graph, graphWithFinishingTimes[i].Id);
                }
            }
        }

        static void DFS(Dictionary<int, Vertex> graph, int node)
        {
            graph[node].IsExplored = true;
            graph[node].LeaderId = _actualLeader;
            if(_leaderCounter.ContainsKey(_actualLeader)) _leaderCounter[_actualLeader]++;

            foreach (var edge in graph[node].Edges)
            {
                if(!graph[edge].IsExplored) DFS(graph, edge);
            }

            _finishingTime++;
            graph[node].FinishingTime = _finishingTime;
        }

        private static Dictionary<int, Vertex> BuiltGraph(Boolean reversed)
        {
            var graph = new Dictionary<int, Vertex>();

            string line;

            var verticesList = new List<string[]>();

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("SCC.txt");

            while ((line = file.ReadLine()) != null) verticesList.Add(line.Split(' '));

            foreach (var edge in verticesList)
            {
                var vertexId = Convert.ToInt32(reversed ? edge[1] : edge[0]);
                var edgeId = Convert.ToInt32(reversed ? edge[0] : edge[1]);

                if (graph.ContainsKey(vertexId))
                {
                    graph[vertexId].Edges.Add(edgeId);
                    continue;
                }

                graph.Add(vertexId, new Vertex(vertexId));
                graph[vertexId].Edges.Add(edgeId);
            }

            return graph;
        }
    }
}
