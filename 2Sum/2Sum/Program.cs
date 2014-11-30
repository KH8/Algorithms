using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2Sum
{
    class Program
    {
        public static int Counter;

        static void Main()
        {
            var hashSet = BuiltHashSet("2sum.txt");

            CheckRange(hashSet, 10000, 10000);
            Parallel.For(-10, 11, i => CheckRange(hashSet, i*1000, i*1000 + 999));

            Console.WriteLine("The result of computation is: " + Counter);
            Console.ReadKey();
        }

        public static void CheckRange(HashSet<Int64> hashSet, int start, int stop)
        {
            for (Int64 i = start; i <= stop; i++)
            {
                foreach (var l in hashSet)
                {
                    var valueToLookUp = i - l;
                    if (l == valueToLookUp) continue;
                    if (!hashSet.Contains(valueToLookUp)) continue;
                    Counter++;
                    Console.WriteLine(i + " = " + l + " + " + valueToLookUp + " : " + Counter);
                    break;
                }
            }
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
        public static HashSet<Int64> BuiltHashSet(string fileName)
        {
            var newHashSet = new HashSet<Int64>();

            string line;

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                var newValue = Convert.ToInt64(line);
                if (!newHashSet.Contains(newValue)) newHashSet.Add(newValue);
            }
            return newHashSet;
        }
    }
}
