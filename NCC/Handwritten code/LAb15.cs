using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Array of names
        string[] names = { "Ram", "Shyam", "Hari", "Bikash", "Mahesh" };

        // Sorting using LINQ
        var sortedNames = from name in names
                          orderby name
                          select name;

        Console.WriteLine("Sorted Names:");
        foreach (var name in sortedNames)
        {
            Console.WriteLine(name);
            
        }
        Console.ReadKey();
    }
}
