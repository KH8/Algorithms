using System;
using System.Collections.Generic;

namespace DnC_Inversions
{
    class Program
    {
        static void Main()
        {
            string line;
            var counter = 0;

            var list = new Dictionary<int, string>();

            // Read the file and display it line by line.
            var file =
               new System.IO.StreamReader("IntegerArray.txt");
            while ((line = file.ReadLine()) != null)
            {
                list.Add(counter, line);
                counter++;
            }

            file.Close();

            var array = new int[counter];
            foreach (var variable in list) array[variable.Key] = Convert.ToInt32(variable.Value);

            var numberOfInversions = SortAndCount(array, out array);

            Console.WriteLine(numberOfInversions);
            Console.ReadKey();
        }

        static int SortAndCount(int[] arrayInts, out int[] newArrayInts)
        {
            if (arrayInts.Length <= 1)
            {
                newArrayInts = arrayInts;
                return 0;
            }

            var splitArrayInts = Split(arrayInts);

            var x = SortAndCount(splitArrayInts[0], out splitArrayInts[0]);
            var y = SortAndCount(splitArrayInts[1], out splitArrayInts[1]);

            var z = SplitCount(splitArrayInts[0], splitArrayInts[1], out arrayInts);

            newArrayInts = arrayInts;
            return x + y + z;
        }

        static int SplitCount(int[] leftArrayInts, int[] rightArrayInts, out int[] arrayInts)
        {
            var result = 0;
            var length = leftArrayInts.Length + rightArrayInts.Length;

            arrayInts = new int[length];

            var i = 0;
            var j = 0;

            for (var k = 0; k < length; k++)
            {
                if (i >= leftArrayInts.Length)
                {
                    arrayInts[k] = rightArrayInts[j];
                    j++;
                    continue;
                }
                if (j >= rightArrayInts.Length)
                {
                    arrayInts[k] = leftArrayInts[i];
                    i++;
                    continue;
                }
                if (leftArrayInts[i] < rightArrayInts[j])
                {
                    arrayInts[k] = leftArrayInts[i];
                    i++;
                }
                else
                {
                    arrayInts[k] = rightArrayInts[j];
                    result += leftArrayInts.Length - i;
                    j++;
                }
            }

            return result;
        }

        static int[][] Split(int[] arrayInts)
        {
            var outputArray = new int[2][];

            var length = (int)Math.Ceiling(arrayInts.Length / 2.0);
            outputArray[0] = new int[length];
            outputArray[1] = new int[arrayInts.Length - length];

            for (var i = 0; i < length; i++)
            {
                outputArray[0][i] = arrayInts[i];
            }
            for (var i = length; i < arrayInts.Length; i++)
            {
                outputArray[1][i - length] = arrayInts[i];
            }

            return outputArray;
        }
    }
}
