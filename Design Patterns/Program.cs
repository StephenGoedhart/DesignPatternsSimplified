using System;
using System.Collections.Generic;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("//------------------- Simple Factory Pattern ----------------------//");
            AnimalFactory animalFactory = new AnimalFactory();
            Dog dog = animalFactory.createDog();
            Cat cat = animalFactory.createCat();

            Console.WriteLine("//------------------- Factory Method Design Pattern ----------------------//");
            ShapeFactory shapeFactory = new ShapeFactory();
            IShape circle = shapeFactory.Create(ShapeFactory.Type.circle);
            IShape rectangle = shapeFactory.Create(ShapeFactory.Type.rectangle);
            IShape triangle = shapeFactory.Create(ShapeFactory.Type.triangle);

            circle.printShape();
            rectangle.printShape();
            triangle.printShape();

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
