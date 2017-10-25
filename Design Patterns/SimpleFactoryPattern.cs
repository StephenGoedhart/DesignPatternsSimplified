using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
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
