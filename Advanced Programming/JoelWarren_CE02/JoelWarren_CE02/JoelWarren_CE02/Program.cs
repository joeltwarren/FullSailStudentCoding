using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE02
{
    class Program
    {
        static void Main(string[] args)
        {
            // course variable
            Course currentCourse = null;
            // program run control
            bool programIsRunning = true;

            // while loop for program starting the menu
            while (programIsRunning)
            {
                // calling the main menu and getting the users input
                string input = Menu();

                // Do what the user asks with a switch
                switch (input)
                {
                    case "1":
                    case "create a course":
                        {
                            currentCourse = CreateCourse();
                        }
                        break;
                    case "2":
                    case "create a teacher":
                        {
                            CreateTeacher(currentCourse);
                        }
                        break;
                    case "3":
                    case "add students":
                        {
                            CreateStudents(currentCourse);
                        }
                        break;
                    case "4":
                    case "display course information":
                        {
                            DisplayCourse(currentCourse);
                        }
                        break;
                    case "5":
                    case "exit":
                        {
                            programIsRunning = false;
                        }
                        break;


                }
                Utility.PauseBeforeContinuing();
            }

        }
        static string Menu()
        {
            Console.Clear();
            // display a list of options
            Console.Write(
                "1. Create a course\n" +
                "2. Create a teacher\n" +
                "3. Add students\n" +
                "4. Display course information\n" +
                "5. Exit\n" +
                "Select an option: ");

            // take input from the user
            string input = Console.ReadLine().ToLower();
            return input;
        }

        // create the required course information
        static Course CreateCourse()
        {

            // ask for and store the necessary variables to create the new course object
            Console.Write("What is the name of the course? ");
            string courseName = Validation.CheckforBlank(Console.ReadLine());

            Console.Write("What is the description of the course? ");
            string description = Validation.CheckforBlank(Console.ReadLine());

            int numOfStudents = Validation.GetIntGreaterThanEqualToMin(0, 300, "How many students will be in this class (0-300)? ");

            // create the new course object and assign it to the currentCourse Variable
            Course currentCourse = new Course(courseName, description, numOfStudents);

            return currentCourse;
        }

        // ask for and store the necessary variables to create the new Teacher object
        static void CreateTeacher(Course currentCourse)
        {
            
            if (currentCourse == null)
            {
                Console.WriteLine("Please create a course before adding a teacher.");

            }
            else
            {
                Console.Write("What is the teacher's name? ");
                string name = Validation.CheckforBlank(Console.ReadLine());

                Console.Write("What is the teacher's description? ");
                string description = Validation.CheckforBlank(Console.ReadLine());

                int age = Validation.GetIntGreaterThanEqualToMin(18, 70, "Enter the teachers's age (18 -70): ");

                Teacher newTeacher = new Teacher(name, description, age);
                currentCourse.TeacherOfClass = newTeacher;

                bool keepAddingKnowledge = true;

                string[] knowledge = null;
                List<string> knowledgeList = new List<string>();
                while (keepAddingKnowledge)
                {

                    Console.Write("What knowledge does this instructor have? ");
                    knowledgeList.Add(Validation.CheckforBlank(Console.ReadLine()));
                    bool enterMore = Validation.GetBool("Would you like to continue adding more knowledge inforamtion? (y/n) ");
                    if (enterMore == false)
                    {
                        keepAddingKnowledge = false;
                    }
                }
                knowledge = knowledgeList.ToArray();
                newTeacher.TeachersKnowledge = knowledge;
            }
        }

        // ask for and store the necessary variables to create the new student object
        static void CreateStudents(Course currentCourse)
        {
            if (currentCourse != null)
            {
                int numOfStudentsCounter = currentCourse.Students.Length;

                for (int i = 0; i < numOfStudentsCounter; i++)
                {

                    Console.Write("What's the students name? ");
                    string studentsName = Validation.CheckforBlank(Console.ReadLine()); ;

                    Console.Write("What's the students descritpion? ");
                    string studentsDescritpion = Validation.CheckforBlank(Console.ReadLine()); ;

                    int studentsAge = Validation.GetIntGreaterThanEqualToMin(0,80, "What's the students age (5-80)? ");

                    Student newStudents = new Student(studentsName, studentsDescritpion, studentsAge);
                    currentCourse.Students[i] = newStudents;

                    newStudents.Grade = Validation.GetIntGreaterThanEqualToMin(0, 100, "What's the students current grade (0-100)? ");
                }
            }
            else
            {
                Console.WriteLine("Please create a course first attempting to add students.");
            }
        }

        // display all currrent coure related data
        static void DisplayCourse(Course currentCourse)
        {
            if (currentCourse != null && currentCourse.TeacherOfClass!= null && currentCourse.Students != null)
            {
                if (currentCourse.Students[0]?.Name != null)
                {
                    Console.WriteLine("===============================================================================");
                    Console.WriteLine($"The current course name is {currentCourse.CourseName}");
                    Console.WriteLine($"The current course description is {currentCourse.Description}");
                    Console.WriteLine($"The current number of students in {currentCourse.CourseName} is {currentCourse.Students.Length.ToString()}");
                    Console.WriteLine("\r\n");
                    Console.WriteLine("===============================================================================");
                    Console.WriteLine($"The current course Teacher is {currentCourse.TeacherOfClass.Name}");
                    Console.WriteLine($"{currentCourse.TeacherOfClass.Name}'s knowledge is {Utility.StringToArrayUsingJoin(currentCourse.TeacherOfClass.TeachersKnowledge)}");
                    Console.WriteLine($"{currentCourse.TeacherOfClass.Name}'s age is {currentCourse.TeacherOfClass.Age}");
                    Console.WriteLine("\r\n");
                    Console.WriteLine("===============================================================================");
                    Console.WriteLine($"The {currentCourse.CourseName} classes student information is:");

                    int indexCount = currentCourse.Students.Length;
                    for (int i = 0; i < indexCount; i++)
                    {
                        Console.WriteLine("\r\n");
                        Console.WriteLine("===================================================");
                        Console.WriteLine($"Student's Name: {currentCourse.Students[i].Name}");
                        Console.WriteLine($"Student's Descritption: {currentCourse.Students[i].Description}");
                        Console.WriteLine($"Student's Age: {currentCourse.Students[i].Age}");
                        Console.WriteLine($"Student's Current Grade: {currentCourse.Students[i].Grade}");
                    }
                }
                else
                {
                    Console.WriteLine("Please create the students before displaying the course information.");
                }
            }
            else
            {
                Console.WriteLine("Please create a course, a teacher, and students before displaying the course information.");
            }
        }
    }
}
