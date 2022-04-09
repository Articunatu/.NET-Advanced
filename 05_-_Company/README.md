# .NET-Advanced


CODE PREVIEW:
![Skärmbild 2021-10-16 135317](https://user-images.githubusercontent.com/62301779/137586709-6bd3b484-6402-4159-a2b1-c8a1f9357598.png)

Main features:
- View the balance of each account

Extra features:
- Different currencies

# REFLECTION
STRUCTURE
The project consists of three models: Employee, Project and TimeReport, where TimeReport is the connecting table which creates the many-to-many relationship between Employee and Project. In the services, there are two interfaces, one for both repositories for Projects and TimeReports, and one for solely the Employee repository. This is because the Employee has two unique methods that the other classes do not use.

LINQ vs Loops
In one part of the code I used a SUM-method from the LINQ library in order to calculate the total amount of hours an employee has worked. If you wanted better performance from the project you could use a custom loop, because the linq methods already have extra loops. Normally you would mainly choose to use linq when you want to make the code more readable, but in this case I choose it only to learn to use linq more only for the sake of learning it better

 ![](https://user-images.githubusercontent.com/62301779/137586431-9c02608b-d33a-4fae-8a64-c5799a4731f9.png)
