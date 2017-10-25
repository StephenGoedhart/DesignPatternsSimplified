###### *Stephen Goedhart*
# Gang of Four: Simplified

### Solutions to reoccurring object-oriented programming challenges. 
Simplified documentation to increase memorability and usability.

Original Title: Design Patterns: Elements of reusable Object-Oriented Software. 

Original Authors:  E. Gamma, R. Helm, R. Johnson, J. Vlissides.

## 23 Design patterns categorized

* **Creational Design Patterns:** Design patterns that deal with object creation.
  * **Factory Method:** The Factory design pattern instantiates objects based on classes with a common parent class or interface. Instantiating such objects in a factory class, we guarantee type dependencies and decrease invalid type errors.
* **bstract Factory:** 


* Item 2
  * Item 2a
  * Item 2b


Design patterns that deal with object creation.

* Abstract Factory
* Builder
* Prototype
* Singleton
2. Structural Design Patterns
* Adapter	
* Bridge
* Composite
* Decorator
* Facade
* Proxy
3. Behavioral Design Patterns
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
By separating method invocation (command) from method declaration (receiver) using the implementation of the command design pattern we reach a new level of decoupling and possibilities.
* Call multiple receiver methods within the command. 
* Call commands within commands. 
* Extent behavior by adding / altering commands without worrying about the actual implementation. 
* Alter implementation in the receiver class without worrying it’s dependencies.  


## Command Pattern

![alt text]( https://github.com/StephenGoedhart/DesignPatternsSimplified/blob/master/Src/images/commandDesignPatternDiagram.png "Command Design Pattern Diagram")

By separating method invocation from method declaration using the implementation of the command design pattern we reach a new level of decoupling and possibilities.
* Call multiple receiver methods within the command. 
* Call commands within commands. 
* Extent behavior by adding / altering commands without worrying about the actual implementation. 
* Alter implementation in the receiver class without worrying it’s dependencies.  

###### C# Code example:
```C#
    //By using an interface we guarantee type related functionality.
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    //Use a receiver interface to enable the use of polymorphism later on.
    public interface IVehicle
    {
        void turnOn();
        void turnOff();
        void GearUp();
        void GearDown();
    }

    //Define a receiver class that implements the receiver interface
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

    //Define another receiver class that implements the receiver interface
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

    //A command can be as specific as you'd like. This command only adheres to Car objects. 
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

    //A command can be as specific as you'd like. This command only adheres to Plane objects. 
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

    //A command can be as specific as you'd like. This command adheres to all IVehicle types. 
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

