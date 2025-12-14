using System;

namespace LAB
{
    // First interface for length
    interface ILength
    {
        double Length { get; set; }
    }

    // Second interface for width
    interface IWidth
    {
        double Width { get; set; }
    }

    // Class that inherits both interfaces
    class Rectangle : ILength, IWidth
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double GetArea()
        {
            return Length * Width;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle
            {
                Length = 5,
                Width = 10
            };

            Console.WriteLine($"Length: {rect.Length}");
            Console.WriteLine($"Width: {rect.Width}");
            Console.WriteLine($"Area of Rectangle: {rect.GetArea()}");

            Console.ReadLine();
        }
    }
}
