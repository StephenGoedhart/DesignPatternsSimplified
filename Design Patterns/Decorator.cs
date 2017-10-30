using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorDesignPattern
{
    //Random abstract class
    public abstract class Animal
    {
       public abstract void makeSound();
    }
    
    //This is a concrete implementation
    public class Cat : Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("Meow!");
        }
    }

    public class AnimalDecorator : Animal
    {
        public override void makeSound()
        {
            //i WANNA DO SOMETHING ELSE WHEN I CALL THIS
            throw new NotImplementedException();
        }
    }

    public class ConcreteAnimalDecorator : Animal
    {
        public override void makeSound()
        {
            Console.WriteLine("Added behavior?");
        }
    }

    //TO DO

    



}
