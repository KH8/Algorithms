using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SCCs
{
    class Program
    {
        static int _finishingTime;
        static int _actualLeader;

        static int[] _finishingTimes;
        static int[] _exploration; 

        static readonly Dictionary<int, int> LeaderCounter = new Dictionary<int, int>(); 

        static void Main()
        {
            var T = new Thread(ThreadDelegate, 16000000);
            T.Start();
        }

        public static void ThreadDelegate()
        {
            var graph = BuiltGraph(true);
            _finishingTimes = new int[graph.Count + 1];
            _exploration = new int[graph.Count + 1];

            DfsLoop(graph);

            graph = BuiltGraph(false);

            _actualLeader = 0;
            _exploration = new int[graph.Count + 1];

            DfsLoop(graph, _finishingTimes);

            var sortedDict = from entry in LeaderCounter orderby entry.Value descending select entry;
            int[] counter = {0};

            foreach (var i in sortedDict.TakeWhile(i => counter[0] < 5))
            {
                Console.WriteLine("A vertex: " + i.Key + " is a leader of " + i.Value + " vertices");
                counter[0]++;
            }
            Console.ReadKey();
        }

        static void DfsLoop(Dictionary<int, List<int>> graph)
        {
            for (var i = graph.Count; i > 0; i--)
            {
                if (_exploration[i] != 0) continue;
                _actualLeader = i;
                Dfs(graph, i, true);
            }
        }

        static void DfsLoop(Dictionary<int, List<int>> graph, IList<int> finishingTimes)
        {
            for (var i = finishingTimes.Count - 1; i > 0; i--)
            {
                if (_exploration[finishingTimes[i]] == 1) continue;
                _actualLeader = finishingTimes[i];
                LeaderCounter.Add(_actualLeader, 0);

                Dfs(graph, finishingTimes[i], false);
            }
        }

        static void Dfs(Dictionary<int, List<int>> graph, int node, Boolean countTimes)
        {
            _exploration[node] = 1;
            if(LeaderCounter.ContainsKey(_actualLeader)) LeaderCounter[_actualLeader]++;

            foreach (var edge in graph[node].Where(edge => _exploration[edge] != 1))
            {
                Dfs(graph, edge, countTimes);
            }

            if (!countTimes) return;
            _finishingTime++;
            _finishingTimes[_finishingTime] = node;
        }

        private static Dictionary<int, List<int>> BuiltGraph(Boolean reversed)
        {
            var graph = new Dictionary<int, List<int>>();

            string line;

            var verticesList = new List<string[]>();

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("SCC.txt");

            while ((line = file.ReadLine()) != null) verticesList.Add(line.Split(' '));

            foreach (var edge in verticesList)
            {
                var vertexId = Convert.ToInt32(reversed ? edge[1] : edge[0]);
                var edgeId = Convert.ToInt32(reversed ? edge[0] : edge[1]);

                if (!graph.ContainsKey(vertexId))
                {
                    graph.Add(vertexId, new List<int>());
                }
                if (!graph.ContainsKey(edgeId))
                {
                    graph.Add(edgeId, new List<int>());
                }

                graph[vertexId].Add(edgeId);
            }

            return graph;
        }
    }
}
