###### *Stephen Goedhart*
# Gang of Four: Simplified

### Solutions to reoccurring object-oriented programming challenges. 
Simplified documentation to increase memorability and usability.
Original Title: Design Patterns: Elements of reusable Object-Oriented Software. 
Original Authors:  E. Gamma, R. Helm, R. Johnson, J. Vlissides.
## 23 Design patterns categorized
1. Creational
…Factory Method
…Abstract Factor
…Builder
* Prototype
* Singleton
2. Structural
* Adapter	
* Bridge
* Composite
* Decorator
* Facade
* Proxy
3. Behavioral
* Interpreter
* Template method
* Chain of Responsibility
* Command
* Iterator
* Mediator
* Memento
* Flyweight
* Observer
* State
* Strategy
* Visitor

#### Creational design patterns
Defers object creation to subclasses.
#### Structural design patterns
Describes ways to assemble objects.
#### Behavioral design patterns
Describes how a group of objects cooperate to perform a task that no single object can do alone.
## Use cases for:
#### Abstract Factory, Factory Method, Prototype
When you want to use polymorphism to instantiate objects of classes with a common parent class. Not using the design pattern may lead to faulty instantiation and code assuming inheritance that isn’t available. 

#### Chain of Responsibility, Command

## Command Pattern
```C#
    //By using an interface we guarantee that all ICommand interface types are executable and undoable.
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    //Instantiating a vehicle interface to use polymorphism later on.
    public interface IVehicle
    {
        void turnOn();
        void turnOff();
        void GearUp();
        void GearDown();
    }

    //Car implementation of the Vehicle interface.
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

    //Plane implementation of the Vehicle interface.
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

    //Car specific command encapsulating the Car object.
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

    //Plane specific command encapsulating the Plane object.
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

    //Vehicle specific command combining encapsulation and polymorphism.
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

static void Main(string[] args)
        {
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

            //We don't need to know anything about the objects or the commands to execute them.
            //This level of encapsulation is what the command design pattern is all about.
            foreach(ICommand cmnd in scheduler)
            {
                cmnd.Execute();
            }
        }
```

