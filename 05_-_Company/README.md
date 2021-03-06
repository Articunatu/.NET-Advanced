# .NET-Advanced

Fifth and final project of the Advanced .NET course, 
*Consists of:*
- REST-API 
- Database using Entity Framework, coded first
- Usage of LINQ
- Async tasks

ER Diagram over database models:
![ER Diagram](https://github.com/Articunatu/.NET-Advanced/blob/main/05_-_Company/ER-Diagram.png)

UML Diagram for services:
![UML](https://github.com/Articunatu/.NET-Advanced/blob/main/05_-_Company/UML-Services.png)

# REFLECTION
STRUCTURE<br />
The project consists of three models: Employee, Project and TimeReport, where TimeReport is the connecting table which creates the many-to-many relationship between Employee and Project. In the services, there are two interfaces, one for both repositories for Projects and TimeReports, and one for solely the Employee repository. This is because the Employee has two unique methods that the other classes do not use.
The project follows the third normal form.
It consists of as few models as possible, with the intention of decreasing the number of joins in the queries. 

INTERFACES<br />
There are two interfaces for the three services, one for the project and time report services, which could be considered the main interface. The second interface is only implemented by the employee service since it has two extra methods: One for reading all employees associated with a specific project, and one for calculating the total amount of hours an employee has worked on a chosen week. 
The flaw with these two interfaces is that the employee one is the same as the other one, but with two additional methods. Originally I wanted the employee interface to exclusively consist of the two original methods. Then the employee service would have implemented two different interfaces instead of one, but I, unfortunately, couldn’t get it to work with two interfaces for one service in the Startup-class. 

PERFORMANCE<br />
The ToArrayAsync method would drag down the performance with really large databases, where you want to fetch around a million unique records. Thus it’s mostly suited for smaller projects such as this one.

LINQ vs LOOPS<br />
In one part of the code I used a SUM-method from the LINQ library in order to calculate the total amount of hours an employee has worked. If you wanted better performance from the project you could use a custom loop, because the linq methods already have extra loops in their source code. Normally you would mainly choose to use linq when you want to make the code more readable, but in this case I choose it only to learn to use linq more only for the sake of learning it better. 
![](https://github.com/Articunatu/.NET-Advanced/blob/main/05_-_Company/Linq%20Code.png)<br />
It should also be noted that this WeeklyHours method could have been even shorter by using Include() instead of a join query.

DATE<br />
Date in TimeReport was originally going to be of the DateTime type, with each time report being connected to a specific date. Then in the method WeeklyHours, the date would be converted to the correct week (of an integer type). The conversion never worked out, so instead each time report has an integer variable that stores the week the time report was written. Ideally, it would have been better to use a DateTime type in order to get access to optimized calculation methods that are stored within both C# and SQL. Another flaw without the DateTime variable is that you won’t be able to know the year in which the report was written, and would need another variable for the year itself. 


 
