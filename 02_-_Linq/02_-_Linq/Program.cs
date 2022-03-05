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
            var MathTeachers = context.TeachersSubjects.
                               Join(
                               context.Teachers,
                               tSu => tSu.TeacherID,
                               tea => tea.ID,
                               (tSu, tea) => new
                               {
                                   tSu,
                                   tea
                               })
                               .Join(context.Subjects,
                               teaSub => teaSub.tSu.ID,
                               subj => subj.ID,
                               (teaSub, subj) => new { teaSub, subj })
                               .Where(s => s.subj.SubName.Equals("Matematik 7"))
                               .Select(t => new
                               {
                                   TID = t.teaSub.tea.ID,
                                   TName = t.teaSub.tea.Name,
                                   SName = t.subj.SubName
                               }
                               ).ToList();

            foreach (var item in MathTeachers)
            {
                Console.WriteLine(item.TID + "\t" + item.TName + "\t  " + item.SName);
            }

            #endregion

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
                              }).ToList();

            foreach (var item in stdsTeachs)
            {
                Console.WriteLine("ID = {0}, Elev = {1}, Ämne = {2}. Lärare = {3}",
                                  item.SID, item.SName, item.SSubj, item.STeach);
            }

            #endregion

            ///Where method syntax with Contains
            string selectSubj = "Programmering 1";
            var allSubjNames = context.Subjects.Where(a => a.SubName.Contains(selectSubj));
            bool hasProg = false;
            foreach (var item in allSubjNames)
            {
                if (item.SubName.Contains(selectSubj))
                {
                    Console.WriteLine("Ja, finns med bland ämnena", selectSubj);
                    hasProg = true;
                }
            }
            if (!hasProg)
            {
                Console.WriteLine("Nej, {0} finns ej bland ämnena...", selectSubj);
            }
            

        }
    }
}
