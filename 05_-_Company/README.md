# .NET-Advanced
# InternetBank

Final project of the Introduction to C# course. 
A simple version of an internet bank, requiered to at least contain one array and methods of your own.
You can choose between 5 unique users to log in to, and they all have a different amount of accounts.

CODE PREVIEW:
![Skärmbild 2021-10-16 135202](https://user-images.githubusercontent.com/62301779/137586695-6c38fa18-8976-4740-8f0e-fab1bfc990d9.png)
![Skärmbild 2021-10-16 135241](https://user-images.githubusercontent.com/62301779/137586699-648005b4-97ed-4cac-b6e9-a35be9061f43.png)
![Skärmbild 2021-10-16 135317](https://user-images.githubusercontent.com/62301779/137586709-6bd3b484-6402-4159-a2b1-c8a1f9357598.png)

Main features:
- View the balance of each account
- Transfer money between accounts
- Withdraw money from an account

Extra features:
- Different currencies
- Creating new accounts
- Transfering between users
- Store money
- Changes in money are kept, even after logging out
- 3 minute timer lockout for entering wrong pincodes

# REFLECTION
I have chosen to base all the code around an user index (an integer variable) which determines which user logged in at the moment, and what variables the user gets access in the bank. This user index variable is passed as a parameter to all the methods of the bank service.

The names for all the accounts are stored in a two-dimensional string array, and the money of each account is stored in a two-dimensional double array. 
These arrays are divided into different users by the rows, the first row contains the first user's 5 accounts, the second row has the second user's 4 accounts.
The user index is always placed as the first index of the these arrays, and the second index represents the chosen account.
It might not look obvious to an outsider what role the user index and number input have in each situation, which would be the biggest flaw of relying so heavily on multi-dimensional arrays - which only can use numbers as the indexes.

Each of the different functions of the bank are divided into separate methods, which are accessed through a switch statement which checks what number the user has written. Another switch statement was used to check what username the user has written. Switch statements were used instead of else if statements because they take up less lines of codes (if you place the breaks correctly), looks cleaner and are usually preferable when having more than 3 options. 

The function to open new accounts could have been more easily made with a list instead of the multi-dimensional arrays, since there exists a function for adding new elements to the list. Using a list was ignored becuase this course doesn't include the use of object-oriented programming.
No such function exists for array, and if you try to set a new size to an already defined array, all the values it contains will be lost. There was a need to re-loop the arrays containing a user's account names and balances instead of simply adding a new one. Then you could set a new size for the two arrays, and finally add the old backup values.

The array for currency signs is one-dimensional and gives out the currency sign depending on the second index of an  account; a user's first account will always contain SEKs, the second account has EURs, the third USDs, the forth GBPs and the fifth will have DKKs. A two-dimensional array containing doubles was used to calculate the values of each currency in the other ones.
This structure could also be seen as the biggest flaw of the program. If a user only has two accounts they can only have SEKs and EURs on them. 

The currency arrays only contain 5 different ones, so when an user has more than 5 accounts the program automitically defaults the currency to SEKs - and ignores conversion when transfering between accounts. This could have been solved by having the user create their own currency when opening their 6th account, similar to how the program reloops the specified arrays to create a new account. Both the currency sign and calculator arrays would then need to be re-looped, and the user would have to input all the new currency coefficients as well. I initially ignored this solution becuase it would be too much code to write (only to solve a very specific case in the program).

If the currency sign array also would have been two-dimensional it would have been possible to manually set the currency of each individual account. But then that would also have requiered the array - containing the currency converter coefficients - to be of a different size.

Perhaps the best solution would be to keep the currency sign array be one-dimensional, but add another two-dimensional array (for integers). Each account would have number - between 0 and 4 -  which would be used as an index to access a currency sign from the currency sign array. This could also be used to access coefficients from the currency conversion array.
If a user with 5 account wants to open a 6th one they would only need to input the number for the corresponding currency. There would be no need to expand any arrays, like in the previous solutions!


There is a lack of foreach loops in the code because the output always needed to be two-dimensional. Unless I'm missing an obvious solution, the foreach loop could only write out the text in columns like this, wth inconsistent formating: ![](https://user-images.githubusercontent.com/62301779/137586431-9c02608b-d33a-4fae-8a64-c5799a4731f9.png)
Instead the program uses normal for loops with a condition checking to the length of the arrays you want to loop, and can easily print out two different variables on the same row.

The program could alternatively have used floats instead of doubles for the decimal values to save storage (only 2 decimals are needed in this project), but didn't want to write an F after every value. Decimals could also have been used to get more exact values, which is often used in real bank services. But since this is only a smaller project, I prioritized the most readable code with fast performance. 

All the functions are set to static because it looks cleaner to someone reading the code, where as you could argue it to be unnecsessary to have so much be shared across classes that don't exist.  I'm also used to programming in Unity, where you can access public functions within the same script without having to manually creating an instance. I prioritized the readability (or length) of the code, without taking the performance into consideration.

This is the first time I have used Date.Time, and used this instead of timer primarily because it was listed among the sources for the course and doesn't require you to import another class library. With that being said, if it was possible to add a function similar to the WaitForSeconds that exists in Unity I would have done that because it would have made the code a bit shorter and visually cleaner, even if it meant downloading extra files.

Exception references could be more specific for various scenarious, as of now the same output is always used when an error occurs. 

The structure for the commit messages might not be entirely consistent, but generally newly added features are labeled as ”feat”, then followed by what is added, and ”fix” is used when a bug fix has been done. Comments in the program are also labeled as ”feat”, which perhaps should have had the ”docs” - for documentation. 
