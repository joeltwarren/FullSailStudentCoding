using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE02
{
    class Course
    {
        private string _courseTitle;
        private string _courseDescription;
        private Teacher _teacher;
        private Student[] _students;

        // this will instantiat the Course object and set the _students array to the correct size but leave it empty
        public Course(string courseTitle, string courseDescription, int numOfStudents)
        {
            _courseTitle = courseTitle;
            _courseDescription = courseDescription;
            _students = new Student[numOfStudents];
        }

        public Teacher TeacherOfClass
        {
            get { return _teacher; }
            set { _teacher = value; }
        }

        public string CourseName
        { 
            get{ return _courseTitle; }
        }

        public Student[] Students
        {
            get { return _students; }
            set { _students = value; }
        }

        public string Description
        {
            get { return _courseDescription; }
        }
    }


}
