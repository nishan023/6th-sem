using System;

namespace StudentApp
{
    class Student
    {
        // Automatic properties
        public int StudentId { get; set; }
        public required string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create and initialize student object
            Student s1 = new Student
            {
                StudentId = 101,
                Name = "Nishan"
            };

            // Display student details
            Console.WriteLine("--- Student Details ---");
            Console.WriteLine("Student ID : " + s1.StudentId);
            Console.WriteLine("Name       : " + s1.Name);

            Console.ReadLine(); 
        }
    }
}
