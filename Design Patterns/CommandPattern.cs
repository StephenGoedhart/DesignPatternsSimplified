using System;
using System.Collections.Generic;


namespace Design_Patterns
{
    //By using an interface we guarantee that all ICommand interface types are executable and undoable.
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    //Instantiating a vehicle interface to use polymorphism later on
    public interface IVehicle
    {
        void turnOn();
        void turnOff();
        void GearUp();
        void GearDown();
    }

    //Car implementation of the Vehicle interface
    public class Car : IVehicle 
    {
        private int gear = 0;

        public void turnOn()
        {
            Console.WriteLine("Car started");
        }

        public void turnOff()
        {
            Console.WriteLine("Car stopped");
        }

        public void GearUp()
        {
            gear++;
            Console.WriteLine("Car switched gear to: " + gear);
        }

        public void GearDown()
        {
            gear--;
            Console.WriteLine("Car switched gear to: " + gear);
        }

    }

    //Plane implementation of the Vehicle interface
    public class Plane : IVehicle
    {
        public void turnOn()
        {
            Console.WriteLine("Plane engine spooling up");
        }
        public void turnOff()
        {
            Console.WriteLine("Plane engine cooling down");
        }
        public void GearUp()
        {
            Console.WriteLine("Landing Gear Up");
        }
        public void GearDown()
        {
            Console.WriteLine("Landing Gear Down");
        }         
    }

    //Car specific command encapsulating the Car object
    public class CarGearUp : ICommand
    {
        private IVehicle car;
        public CarGearUp(IVehicle newCar)
        {
            car = newCar;
        }

        public void Execute()
        {
            car.GearUp();
        }

        public void Undo()
        {
            car.GearDown();
        }
    }

    //Plane specific command encapsulating the Plane object
    public class PlaneGearUp : ICommand
    {
        private IVehicle plane;
        public PlaneGearUp(IVehicle newPlane)
        {
            plane = newPlane;
        }

        public void Execute()
        {
            plane.GearUp();
        }

        public void Undo()
        {
            plane.GearDown();
        }
    }

    //Vehicle specific command combining encapsulation and polymorphism
    public class TurnAllVehiclesOff : ICommand
    {
        private List<IVehicle> vehicles;
        public TurnAllVehiclesOff(List<IVehicle> newVehicles)
        {
            vehicles = newVehicles;
        }

        public void Execute()
        {
            foreach(IVehicle vehicle in vehicles)
            {
                vehicle.turnOff();
            }
        }

        public void Undo()
        {
            foreach (IVehicle vehicle in vehicles)
            {
                vehicle.turnOn();
            }
        }
    }    
}
