######*Stephen Goedhart*
#Gang of Four: Simplified
###Solutions to recurring object-oriented programming challenges in C#. Simplified documentation to increase memorability and usability.
Original Title: Design Patterns: Elements of reusable Object-Oriented Software. 
Original Authors:  E. Gamma, R. Helm, R. Johnson, J. Vlissides.
##23 Design patterns categorized
1. Creational
* Factory Method
* Abstract Factor
* Builder
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

####Creational design patterns
Defers object creation to subclasses.
####Structural design patterns
Describes ways to assemble objects.
####Behavioral design patterns
Describes how a group of objects cooperate to perform a task that no single object can do alone.
##Use cases for:
####Abstract Factory, Factory Method, Prototype
When you want to use polymorphism to instantiate objects of classes with a common parent class. Not using the design pattern may lead to faulty instantiation and code assuming inheritance that isn’t available. 

####Chain of Responsibility, Command

Command Pattern

