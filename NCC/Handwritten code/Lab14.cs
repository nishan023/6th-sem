using System;
using System.IO;

namespace LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "sample.txt";
            string movedFilePath = "moved_sample.txt";

            // --------- Create and Write to File ---------
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Hello, this is a sample file.\n");
                File.AppendAllText(filePath, "Adding another line.\n");
                Console.WriteLine("File created and written successfully.");
            }

            // --------- Read File ---------
            Console.WriteLine("\n--- Reading File ---");
            string content = File.ReadAllText(filePath);
            Console.WriteLine(content);

            // --------- Move File ---------
            if (File.Exists(filePath))
            {
                File.Move(filePath, movedFilePath);
                Console.WriteLine($"File moved to {movedFilePath}");
            }

            // --------- Delete File ---------
            if (File.Exists(movedFilePath))
            {
                File.Delete(movedFilePath);
                Console.WriteLine("File deleted successfully.");
            }

            Console.ReadLine();
        }
    }
}
