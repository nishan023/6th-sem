using System;

namespace LAB
{
    // Base class
    class Animal
    {
        // Virtual method
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    // Derived class 1
    class Dog : Animal
    {
        // Override the virtual method
        public override void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    // Derived class 2
    class Cat : Animal
    {
        // Override the virtual method
        public override void MakeSound()
        {
            Console.WriteLine("Cat meows");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal = new Animal();
            Animal myDog = new Dog();
            Animal myCat = new Cat();

            Console.WriteLine("--- Polymorphism using Virtual Methods ---");
            myAnimal.MakeSound(); // Calls base class method
            myDog.MakeSound();    // Calls derived class method
            myCat.MakeSound();    // Calls derived class method

            Console.ReadLine();
        }
    }
}
