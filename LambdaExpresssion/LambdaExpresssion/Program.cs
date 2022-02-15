using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExpresssion
{
    class Program
    {
        static void Main()
        {
            //StatementLambda();

            int[] numbers = { 1, 2, 3, 4, 5};
            var sNum = numbers.Select(x => x * x);

           // Console.WriteLine(string.Join(" ", sNum));

            int[] numbers2 = { 5, 4, 1, 3, 8, 9, 15, 6, 21, 11, 2 };
            int oddNum = numbers2.Count(x => x % 2 == 1);

            //Console.WriteLine($"Det finns {oddNum} udda tal bland sifforna {string.Join(" ", numbers2)}");
            
            var NumberSets = new List<int[]>
            {
                new [] { 1, 2, 3, 4, 5},
                new [] { 0, 0, 0},
                new [] { 9, 8},
                new [] { 1, 0, 1, 0 , 1, 0, 1, 0},
            };

            var SetSwitchPos = from NumberSet in NumberSets 
                               where NumberSet.Count(x => x > 0) > 3
                               select NumberSet;
            ///Find all arrays with an index higher than 3
            ///
            foreach (var item in SetSwitchPos)
            {
                Console.WriteLine(string.Join("", item));
            }
        }

        private static void StatementLambda()
        {
            List<Employee> ListEmployees = new List<Employee>()
            {
                new Employee { ID = 101, FullName = "May"},
                new Employee { ID = 104, FullName = "Brendan"},
                new Employee { ID = 119, FullName = "Zinnia"},
            };

            ///Part 2
            //Predicate<Employee> employeePredicate = new Predicate<Employee>(FindEmployee);

            ///Part 3
            //Employee e1 = ListEmployees.Find(e => FindEmployee(e));
            //Console.WriteLine(e1.FullName);

            ///Part 4 Anonymous method
            Employee empAnon = ListEmployees.Find(
                delegate (Employee E)
                {
                    return E.ID == 101;
                }
                );
            Console.WriteLine(empAnon.FullName);

            Employee ELambd = ListEmployees.Find(X => X.ID == 101);
            Console.WriteLine(ELambd.FullName);

            Console.ReadKey();
        }

        ///Part 1 Name dependent method
        //public static bool FindEmployee(Employee emp)
        //{
        //    return emp.ID == 101;
        //}

    }
}
