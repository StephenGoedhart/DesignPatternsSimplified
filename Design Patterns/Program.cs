using System;
using System.Collections.Generic;
using SF = SimpleFactory;
using FM = FactoryMethod;
using AF = AbstractFactory;
using AP = AdapterPattern;

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

            Console.WriteLine("//------------------- Abstract Factory Pattern ----------------------//");

            //Use the hidden factory instantiation logic to two factories.
            AF.AbstractFactory Factory1 = AF.FactoryFactory.Create("animal");
            AF.AbstractFactory Factory2 = AF.FactoryFactory.Create("clothing");

            //Use the factories to create the needed objects.
            AF.IAnimal afDog = Factory1.getAnimal("dog");
            AF.IAnimal afCat = Factory1.getAnimal("cat");

            AF.IClothing afHat = Factory2.getClothing("hat");
            AF.IClothing afPants = Factory2.getClothing("pants");

            //Output data to make sure everything went OK. 
            afDog.makeSound();
            afCat.makeSound();

            afHat.printDescription();
            afPants.printDescription();

            Console.WriteLine("//------------------- Adapter Design Pattern ----------------------//");  
 
            AP.IAnimal apDog = new AP.Dog();
            AP.IAnimal apCat = new AP.Cat();
            AP.IVehicle jaguar = new AP.Car();
            AP.IAnimal adaptedJaguar = new AP.AnimalVehicleAdapter(jaguar);

            List<AP.IAnimal> animals = new List<AP.IAnimal>();
            animals.Add(apDog);
            animals.Add(apCat);
            animals.Add(adaptedJaguar);

            foreach(AP.IAnimal animal in animals)
            {
                animal.makeSound();
            }


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
