using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joel_Warren_CE04
{
    class Course
    {
        string _title;
        string _description;
        Grade[] _grades;
        bool _graded = false; // changed int type to bool & set this to false so the logic bug would be fixed where you create a student and it will not fail the if statement when displaying grades before adding them

        public string Title // changed float type to string to match the private field and fix another error found during course creation
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
        public Grade[] Grades
        {
            get
            {
                return _grades;
            }
        }

        public Course(int numberOfAssignments)
        {
            _grades = new Grade[numberOfAssignments];
            _graded = false;
        }

        public void AddGrades()
        {
            do
            {
                for (int i = 0; i < _grades.Length; ++i) // added ; between 0 & i after int
                {
                    _grades[i] = new Grade();

                    Console.Write($"Enter a description for assignment {i + 1}: ");
                    _grades[i].Description = Console.ReadLine();


                    string input = "";
                    float value;

                    Console.Write($"Enter the grade earned for assignment {i + 1} as a percentage (0 - 100): ");
                    input = Console.ReadLine();

                    while (!float.TryParse(input, out value)) // added ! to fix the tryparse with adding a grade it now accepts a number
                    {
                        Console.WriteLine("Please enter a number: ");
                        input = Console.ReadLine();
                    }

                    _grades[i].PercentEarned = value;

                    Console.Write($"Enter assignment {i + 1}'s weight of total grade as a percentage (0 - 100): ");
                    input = Console.ReadLine();

                    while (!float.TryParse(input, out value))
                    {
                        Console.WriteLine("Please enter a number: ");
                        input = Console.ReadLine();
                    }
                    _grades[i].Weight = value;
                }
            } while (ValidateWeightTotal() == false);
            _graded = true;
        }

        private bool ValidateWeightTotal()
        {
            float precisionFactor = 0.001f; //changed int type to float
            float _totalWeight = 0;
            bool result = false;

            for (int i = 0; i < _grades.Length; ++i)
            {
                _totalWeight += _grades[i].Weight;
            }

            if(_totalWeight < 100 + precisionFactor && _totalWeight > 100 - precisionFactor)
            {
                result = true;
            }

            if (result == false)
            {
                Console.WriteLine($"Weight total = {_totalWeight} instead of 100.\nPlease enter the values again.\n"); // added ( after console.writeline
            }

            return result;
        }

        public float GetFinalGrade()
        {
            bool weightsAreValid = ValidateWeightTotal();
            float finalGrade = 0;

            if(weightsAreValid)
            {
                for (int i = 0; i < _grades.Length; ++i)
                {
                    finalGrade += _grades[i].GetPercentOfFinalGrade();
                }
            }

            return finalGrade;
        }

        public void DisplayGrades()
        {
            if (_graded && ValidateWeightTotal()) // added && ValidaeWeightTotal()
            {
                float total = 0f;
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Title: {Title}");
                for (int i = 0; i < _grades.Length; ++i)
                {
                   Grade grade = _grades[i];
                   total += grade.GetPercentOfFinalGrade(); // removed line comments
                   Console.WriteLine($"Desc: {grade.Description}\nEarned: {grade.PercentEarned}\nPercent towards final grade: {grade.GetPercentOfFinalGrade()}\n");
                }
                
                Console.WriteLine($"Grade for the course: {total}");
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("Please add correct grades first.");
            }
        }
    }
}
