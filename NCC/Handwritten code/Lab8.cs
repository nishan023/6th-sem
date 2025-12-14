using System;

namespace LAB
{
    // Define a delegate that takes two integers and returns an integer
    delegate int AddDelegate(int a, int b);

    internal class Program
    {
        // Method to add two numbers
        static int AddNumbers(int x, int y)
        {
            return x + y;
        }

        static void Main(string[] args)
        {
            // Create a delegate instance and point it to AddNumbers
            AddDelegate del = new AddDelegate(AddNumbers);

            int num1 = 10;
            int num2 = 20;

            // Invoke the delegate
            int result = del(num1, num2);

            Console.WriteLine($"The sum of {num1} and {num2} is: {result}");

            Console.ReadLine();
        }
    }
}
