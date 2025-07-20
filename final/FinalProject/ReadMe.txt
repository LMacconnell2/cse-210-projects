To the user:

Please ensure that when you mention filepaths, do not forget to include ".json" at the end. Otherwise the program will not work propely. 

How everything has been implemented:
Abstraction:
- the program includes four different classes which represent types of events. In addition, other classes are present to better organize the program.

Encapsulation:
- The program includes both public and private attributes and methods. 

Inheritance: 
- The four event types each have their own classed which are derived from the base event class. You may remember 
that I had first intended to include a TimeBlock class. However, as I got closer to finishing the project, I realized
that a TimeBlock class was entirely redundant. 

Polymorphism:
- The Event class has DisplayEvent(), which is called and overwritten in shorthand by other classes. 