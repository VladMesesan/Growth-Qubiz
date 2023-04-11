using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Growth.Controllers.Csharp
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LINQController : ControllerBase
    {
        [HttpGet]
        public int[] GetOldSchoolLINQ()
        {
            var studentIds = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var studentsWithEvenIds =
                from studentId in studentIds
                where studentId % 2 == 0
                select studentId;

            return studentsWithEvenIds.ToArray();
        }

        [HttpGet]
        public string[] GetLambdaLINQ()
        {
            Student[] studentList = {
                new Student { StudentID = 1, StudentName = "John Nigel", Mark = 73, City ="NYC", Grades = new int[3] { 1, 2, 3 } },
                new Student { StudentID = 12, StudentName = "John Nigel", Mark = 49, City ="AL", Grades = new int[3] { 1, 3, 9 } },
                new Student { StudentID = 2, StudentName = "Alex Roma",  Mark = 51 , City ="CA", Grades = new int[3] { 4, 5, 6 } },
                new Student { StudentID = 3, StudentName = "Noha Shamil",  Mark = 88 , City ="CA", Grades = new int[3] { 7, 8, 9 } },
                new Student { StudentID = 4, StudentName = "James Palatte" , Mark = 60, City ="NYC", Grades = new int[3] { 1, 6, 9 } },
                new Student { StudentID = 5, StudentName = "Ron Jenova" , Mark = 85 , City ="NYC" }
                };

            string[] results = studentList.Where(x => x.Mark > 60)
                                          .Select(x => x.StudentName)
                                          .ToArray();

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            List<int> listGrades = studentList.Where(x => x.Grades != null).SelectMany(x => x.Grades).ToList();
            //SelectMany flattens results to just a list(or an array); Select would return a 2D Array here

            int[] arrayGrades = studentList.Where(x => x.Grades != null).SelectMany(x => x.Grades).ToArray(); //where for null check
            //above is list, here is array - both work

            string grades = "";
            for (int i = 0; i < arrayGrades.Length; i++)
            {
                grades += arrayGrades[i];
            }
            Trace.WriteLine("Select Many - " + grades);

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Order by name, then by city: " + studentList.OrderBy(x => x.StudentName).ThenBy(x => x.City));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Order desc by name: " + studentList.OrderByDescending(x => x.StudentName));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("All marks above 50? " + studentList.All(x => x.Mark > 50));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Any marks above 86? " + studentList.Any(x => x.Mark > 86));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Skip first 2 - " + studentList.Skip(2).ToArray()[0].StudentName + studentList.Take(2).ToArray()[1].StudentName);

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Only take first 2 - " + studentList.Take(2).ToArray()[0].StudentName + studentList.Take(2).ToArray()[1].StudentName);

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Add up all marks - " + studentList.Sum(x => x.Mark));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Number of students with marks above 65 - " + studentList.Count(x => x.Mark > 65));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Highest mark -  " + studentList.Max(x => x.Mark));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Lowest mark - " + studentList.Min(x => x.Mark));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("Average of marks - " + studentList.Average(x => x.Mark));

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("First student with id multiple of 2 - , OR ELSE error!" + studentList.First(x => x.StudentID % 2 == 0).StudentName);
            //returns first element that satisfies condition; ArgumentNullException if input is null; InvalidOperationException if result is null

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("FirstOrDefault student with ID == 1 - " + studentList.FirstOrDefault(x => x.StudentID % 2 == 0)?.StudentName);
            //if no result, it will return null for reference types and a default value for value types

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("One single student with ID == 1, OR ELSE error! - " + studentList.Single(x => x.StudentID == 1).StudentName);
            // ArgumentNullException if input is null or if more than one element satisfies the condition

            Trace.WriteLine("--------------------------------------------------------------------------------------------------");
            Trace.WriteLine("One singleOrDefault student with ID == 1 - " + studentList.SingleOrDefault(x => x.StudentID == 1)?.StudentName);
            //if no element meets condition, will return null for reference type or the default value for value types

            return results;
        }
    }

    internal class Student
    {
        public Student() { }

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Mark { get; set; }
        public string City { get; set; }
        public int[] Grades { get; set; }
    }
}
