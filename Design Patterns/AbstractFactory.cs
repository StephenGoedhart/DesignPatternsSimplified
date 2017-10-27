using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface IAnimal
    {
        void makeSound();
    }

    public interface IClothing
    {
        void printDescription();
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

    public class Hat : IClothing
    {
        public void printDescription()
        {
            Console.WriteLine("A brightly colored party hat!");
        }
    }

    public class Pants : IClothing
    {
        public void printDescription()
        {
            Console.WriteLine("Denim based pants!");
        }
    }

    public abstract class AbstractFactory
    {
        public abstract IAnimal getAnimal(string animal);
        public abstract IClothing getClothing(string clothing);
    }

    public class AnimalFactory : AbstractFactory
    {
        public override IAnimal getAnimal(string animal)
        {
            if (animal == "cat")
                return new Cat();
            if (animal == "dog")
                return new Dog();
            return null;
        }

        public override IClothing getClothing(string clothing)
        {
            return null;
        }
    }

    public class ClothingFactory : AbstractFactory
    {
        public override IAnimal getAnimal(string animal)
        {
            return null;
        }

        public override IClothing getClothing(string clothing)
        {
            if (clothing == "hat")
                return new Hat();
            if (clothing == "pants")
                return new Pants();
            return null;
        }
    }

    public class FactoryFactory
    {
        public static AbstractFactory Create(string factory)
        {
            if (factory == "animal")
                return new AnimalFactory();
            if (factory == "clothing")
                return new ClothingFactory();
            return null;
        }
    }


}
