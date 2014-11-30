using System;
using System.Collections.Generic;
using System.Linq;

namespace _2Sum
{
    class Program
    {
        static void Main()
        {
            var hashSet = BuiltHashSet("2sum.txt");
            var counter = 0;

            for (Int64 i = -10000; i <= 10000; i++)
            {
                foreach (var l in hashSet)
                {
                    var valueToLookUp = i - l;
                    if (l == valueToLookUp) continue;
                    if (!hashSet.Contains(valueToLookUp)) continue;
                    counter++;
                    break;
                }
                Console.WriteLine(i + " : " + counter);
            }

            Console.WriteLine("The result of computation is: " + counter);
            Console.ReadKey();
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
