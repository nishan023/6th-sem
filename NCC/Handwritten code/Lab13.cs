using System;
using System.IO;

namespace LAB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Drive Information ---");

            // Get all drives on the system
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                // Only check drives that are ready
                if (drive.IsReady)
                {
                    Console.WriteLine($"Drive: {drive.Name}");
                    Console.WriteLine($"Total Size: {drive.TotalSize / (1024 * 1024 * 1024)} GB");
                    Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
                    Console.WriteLine("--------------------------");
                }
            }

            Console.ReadLine();
        }
    }
}
