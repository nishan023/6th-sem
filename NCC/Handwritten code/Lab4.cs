using System;

namespace LAB
{
    class StudentNames
    {
        private string[] names = new string[5];  // Fixed size array

        // Indexer
        public string this[int index]
        {
            get { return names[index]; }
            set { names[index] = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentNames students = new StudentNames();

            // Store names using indexer
            students[0] = "Nishan";
            students[1] = "Amit";
            students[2] = "Subham";
            students[3] = "Rajesh";
            students[4] = "Rajkumar";

            Console.WriteLine("--- Student Names ---");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Student {i + 1}: {students[i]}");
            }

            Console.ReadLine(); // Keep console open
        }
    }
}
