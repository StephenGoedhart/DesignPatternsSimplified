using System;
using System.Collections.Generic;
using SF = SimpleFactory;
using FM = FactoryMethod;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("//------------------- Simple Factory Pattern ----------------------//");
            //Declare simple factory.
            SF.AnimalFactory animalFactory = new SF.AnimalFactory();

            //Use factory to create objects.
            SF.Dog sfDog = animalFactory.createDog();
            SF.Cat sfCat = animalFactory.createCat();

            Console.WriteLine("//------------------- Factory Method Pattern ----------------------//");
            //Define factories with overridden factory methods.
            FM.CatFactory catFactory = new FM.CatFactory();
            FM.DogFactory dogFactory = new FM.DogFactory();

            //Use factories to define objects based on the same type. 
            FM.IAnimal fmDog = dogFactory.Create();
            FM.IAnimal fmCat = catFactory.Create();

            fmDog.makeSound();
            fmCat.makeSound();

            Console.WriteLine("//------------------- Command Design Pattern ----------------------//");
            //Define objects.
            IVehicle AudiA6 = new Car();
            IVehicle Cessna172 = new Plane();

            //Specific commands that hide the actual implementation.
            ICommand carGearUp = new CarGearUp(AudiA6);
            ICommand planeGearUp = new PlaneGearUp(Cessna172);
            ICommand turnAllOff = new TurnAllVehiclesOff(new List<IVehicle>() { AudiA6, Cessna172 });

            //A schedular that holds a couple commands ready to be executed at a later time.
            List<ICommand> scheduler = new List<ICommand>();
            scheduler.Add(carGearUp);
            scheduler.Add(planeGearUp);
            scheduler.Add(turnAllOff);

            //We don't need to know anything about the objects or the commands to execute them
            //This level of encapsulation is what the command design pattern is all about.
            foreach(ICommand cmnd in scheduler)
            {
                cmnd.Execute();
            }
            Console.ReadLine();
        }
    }
}
