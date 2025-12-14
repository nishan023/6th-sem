using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Process started...");

        // Call the long process asynchronously
        await LongProcess();

        Console.WriteLine("Process finished!");
        Console.ReadLine();
    }

    // Simulating a long process
    static async Task LongProcess()
    {
        Console.WriteLine("Long process is running...");
        await Task.Delay(5000); // 5 seconds delay (simulates long operation)
        Console.WriteLine("Long process completed.");
    }
   
}
