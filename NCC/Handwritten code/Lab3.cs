using System;

namespace LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Original array
            int[] arr = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Original Array:");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }

            // Reverse the array
            Array.Reverse(arr);

            Console.WriteLine("\n\nReversed Array:");
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine(); // keep console open
        }
    }
}
