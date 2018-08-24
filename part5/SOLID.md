SOLID is a term describing a collection of design principles. 

SOLID means: 

    1| SRP | Single Responsibility Principle | A class should have one, and only one , reason to change.  | 单一责任原则
    2| OCP | Open/Closed Principle  | You should be able to extend a classes behavior, without modifying it. | 开放封闭原则
    3| LSP | Liskov Substitution Principle | derived classes must be substitutable for their base classes.| 里氏替换原则
    4| ISP | Interface Segregation Principle | make fine grained interfaces that are client specific.| 接口分离原则
    5| DIP | Dependency Inversion Principle  | depend on abstractions, not on concretions. | 依赖倒置原则
    
<br/>  

## Single Responsibility Princeiple
+ SRP states that every class should have a single responsibility. There should never be more than one reason for a class to change .
Thinking in term of responsibilities will help yolu desing your application better.  
Ask yourself whether the logic you are introducing should live in this class or not .

## Open/Closed Principle
+ OCP states that software entities should be open for extension, but closed for modification. 
You should make all member variables private by default, write getters and setters only when you need them . 

## Liskov Substitution Principle
+ LSP states that objects in a program should be replaceable with instances of their subtypes without altering the correctness of the program. 

## Interface Segregation Principle
+ ISP states that many client-specific interfaces are better than one general-purpose interface. 
in other words, you should not have to implement methods that you don't use. Enforcing ISP gives you low coupling, and high cohesion. 
NOTE: this is similar to the SRP. An interface is a contract that meets a need. 
it's ok to have a class that implements different interfaces, but be careful, don't violate SRP. 

## Dependency Inversion Principle
+ DIP has two key points: 
  1. Abstractions should not depend upon details;
  2. Details should depend upon abtractions. 
This principle could be rephrased as use the same level of abstraction at a given level. 
Interfaces should depend on other interfaces. Don't add concrete classes to method signatures of an interface. However, use interfaces in your class mehtods.
NOTE: DIP is not the same as Dependency injection. 
Dependency injection is about how one object knows about another dependent object. it is about how one object acquires a dependency. 
On the other hand, DIP is about the level of abstraction. also, a Dependency injection container is a way to auto-wire classes together. 
that does not mean you do dependency injection though. 

# Conclusion
avoiding tight coupling is the key. Take the time to understand those that you don't understand. 
