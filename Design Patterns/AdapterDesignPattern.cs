using System;

namespace AdapterPattern
{
    //Random interface 1
    public interface IAnimal
    {
        void makeSound();
    }

    //Random interface 2
    public interface IVehicle
    {
        void throttle();
    }

    //Random implementation of the first interface
    public class Dog : IAnimal
    {
        public void makeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    //Another random implementation of the first interface
    public class Cat : IAnimal
    {
        public void makeSound()
        {
            Console.WriteLine("Meow!");
        }
    }

    //Random implementation of the second interface
    public class Car : IVehicle
    {
        public void throttle()
        {
            Console.WriteLine("Vroom!");
        }
    }

    //The Adapter that makes types of the second interface compatabile with types of the first one
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
