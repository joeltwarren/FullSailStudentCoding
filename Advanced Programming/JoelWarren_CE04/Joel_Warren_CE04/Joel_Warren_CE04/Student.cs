using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joel_Warren_CE04
{
    class Student
    {
        static int _nextStudentIDNum = 1000;

        string _firstName;
        string _lastName;
        string _email;
        string _address;
        string _phoneNumber;
        int _age;
        int _studentIdNum;
        List<Course> _courses;

        public Student(string firstName, string lastName)
        {
            _firstName = firstName; // added Name to first making firstName
            _lastName = lastName;
            _studentIdNum = ++_nextStudentIDNum;
            _courses = new List<Course>();
        }

        public string Name
        {
            get
            {
                return $"{_lastName}, {_firstName}";
            } // added } here

        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Phone
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        public int StudentNumber
        {
            get
            {
                return _studentIdNum;
            }
            set
            {
                _studentIdNum = value;
            }
        }
        public List<Course> Courses
        {
            get
            {
                return _courses;
            }
        }

        private int SelectCourse(string message)
        {
            int len = _courses.Count;
            int index = -1;

            if (len > 0)
            {
                for (index = 0; index < len; ++index)
                {
                    Console.WriteLine($"{index + 1}. {_courses[index].Title}");
                }
                Console.Write(message);
                string selection = Console.ReadLine(); // added () to the end of Console

                while (!int.TryParse(selection, out index) || (index < 1 || index > len))
                {
                    Console.Write("Please make a valid selection: ");
                    selection = Console.ReadLine();
                }

                --index;  //commented out this index change it creates a infinite loop
            }

            return index; // added keyword of return here
        }

        public void AddACourse()
        {
            string input;

            Console.Write("How many assignments are in the course? ");
            input = Console.ReadLine();
            int numAssignments = 0;

            while (!int.TryParse(input, out numAssignments))
            {
                Console.Write("Please enter a number: ");
                input = Console.ReadLine();
            }

            Course course = new Course(numAssignments);

            Console.Write("What is the courses title? ");
            course.Title = Console.ReadLine();

            Console.Write("What is the courses description? ");
            course.Description = Console.ReadLine(); // changed to console.readline()

            _courses.Add(course);
        }

        public void RemoveACourse()
        {
            int index = SelectCourse("Select a course to remove. (Enter the number): ");

            if (index >= 0) // changed == to >= 0 so that the indexed course number can be removed
            {
                _courses.RemoveAt(index); // swapped the if and else body here they were backwards
            }
            else
            {
                Console.WriteLine("No courses to remove.  Try adding one first.");
            }
        }

        public void AddGradesForACourse()
        {
            int index = SelectCourse("Select a course to add grades for. (Enter the number): ");

            if (index == -1)
            {
                Console.WriteLine("No course to add grades to.  Try adding one first.");
            }
            else
            {
                _courses[index].AddGrades();
            }
        }

        public void DisplayGradesForACourse()
        {
            int index = SelectCourse("Select a course to display grades for. (Enter the number): ");

            if (index == -1)
            {
                Console.WriteLine("No course to display grades for.  Try adding one first.");
            }
            else
            {
                _courses[index].DisplayGrades();
            }
        }

        public void DisplayAllGrades()
        {
            if (_courses.Count != 0) // added a size count check here to address an issue with displaying grades not working after creating a student. (option 1 then 7)
            {
                foreach (Course c in _courses)
                {
                    c.DisplayGrades(); // removed the comment lines from the start here of c.DisplayGrades();
                }
            }
            else
            {
                Console.WriteLine("Please Add Grades First");
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}\nAge: {Age}\nAddress: {Address}\nPhone: {Phone}\nEmail: {Email}");

        }
    }
} // added the } here

