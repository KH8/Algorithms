using System;
using System.Collections.Generic;

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

            //var numberOfInversions = SortAndCount(array, out array);

            //Console.WriteLine(numberOfInversions + " counted in: " + (DateTime.Now.Millisecond - time) + " ms");
            Console.ReadKey();
        }
    }
}
