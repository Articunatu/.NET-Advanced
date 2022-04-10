# .NET-Advanced

Fifth and final project of the Advaneced .NET course
*Consists of:*
- REST-API 
- Database using Entity Framework
- Usage of LINQ
- Async tasks

ER Diagram over database models:
![ER Diagram](https://github.com/Articunatu/.NET-Advanced/blob/main/05_-_Company/ER-Diagram.png)

UML Diagram for services:
![Skärmbild 2021-10-16 135317](https://user-images.githubusercontent.com/62301779/137586709-6bd3b484-6402-4159-a2b1-c8a1f9357598.png)

# REFLECTION
STRUCTURE
The project consists of three models: Employee, Project and TimeReport, where TimeReport is the connecting table which creates the many-to-many relationship between Employee and Project. In the services, there are two interfaces, one for both repositories for Projects and TimeReports, and one for solely the Employee repository. This is because the Employee has two unique methods that the other classes do not use.

The project follows the third normal form.
It consists of as few models as possible, with the intention of decreasing the number of joins in the queries. 

INTERFACES
There are two interfaces for the three services, one for the project and time report services, which could be considered the main interface. The second interface is only implemented by the employee service since it has two extra methods: One for reading all employees associated with a specific project, and one for calculating the total amount of hours an employee has worked on a chosen week. 
The flaw with these two interfaces is that the employee one is the same as the other one, but with two additional methods. Originally I wanted the employee interface to exclusively consist of the two original methods. Then the employee service would have implemented two different interfaces instead of one, but I, unfortunately, couldn’t get it to work with two interfaces for one service in the Startup-class. 

PERFORMANCE
The ToArrayAsync method would drag down the performance with really large databases, where you want to fetch around a million unique records. Thus it’s mostly suited for smaller projects such as this one.

LINQ vs LOOPS
In one part of the code I used a SUM-method from the LINQ library in order to calculate the total amount of hours an employee has worked. If you wanted better performance from the project you could use a custom loop, because the linq methods already have extra loops in their source code. Normally you would mainly choose to use linq when you want to make the code more readable, but in this case I choose it only to learn to use linq more only for the sake of learning it better. It should also be noted that this WeeklyHours method could have been even shorter by using Include() instead of a join query.

DATE
Date in TimeReport was originally going to be of the DateTime type, with each time report being connected to a specific date. Then in the method WeeklyHours, the date would be converted to the correct week (of an integer type). The conversion never worked out, so instead each time report has an integer variable for which week the time report was written. 

 ![](https://user-images.githubusercontent.com/62301779/137586431-9c02608b-d33a-4fae-8a64-c5799a4731f9.png)
