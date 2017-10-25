using System;

namespace FactoryMethod
{    
    public interface IAnimal
    {
        void makeSound();
    }

    public class Dog : IAnimal
    {
        public void makeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class Cat : IAnimal
    {
        public void makeSound()
        {
            Console.WriteLine("Meow!");
        }
    }

    public abstract class AnimalFactory
    {
        public abstract IAnimal Create();
    }

    public class DogFactory : AnimalFactory
    {
        public override IAnimal Create()
        {
            return new Dog();
        }
    }

    public class CatFactory : AnimalFactory
    {
        public override IAnimal Create()
        {
            return new Cat();
        }
    }
}
