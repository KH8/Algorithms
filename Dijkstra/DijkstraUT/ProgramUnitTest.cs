using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DijkstraUT
{
    [TestClass]
    public class ProgramUnitTest
    {
        public string ToAssertableString(IDictionary<int, List<KeyValuePair<int, int>>> dictionary)
        {
            var pairStrings = dictionary.OrderBy(p => p.Key)
                .Select(p => p.Key + ": " + string.Join(", ", p.Value));
            return string.Join("; ", pairStrings);
        }

        [TestMethod]
        public void BuiltGraphUt()
        {
            var expected = new Dictionary<int, List<KeyValuePair<int, int>>>
            {
                {
                    1, new List<KeyValuePair<int, int>>
                    {new KeyValuePair<int, int>(2, 1)}
                },
                {
                    2, new List<KeyValuePair<int, int>>
                    {new KeyValuePair<int, int>(3, 2)}
                },
                {
                    3, new List<KeyValuePair<int, int>>
                    {new KeyValuePair<int, int>(4, 3)}
                },
                {
                    4, new List<KeyValuePair<int, int>>
                    {new KeyValuePair<int, int>(1, 4)}
                }
            };

            var actual = Dijkstra.Program.BuiltGraph("dijkstraDataUT.txt");

            Assert.AreEqual(ToAssertableString(expected), ToAssertableString(actual));
        }
    }
}
