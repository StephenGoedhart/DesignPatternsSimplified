###### *Stephen Goedhart*
# Gang of Four: Simplified
### Simplified documentation to increase memorability and usability.

Original Title: Design Patterns: Elements of reusable Object-Oriented Software. 

Original Authors:  E. Gamma, R. Helm, R. Johnson, J. Vlissides.


## Design patterns categorized

* **Creational Design Patterns:** Design patterns that deal with object creation.
  * **[Simple Factory / Factory Pattern](#simple-factory):** The Simple Factory Pattern denotes the practice of creating a class that contains object creating methods. This pattern is used to encapsulate object instantiation logic and to declare this logic in one place.
  * **[Factory Method / Virtual Constructor](#factory-method):** The Factory Method denotes the practice of creating an abstract factory class with an object creation method. We can override this factory method in child classes. This approach increases scalability as we force polymorphic dependency.
  * **Abstract Factory / Kit Pattern:** 


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

## Simple Factory
###### [< Back to pattern overview](#design-patterns-categorized)
 
![alt text]( https://github.com/StephenGoedhart/DesignPatternsSimplified/blob/master/Src/images/SimpleFactoryDesignPattern.png "Simple Factory Design Pattern Diagram")

The Simple Factory Pattern denotes the practice of creating a class that contains object creating methods. This pattern is used to encapsulate object instantiation logic and to declare this logic in one place.

The class diagram depicts a factory class with two methods. CreateCat and CreateDog. The names are self-explanatory. CreateCat() returns a new Cat and CreateDog returns a new Dog. We can now create either object without needing to know anything about its instantiation logic since that is encapsulated within factory class.  

###### C# Declaration:
```C#
namespace SimpleFactory
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
}```

###### C# Usage:
```C#
using System;
using System.Collections.Generic;
using SF = SimpleFactory;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Declare simple factory.
            SF.AnimalFactory animalFactory = new SF.AnimalFactory();

            //Use factory to create objects.
            SF.Dog sfDog = animalFactory.createDog();
            SF.Cat sfCat = animalFactory.createCat();
        }
    }
}
//Output: 
//Created Dog
//Created Cat
```

## Factory Method
###### [< Back to pattern overview](#design-patterns-categorized)

![alt text]( https://github.com/StephenGoedhart/DesignPatternsSimplified/blob/master/Src/images/factoryMethodDesignPatternDiagram.png "Factory Method Design Pattern Diagram")

A factory class instantiates objects based on classes with a common parent class or interface using polymorphism. This way we guarantee type and decrease invalid type errors.

###### C# Code example:
```C#
public interface IAnimal
    {
        void makeSound();
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

    public abstract class AnimalFactory
    {
        public abstract IAnimal Create();
    }

    public class DogFactory : AnimalFactory
    {
        public override IAnimal Create()
        {
            return new Dog();
        }
    }

    public class CatFactory : AnimalFactory
    {
        public override IAnimal Create()
        {
            return new Cat();
        }
    }//Output: 
//This is a circle 
//This is a rectangle
//This is a triangle
```

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

