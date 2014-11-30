using System.Collections.Generic;

namespace _2Sum
{
    class Program
    {
        static void Main()
        {
        }

        /// <summary>
        /// Dictionary builder.
        /// </summary>
        /// <param name="fileName"> Path to the source *.txt file.
        /// </param>
        /// <seealso cref="System.String">
        /// You can use the cref attribute on any tag to reference a type or member
        /// and the compiler will check that the reference exists.
        /// </seealso>
        public static Dictionary<int, int> BuiltGraph(string fileName)
        {
            var graph = new Dictionary<int, int>();
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
