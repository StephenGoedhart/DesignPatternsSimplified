using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public interface IAnimal
    {
        void makeSound();
    }

    public interface IVehicle
    {
        void throttle();
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

    public class Car : IVehicle
    {
        public void throttle()
        {
            Console.WriteLine("Vroom!");
        }
    }

    public class AnimalVehicleAdapter : IAnimal
    {
        private IVehicle vehicle;
        public AnimalVehicleAdapter(IVehicle newVehicle)
        {
            vehicle = newVehicle;
        }
        public void makeSound()
        {
            vehicle.throttle();
        }
    }
}
