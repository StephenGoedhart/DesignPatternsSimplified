###### *Stephen Goedhart*
# Design Patterns: Simplified
### Simplified documentation to increase memorability and usability.

Source Title: Design Patterns: Elements of reusable Object-Oriented Software. 

Original Authors:  E. Gamma, R. Helm, R. Johnson, J. Vlissides.


## Design patterns categorized

* **Creational Design Patterns:** Design patterns that deal with object creation.
  * **[Simple Factory / Factory Pattern](#simple-factory):** The Simple Factory Pattern denotes the practice of creating a class that contains object creating methods. This pattern is used to encapsulate (hide) object instantiation logic and to declare this logic in one place.
  * **[Factory Method / Virtual Constructor](#factory-method):** The Factory Method denotes the practice of creating an abstract factory class with an object creation method. We can override this object creation method in child classes. This approach increases scalability as we force polymorphic dependency.
  * **[Abstract Factory / Super Factory](#abstract-factory):** The abstract factory denotes the practice of using a factory to create other factories. This is most often used when there are multiple families of factories and we want to hide the instantiation logic. 
  * **[Builder](#builder):** Builder… //To
  * **[Prototype](#prototype):** Prototype… //To do

* **Structural Design Patterns:** Design patterns that deal with relationships between components. 
  * **[Adapter](#adapter):** The Abstract pattern is used to make objects of different types compatible. One of the benefits of doing this is easy collaboration and scalability, since we don’t have to alter type definitions to make them compatible. 




Design patterns that deal with object creation.

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
}
```


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

The Factory Method denotes the practice of creating an abstract factory class with an object creation method. We can override this factory method in child classes. This approach increases scalability as we force polymorphic dependency.

###### C# Declaration:
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
    }
```
###### C# Usage:
```C#
using System;
using System.Collections.Generic;
using FM = FactoryMethod;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define factories with overridden factory methods.
            FM.CatFactory catFactory = new FM.CatFactory();
            FM.DogFactory dogFactory = new FM.DogFactory();

            //Use factories to define objects based on the same type. 
            FM.IAnimal fmDog = dogFactory.Create();
            FM.IAnimal fmCat = catFactory.Create();

                             fmDog.makeSound();
            fmCat.makeSound();
         }
    }
}


//Output: 
//Woof! 
//Meow!
```

## Abstract Factory
###### [< Back to pattern overview](#design-patterns-categorized)
 
![alt text]( https://github.com/StephenGoedhart/DesignPatternsSimplified/blob/master/Src/images/AbstractFactoryDesignPatternDiagram.png "Abstract Factory Design Pattern Diagram")

The abstract factory denotes the practice of using a factory to create other factories. This is most often used when there are multiple families of factories and we want to hide the instantiation logic. 

###### C# Declaration:
```C#
using System;

namespace AbstractFactory
{
    public interface IAnimal
    {
        void makeSound();
    }

    public interface IClothing
    {
        void printDescription();
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

    public class Hat : IClothing
    {
        public void printDescription()
        {
            Console.WriteLine("A brightly colored party hat!");
        }
    }

    public class Pants : IClothing
    {
        public void printDescription()
        {
            Console.WriteLine("Denim based pants!");
        }
    }

    public abstract class AbstractFactory
    {
        public abstract IAnimal getAnimal(string animal);
        public abstract IClothing getClothing(string clothing);
    }

    public class AnimalFactory : AbstractFactory
    {
        public override IAnimal getAnimal(string animal)
        {
            if (animal == "cat")
                return new Cat();
            if (animal == "dog")
                return new Dog();
            return null;
        }

        public override IClothing getClothing(string clothing)
        {
            return null;
        }
    }

    public class ClothingFactory : AbstractFactory
    {
        public override IAnimal getAnimal(string animal)
        {
            return null;
        }

        public override IClothing getClothing(string clothing)
        {
            if (clothing == "hat")
                return new Hat();
            if (clothing == "pants")
                return new Pants();
            return null;
        }
    }

    public class FactoryFactory
    {
        public static AbstractFactory Create(string factory)
        {
            if (factory == "animal")
                return new AnimalFactory();
            if (factory == "clothing")
                return new ClothingFactory();
            return null;
        }
    }
}
```
###### C# Usage:
```C#
using System;
using AF = AbstractFactory;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {      
            //Use the hidden factory instantiation logic to two factories.
            AF.AbstractFactory Factory1 = AF.FactoryFactory.Create("animal");
            AF.AbstractFactory Factory2 = AF.FactoryFactory.Create("clothing");

            //Use the factories to create the needed objects.
            AF.IAnimal dog = Factory1.getAnimal("dog");
            AF.IAnimal cat = Factory1.getAnimal("cat");

            AF.IClothing hat = Factory2.getClothing("hat");
            AF.IClothing pants = Factory2.getClothing("pants");

            //Output data to make sure everything went OK. 
            dog.makeSound();
            cat.makeSound();

            hat.printDescription();
            pants.printDescription();//Output: 
        }
    }
}
//Output:
//Woof!
//Meow!
//A brightly colored party hat!
//Denim based pants!
```


## Adapter 
###### [< Back to pattern overview](#design-patterns-categorized)
 
![alt text]( https://github.com/StephenGoedhart/DesignPatternsSimplified/blob/master/Src/images/AdapterDesignPattern.png "Abstract Factory Design Pattern Diagram")

The Abstract pattern is used to make objects of different types compatible. One of the benefits of doing this is easy collaboration, since we don’t have to alter type definitions (that might’ve been written by someone else) to make them compatible. 

In the code below you can see that we created two interfaces. IAnimal and IVehicle. These interfaces contain different methods. By creating an AdapterClass we can call IVehicle specific methods (throttle();) from IVehicle objects whenever we request IAnimal specific methods (makeSound();) from the adapter itself. 

###### C# Declaration:
```C#
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
```
###### C# Usage:
```C#
using System;
using AP = AdapterPattern;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {      
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
            }        }
    }
}
//Output:
//Woof!
//Meow!
//Vroom!
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

