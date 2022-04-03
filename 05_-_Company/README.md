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
If I valued the performance of this project I would refrain from using LINQ-methods instead of custom loops, but since this is a school project I will LINQ more only for the sake of learning it better. Normally you would mainly use LINQ for the sake of making the code more readable. 
 ![](https://user-images.githubusercontent.com/62301779/137586431-9c02608b-d33a-4fae-8a64-c5799a4731f9.png)
