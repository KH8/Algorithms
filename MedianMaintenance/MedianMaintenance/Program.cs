using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianMaintenance
{
    class Program
    {
        static void Main()
        {
            Int64 sumOfMedians = 0;

            var lowSet = new SortedSet<Int32>();
            var highSet = new SortedSet<Int32>();

            string line;

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("Median.txt");
            while ((line = file.ReadLine()) != null)
            {
                var newValue = Convert.ToInt32(line);

                if (newValue < lowSet.Max || lowSet.Count == 0)
                {
                    lowSet.Add(newValue);
                }
                else
                {
                    highSet.Add(newValue);
                }

                if (lowSet.Count < highSet.Count)
                {
                    lowSet.Add(highSet.Min);
                    highSet.Remove(highSet.Min);
                }

                if (Math.Abs(lowSet.Count - highSet.Count) > 1)
                {
                    if (lowSet.Count > highSet.Count)
                    {
                        highSet.Add(lowSet.Max);
                        lowSet.Remove(lowSet.Max);
                    }
                    else
                    {
                        lowSet.Add(highSet.Min);
                        highSet.Remove(highSet.Min);
                    }
                }

                sumOfMedians += lowSet.Max;
            }

            Console.WriteLine(sumOfMedians);
            Console.ReadKey();
        }

        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
    }
}
