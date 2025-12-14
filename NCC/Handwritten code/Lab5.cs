using System;

namespace LAB
{
    // --------- Single Inheritance ---------
    class Person
    {
        public void ShowPerson()
        {
            Console.WriteLine("I am a Person");
        }
    }

    class Student : Person  // Single Inheritance (Student inherits Person)
    {
        public void ShowStudent()
        {
            Console.WriteLine("I am a Student");
        }
    }

    // --------- Multilevel Inheritance ---------
    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Animal eats food");
        }
    }

    class Mammal : Animal
    {
        public void Walk()
        {
            Console.WriteLine("Mammal walks");
        }
    }

    class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Dog barks");
        }
    }

    // --------- Hierarchical Inheritance ---------
    class Vehicle
    {
        public void Start()
        {
            Console.WriteLine("Vehicle started");
        }
    }

    class Car : Vehicle
    {
        public void Drive()
        {
            Console.WriteLine("Car is driving");
        }
    }

    class Bike : Vehicle
    {
        public void Ride()
        {
            Console.WriteLine("Bike is riding");
        }
    }

    // --------- Main Program ---------
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Single Inheritance ----");
            Student s = new Student();
            s.ShowPerson();
            s.ShowStudent();

            Console.WriteLine("\n---- Multilevel Inheritance ----");
            Dog d = new Dog();
            d.Eat();
            d.Walk();
            d.Bark();

            Console.WriteLine("\n---- Hierarchical Inheritance ----");
            Car c = new Car();
            Bike b = new Bike();
            c.Start();
            c.Drive();
            b.Start();
            b.Ride();

            Console.ReadLine();
        }
    }
}
