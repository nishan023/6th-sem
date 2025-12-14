using System;
using System.Collections.Generic;

namespace LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a dictionary to store CustomerId and CustomerName
            Dictionary<int, string> customers = new Dictionary<int, string>();

            // Add some customers
            customers.Add(101, "Nishan");
            customers.Add(102, "Rajan");
            customers.Add(103, "Suresh");
            customers.Add(104, "Rajesh");

            Console.WriteLine("--- Customer Details ---");
            foreach (KeyValuePair<int, string> customer in customers)
            {
                Console.WriteLine($"CustomerId: {customer.Key}, CustomerName: {customer.Value}");
            }

            Console.ReadLine();
        }
    }
}
