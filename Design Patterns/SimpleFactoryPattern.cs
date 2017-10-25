using System;

namespace SimpleFactory
{
    public class Dog
    {
        public Dog()
        {
            Console.WriteLine("Created Dog");
        }
    }
    public class Cat
    {
        public Cat()
        {
            Console.WriteLine("Created Cat");
        }
    }
    public class AnimalFactory
    {
        public Dog createDog()
        {
            return new Dog();
        }
        public Cat createCat()
        {
            return new Cat();
        }
    }
}
