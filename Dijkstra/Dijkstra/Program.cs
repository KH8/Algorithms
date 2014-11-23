using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra
{
    /// <summary> 
    /// Main class of the program.</summary> 
    /// <remarks> 
    /// Class computes a shortest path problem in the graph, using the Dijkstra's algorythms.
    /// </remarks> 
    class Program
    {
        /// <summary> 
        /// Store for the given graph V.</summary> 
        private static Dictionary<int, List<KeyValuePair<int, int>>> _graphV;

        /// <summary> 
        /// Store for the working graph X.</summary> 
        private static readonly Dictionary<int, List<KeyValuePair<int, int>>> GraphX = new Dictionary<int, List<KeyValuePair<int, int>>>();

        /// <summary> 
        /// Store for the computed shortest paths.</summary> 
        private static readonly Dictionary<int, int> ShortestPaths = new Dictionary<int, int>();

        /// <summary> 
        /// Main and the only one method solvin a Dijkstra's shortest path problem</summary> 
        static void Main()
        {
            _graphV = BuiltGraph("dijkstraData.txt");

            foreach (var node in _graphV) ShortestPaths.Add(node.Key, 1000000);

            GraphX.Add(1, _graphV[1]);
            _graphV.Remove(1);
            ShortestPaths[1] = 0;

            while (_graphV.Count != 0)
            {
                var nodeSelectedId = 0;
                var distance = 1000000;

                foreach (var nodex in GraphX)
                {
                    foreach (var edge in nodex.Value.Where(edge => _graphV.ContainsKey(edge.Key)))
                    {
                        if (distance <= ShortestPaths[nodex.Key] + edge.Value) continue;
                        distance = ShortestPaths[nodex.Key] + edge.Value;
                        nodeSelectedId = edge.Key;
                    }
                }

                if(nodeSelectedId == 0) throw new Exception("Fuck!");

                GraphX.Add(nodeSelectedId, _graphV[nodeSelectedId]);
                _graphV.Remove(nodeSelectedId);
                ShortestPaths[nodeSelectedId] = distance;
            }

            Console.WriteLine(ShortestPaths[7]+
                ","+ ShortestPaths[37]+
                ","+ ShortestPaths[59]+
                ","+ ShortestPaths[82]+
                ","+ ShortestPaths[99]+
                ","+ ShortestPaths[115]+
                ","+ ShortestPaths[133]+
                ","+ ShortestPaths[165]+
                ","+ ShortestPaths[188]+
                ","+ ShortestPaths[197]);

            Console.ReadKey();
        }

        /// <summary> 
        /// Graph builder.
        /// </summary>
        /// <param name="fileName"> Path to the source *.txt file.
        /// </param>
        /// <seealso cref="System.String">
        /// You can use the cref attribute on any tag to reference a type or member  
        /// and the compiler will check that the reference exists. 
        /// </seealso>
        private static Dictionary<int, List<KeyValuePair<int, int>>> BuiltGraph(string fileName)
        {
            var graph = new Dictionary<int, List<KeyValuePair<int, int>>>();
            string line;
            var verticesList = new List<string[]>();
            // Read the file and display it line by line.
            var file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null) verticesList.Add(line.Split('\t'));
            foreach (var edge in verticesList)
            {
                var vertexId = Convert.ToInt32(edge[0]);
                if (!graph.ContainsKey(vertexId)) graph.Add(vertexId, new List<KeyValuePair<int, int>>());

                for (var i = 1; i < edge.Length; i++)
                {
                    var pair = edge[i].Split(',');

                    if (pair.Count() != 2) continue;
                    graph[vertexId].Add(new KeyValuePair<int, int>(Convert.ToInt32(pair[0]), Convert.ToInt32(pair[1])));
                    if (!graph.ContainsKey(Convert.ToInt32(pair[0]))) graph.Add(Convert.ToInt32(pair[0]), new List<KeyValuePair<int, int>>());
                }
            }
            return graph;
        }
    }
}
