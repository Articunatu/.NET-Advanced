using System;
using System.Collections.Generic;
using System.Linq;

namespace _02___Linq
{
    class Program
    {
        static void Main()
        {
            SchoolDBContext context = new SchoolDBContext();

            #region Method multiple joins
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
                                where subj.ID.Equals(3)
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

            #endregion

            ///Lärare i ämnen
            # region Query multiple joins
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
            #endregion

            #region Method Where + Contains
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
            #endregion

            #region Query Where + Contains
            ///Where query syntax with Contains
            Console.WriteLine("\nAlla ämnen:");
            PrintSubjects(context);
            Console.Write("Välj ett ämne att ändra namn på: ");
            string chosenSubj = Console.ReadLine();
            Console.Write("Vad ska ämnet heta ");
            string subjName = Console.ReadLine();

            var changeSubj = from subj in context.Subjects
                             where subj.SubName.Contains(chosenSubj)
                             select subj;

            foreach (var item in changeSubj)
            {
                item.SubName = subjName;
            }

            Console.WriteLine("Alla nya ämnen:");
            PrintSubjects(context);
            #endregion

            foreach (var item in context.Students)
            {
                if (item.ClassID.Equals(1))
                {
                    item.ClassID = 2;
                }
            }

            
            foreach (var item in mentors2)
            {
                Console.WriteLine(item.SID + " " + item.SName + " " + item.TName);
            }
        }

        private static void PrintSubjects(SchoolDBContext context)
        {
            foreach (var item in context.Subjects)
            {
                Console.WriteLine(item.SubName);
            }
        }
    }
}
