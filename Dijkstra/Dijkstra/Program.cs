using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        private static Dictionary<int, List<KeyValuePair<int,int>>> _graph;

        static void Main()
        {
            _graph = BuiltGraph();

            Console.ReadKey();
        }

        private static Dictionary<int, List<KeyValuePair<int, int>>> BuiltGraph()
        {
            var graph = new Dictionary<int, List<KeyValuePair<int, int>>>();
            string line;
            var verticesList = new List<string[]>();
            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("dijkstraData.txt");
            while ((line = file.ReadLine()) != null) verticesList.Add(line.Split('\t'));
            foreach (var edge in verticesList)
            {
                var vertexId = Convert.ToInt32(edge[0]);
                if (!graph.ContainsKey(vertexId)) graph.Add(vertexId, new List<KeyValuePair<int, int>>());

                for (var i = 1; i < edge.Length; i++)
                {
                    if(edge[i] == "") continue;
                    var pair = edge[i].Split(',');
                    graph[vertexId].Add(new KeyValuePair<int, int>(Convert.ToInt32(pair[0]), Convert.ToInt32(pair[1])));

                    if(!graph.ContainsKey(Convert.ToInt32(pair[0]))) graph.Add(Convert.ToInt32(pair[0]), new List<KeyValuePair<int,int>>());
                }
            }
            return graph;
        }
    }
}
