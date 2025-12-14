using System;

namespace LAB
{
    // Interface for arithmetic operations
    interface ICalculator
    {
        int Add(int a, int b);
        int Subtract(int a, int b);
        int Multiply(int a, int b);
        int Divide(int a, int b);
    }

    // Class implementing the interface
    class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Division by zero is not allowed!");
                return 0;
            }
            return a / b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ICalculator calc = new Calculator();

            int num1 = 20;
            int num2 = 4;

            Console.WriteLine("--- Calculator using Interface ---");
            Console.WriteLine($"{num1} + {num2} = {calc.Add(num1, num2)}");
            Console.WriteLine($"{num1} - {num2} = {calc.Subtract(num1, num2)}");
            Console.WriteLine($"{num1} * {num2} = {calc.Multiply(num1, num2)}");
            Console.WriteLine($"{num1} / {num2} = {calc.Divide(num1, num2)}");

            Console.ReadLine();
        }
    }
}
