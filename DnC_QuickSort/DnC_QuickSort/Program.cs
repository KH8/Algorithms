using System;
using System.Collections.Generic;
using System.Globalization;

namespace DnC_QuickSort
{
    class Program
    {
        static void Main()
        {
            string line;
            var counter = 0;

            var list = new Dictionary<int, string>();

            // Read the file and display it line by line.
            var file = new System.IO.StreamReader("QuickSort.txt");
            while ((line = file.ReadLine()) != null)
            {
                list.Add(counter, line);
                counter++;
            }

            file.Close();

            var array = new int[counter];
            foreach (var variable in list) array[variable.Key] = Convert.ToInt32(variable.Value);

            var time = DateTime.Now.Millisecond;

            QuickSort(array, 0, array.Length - 1);
            //var numberOfInversions = SortAndCount(array, out array);

            //Console.WriteLine(numberOfInversions + " counted in: " + (DateTime.Now.Millisecond - time) + " ms");
            Console.ReadKey();
        }

        static void QuickSort(int[] arrayInts, int startPointer, int stopPointer)
        {
            if (stopPointer <= startPointer) return;

            var pivot = 0;
            var splitPoint = Partition(arrayInts, pivot, startPointer, stopPointer);

            QuickSort(arrayInts, startPointer, splitPoint - 1);
            QuickSort(arrayInts, splitPoint + 1, stopPointer);
        }

        static int Partition(int[] arrayInts, int pivotIndex, int startPointer, int stopPointer)
        {
            if (stopPointer <= startPointer) return 0;

            Swap(arrayInts, startPointer, pivotIndex);

            var i = startPointer + 1;

            for (var j = i; j <= stopPointer; j++)
            {
                if (arrayInts[j] < arrayInts[startPointer])
                {
                    Swap(arrayInts, j, i);
                    i++;
                }
            }

            Swap(arrayInts, 0, i-1);
            return i - 1;
        }

        static void Swap(int[] array, int index1, int index2)
        {
            var storageInt = array[index1];
            array[index1] = array[index2];
            array[index2] = storageInt;
        }
    }
}
