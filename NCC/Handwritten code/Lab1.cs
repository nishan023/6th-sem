
using System;

namespace AddTwoDigitsConstructor
{
    class Addition
    {
        int x, y;
        public Addition(int a, int b)
        {
            this.x = a;
            this.y = b;
        }
        public int Sum()
        {
            return x + y;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Addition obj = new Addition(10, 20);
            Console.WriteLine($"The sum is : {obj.Sum()}");
            Console.ReadLine();
        }
    }
}



