using System;
using System.Collections.Generic;

namespace DnC_QuickSort
{
    class Program
    {
        //static Random rand = new Random();

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

            var result = QuickSort(array, 0, array.Length - 1);

            Console.WriteLine(result + " counted in: " + (DateTime.Now.Millisecond - time) + " ms");
            Console.ReadKey();
        }

        static Int64 QuickSort(int[] arrayInts, int startPointer, int stopPointer)
        {
            if (stopPointer <= startPointer) return 0;

            /*var pivot = rand.Next(startPointer, stopPointer); */
            var pivot = Median(arrayInts, startPointer, stopPointer);

            var splitPoint = Partition(arrayInts, pivot, startPointer, stopPointer);

            var numberOfComparisons = stopPointer - startPointer;

            var x = QuickSort(arrayInts, startPointer, splitPoint - 1);
            var y = QuickSort(arrayInts, splitPoint + 1, stopPointer);

            return numberOfComparisons + x + y;
        }

        static int Partition(int[] arrayInts, int pivotIndex, int startPointer, int stopPointer)
        {
            if (stopPointer <= startPointer) return 0;

            Swap(arrayInts, startPointer, pivotIndex);

            var i = startPointer + 1;

            for (var j = i; j <= stopPointer; j++)
            {
                if (arrayInts[j] >= arrayInts[startPointer]) continue;
                Swap(arrayInts, j, i);
                i++;
            }

            Swap(arrayInts, startPointer, i - 1);
            return i - 1;
        }

        static void Swap(int[] arrayInts, int index1, int index2)
        {
            var storageInt = arrayInts[index1];
            arrayInts[index1] = arrayInts[index2];
            arrayInts[index2] = storageInt;
        }

        static int Median(int[] arrayInts, int startPointer, int stopPointer)
        {
            var array = new int[3];
            var middlePointer = (int)Math.Floor((double)(stopPointer + startPointer) / 2);

            array[0] = arrayInts[startPointer];
            array[1] = arrayInts[middlePointer];
            array[2] = arrayInts[stopPointer];

            if (array[1] < array[0]) Swap(array, 0, 1); 
            if (array[2] < array[1]) Swap(array, 1, 2);
            if (array[1] < array[0]) Swap(array, 0, 1);

            if (array[1] == arrayInts[startPointer]) return startPointer;
            if (array[1] == arrayInts[middlePointer]) return middlePointer;
            return stopPointer;
        }
    }
}
