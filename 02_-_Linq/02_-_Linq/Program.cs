using System;
using System.Collections.Generic;
using System.Linq;

namespace _02___Linq
{
    class Program
    {
        static SchoolDBContext context = new SchoolDBContext();

        static void Main()
        {
            Console.WriteLine("MATEMATIK LÄRARE:\n");
            MathTeachers();
            Console.WriteLine("\n*****************\n");

            Console.WriteLine("ELEVERS LÄRARE\n");
            StudentsTeachers();
            Console.WriteLine("\n*****************\n");

            Console.WriteLine("FINNS PROGRAMMERING 1 SOM KURS");
            ContainsProg1();
            Console.WriteLine("\n*****************\n");

            Console.WriteLine("BYTA NAMN PÅ ETT ÄMNE");
            ChangeSubjName();
            Console.WriteLine("\n*****************\n");

            Console.WriteLine("BYT MENTOR FRÅN ANAS TILL REIDAR");
            ChangeMentor();
            Console.WriteLine("\n*****************\n");
        }

        private static void ChangeMentor()
        {
            foreach (var item in context.Students)
            {
                if (item.ClassID.Equals(1))
                {
                    item.ClassID = 2;
               }
            }

            foreach (var item in context.Students)
            {
                Console.WriteLine(item.Name + " " + item.ClassID);
            }

            var mentorsQuery = (from s in context.Students
                                join t in context.Teachers
                                on s.ClassID equals t.ClassID
                                //join c in context.Courses
                                //on s.ClassID equals c.ID
                                select new
                                {
                                    SID = s.ID,
                                    SName = s.Name,
                                    TName = t.Name
                                }).ToArray();

            foreach (var item in mentorsQuery)
            {
                Console.WriteLine(item.SID + " " + item.SName + " " + item.TName);
            }

            context.SaveChanges();
        }

        private static void ChangeSubjName()
        {
            ///Where query syntax with Contains
            Console.WriteLine("\nAlla ämnen:");
            PrintSubjects();
            Console.Write("\nVälj ett ämne att ändra namn på: ");
            string chosenSubj = Console.ReadLine();
            Console.Write("\nVad ska ämnet heta ");
            string subjName = Console.ReadLine();

            var changeSubj = from subj in context.Subjects
                             where subj.SubName.Contains(chosenSubj)
                             select subj;

            foreach (var item in changeSubj)
            {
                item.SubName = subjName;
            }

            //context.SaveChanges();

            Console.WriteLine("\nAlla nya ämnen:");
            PrintSubjects();
        }

        private static void ContainsProg1()
        {
            ///Where method syntax with Contains
            string selectSubj = "Programmering 1";
            var allSubjNames = context.Subjects.Where(a => a.SubName.Contains(selectSubj));
            bool hasProg = false;
            foreach (var item in allSubjNames)
            {
                if (item.SubName.Contains(selectSubj))
                {
                    Console.WriteLine("Ja, {0} finns med bland ämnena", selectSubj);
                    hasProg = true;
                }
            }
            if (!hasProg)
            {
                Console.WriteLine("Nej, {0} finns ej bland ämnena...", selectSubj);
            }
        }

        private static void MathTeachers()
        {
            //var MathTeachers = context.TeachersSubjects.
            //                   Join(
            //                   context.Teachers,
            //                   tSu => tSu.TeacherID,
            //                   tea => tea.ID,
            //                   (tSu, tea) => new
            //                   {
            //                       tSu,
            //                       tea
            //                   })
            //                   .Join(context.Subjects,
            //                   teaSub => teaSub.tSu.ID,
            //                   subj => subj.ID,
            //                   (teaSub, subj) => new { teaSub, subj })
            //                   .Where(s => s.subj.SubName.Equals("C# Introduktion"))
            //                   .Select(t => new
            //                   {
            //                       TID = t.teaSub.tea.ID,
            //                       TName = t.teaSub.tea.Name,
            //                       SName = t.subj.SubName
            //                   }
            //                   ).ToList();

            var MathTeachers = (from tSub in context.TeachersSubjects
                                join tea in context.Teachers
                                on tSub.TeacherID equals tea.ID
                                join subj in context.Subjects
                                on tSub.SubjectID equals subj.ID
                                where subj.ID.Equals(4)
                                select new
                                {
                                    TID = tea.ID,
                                    TName = tea.Name,
                                    SName = subj.SubName
                                }
                                ).ToList();

            foreach (var item in MathTeachers)
            {
                Console.WriteLine(item.TID + " " + item.TName + " " + item.SName);
            }
        }

        private static void StudentsTeachers()
        {
            Console.WriteLine("ÄMNESLÄRARE:");
            ///Lärare i ämnen
            var stdsTeachs = (from std in context.Students
                              join stSu in context.StudentsSubjects
                              on std.ID equals stSu.StudentID
                              join subj in context.Subjects
                              on stSu.SubjectID equals subj.ID
                              join teSu in context.TeachersSubjects
                              on subj.ID equals teSu.SubjectID
                              join tea in context.Teachers
                              on teSu.TeacherID equals tea.ID
                              select new
                              {
                                  SID = std.ID,
                                  SName = std.Name,
                                  STeach = tea.Name,
                                  SSubj = subj.SubName
                              }).ToArray();

            foreach (var item in stdsTeachs)
            {
                Console.WriteLine("ID = {0}, Elev = {1}, Ämne = {2}. Lärare = {3}",
                                  item.SID, item.SName, item.SSubj, item.STeach);
            }

            Console.WriteLine("\nMENTORER:");
            ///Mentorer
            var mentors = context.Courses.
                               Join(
                               context.Teachers,
                               cou => cou.ID,
                               tea => tea.ClassID,
                               (cou, tea) => new
                               {
                                   cou,
                                   tea
                               })
                               .Join(context.Students,
                               course => course.cou.ID,
                               std => std.ClassID,
                               (courses, stds) => new { courses, stds })

                               .Select(t => new
                               {
                                   SID = t.stds.ID,
                                   SName = t.stds.Name,
                                   TName = t.courses.tea.Name
                               }
                               ).ToList();
            foreach (var item in mentors)
            {
                Console.WriteLine(item.SID + " " + item.SName + " " + item.TName);
            }

        }

        private static void PrintSubjects()
        {
            foreach (var item in context.Subjects)
            {
                Console.WriteLine(item.SubName);
            }
        }
    }
}
