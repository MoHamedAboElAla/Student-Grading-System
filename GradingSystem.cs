using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingSystem
{
    internal class GradingSystem
    {
        public void DisplayGradeingInfo(List<Student> students, 
        Func<List<int>,double> calculateAverage,
        Predicate<double> checkPassed,
        Action<Student, double, bool> DisplayData)
        {

            foreach (var student in students)
            {
              
                double averageGrades= calculateAverage(student.Grades);
                bool isPassed = checkPassed(averageGrades);
                DisplayData(student,averageGrades,isPassed);

            }
        }
    }
}
