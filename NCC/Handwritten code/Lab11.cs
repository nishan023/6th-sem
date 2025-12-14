using System;
using System.Collections.Generic;

namespace LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a generic list of integers
            List<int> numbers = new List<int>();

            // Add numbers 1 to 10
            for (int i = 1; i <= 10; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine("--- Numbers from 1 to 10 ---");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }

            Console.ReadLine();
        }
    }
}
