


namespace StudentGradingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string []subject = { "Math", "Science", "English", "History", "Arabic" };
            List<Student> students = new List<Student>(); 

         
            while (true)
            {
                Console.WriteLine("Welcome to the Grading System");
                Console.WriteLine("Please enter your name:");

                string name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty. Please try again.");
                    continue;
                }
               
                List<int> stdGrades = new List<int>(); // List to hold grades for the current student
                
                Console.WriteLine("Please Enter Your Grade for each subject");
             
                for(int i =0; i < subject.Length; i++)
                {
                    Console.Write($"Enter the grade of {subject[i]}: ");
                    int gradeSubject = int.Parse(Console.ReadLine());
                    stdGrades.Add(gradeSubject); // Add the grade to the student's list of grades

                }

                // Create a new student object and add it to the list
                Student student = new Student
                {
                    Name = name,
                    Grades = stdGrades
                };
               
                students.Add(student);
                Console.WriteLine($"A new Student Added With name {name} and total grades {student.Grades.Count} Successfully");

                Console.WriteLine("Do you want to add another student? (y/n): ");

                string response = Console.ReadLine().ToLower();
                if (response != "y")
                {
                    Console.WriteLine("Exiting the grading system. Goodbye!");
                    break;
                }

            }

            GradingSystem gradingSystem = new GradingSystem();
            gradingSystem.DisplayGradeingInfo(students,CalculateAverage,checkStdPassed,DisplayData);

        }

      

        private static bool checkStdPassed(double avgGrade)
        { 
          if(avgGrade >= 40) // Check if the average grade is 60 or above
            {
                return true; // Student passed
            }
            else
            {
                return false; // Student failed
            }
        }
        private static double CalculateAverage(List<int> list)
        {

            if (list == null || list.Count == 0)
            {
                return 0; // Return 0 if the list is null or empty
            }
            return list.Sum() / list.Count; // Calculate and return the average
        }
        private static void DisplayData(Student student, double avgGrades, bool IsPassed)
        {
            string status = IsPassed ? "Passed" : "Failed";
            Console.WriteLine($"The name of student: {student.Name} , the Average of grades is {avgGrades} and he is {status}");
        }
    }
}
