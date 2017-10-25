using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
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
