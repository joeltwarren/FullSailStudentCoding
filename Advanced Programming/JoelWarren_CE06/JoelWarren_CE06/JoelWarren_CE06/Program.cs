using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE06
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Employee> employees = new List<Employee>();
            //Employees.Sort();

            bool programIsRunning = true;

            // while loop for program starting the menu
            while (programIsRunning)
            {

                string userInput = MainMenu();
                // Do what the user asks with a switch
                switch (userInput)
                {
                    case "1":
                    case "add employee":
                    case "add":
                        {
                            employees = CreateEmployee(employees);
                        }
                        break;
                    case "2":
                    case "remove employee":
                    case "remove":
                        {
                            if (Validation.CollectionIsNullOrEmpty(employees))
                            {
                                Utility.ColoredConsole("red", "Please create an employee first!");
                            }
                            else
                            {
                                employees = RemoveEmployee(employees);
                            }
                        }
                        break;
                    case "3":
                    case "display payroll":
                    case "display":
                    case "payroll":
                        {
                            if (Validation.CollectionIsNullOrEmpty(employees))
                            {
                                Utility.ColoredConsole("red", "Please create an employee first!");
                            }
                            else
                            {
                                DisplayPayroll(employees);
                            }

                        }
                        break;
                    case "4":
                    case "exit":
                    case "quit":
                    case "done":
                        {
                            programIsRunning = false;
                        }
                        break;
                    default:
                        Utility.ColoredConsole("red", "Please choose a valid menu option.");
                        break;

                }
                Utility.PauseBeforeContinuing();
            }
        }

        static string MainMenu()
        {
            Console.Clear();
            // display a list of options
            Console.Write(
                "1. Add Employee\n" +
                "2. Remove Employee\n" +
                "3. Display Payroll\n" +
                "4. Exit Program\n" +
                "Choose a selection: ");
            
            // take input from the user
            string input = Console.ReadLine().ToLower();
            return input;
        }

        static List<Employee> CreateEmployee(List<Employee> employees)
        {
            
            // we are going to go ahead and create a second menu system for adding employees
            bool stillAddingEmployees = true;
            while (stillAddingEmployees)
            {
                Console.Clear();
                // display a list of options
                Console.Write(
                    "What type of employee would you like to add?\n" +
                    "1. Full Time\n" +
                    "2. Part Time\n" +
                    "3. Contractor\n" +
                    "4. Salaried\n" +
                    "5. Manager\n" +
                    "6. return to previous menu\n" +
                    "Choose a selection: ");

                // take input from the user
                string input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "1":
                    case "full time":
                    case "full":
                        {
                            string name = Validation.CheckForBlank("Employee Name: ");
                            string address = Validation.CheckForBlank("Employee Address: ");
                            decimal payPerHour = Validation.GetDecimalGreaterThanEqualToMin(7.5m, decimal.MaxValue,"Pay Per Hour($7.50 Minimum Wage): ");
                            FullTime fullTimeEmployee = new FullTime(name,address,payPerHour);
                            employees.Add(fullTimeEmployee);
                            
                        }
                        break;
                    case "2":
                    case "part time":
                    case "part":
                        {
                            string name = Validation.CheckForBlank("Employee Name: ");
                            string address = Validation.CheckForBlank("Employee Address: ");
                            decimal payPerHour = Validation.GetDecimalGreaterThanEqualToMin(7.5m, decimal.MaxValue, "Pay Per Hour($7.50 Minimum Wage): ");
                            decimal numOfHour = Validation.GetDecimalGreaterThanEqualToMin(1, decimal.MaxValue, "Number Of hours Worked: ");
                            PartTime partTimeEmployee = new PartTime(name, address, payPerHour, numOfHour);
                            employees.Add(partTimeEmployee);
                        }
                        break;
                    case "3":
                    case "contractor":
                        {
                            string name = Validation.CheckForBlank("Employee Name: ");
                            string address = Validation.CheckForBlank("Employee Address: ");
                            decimal payPerHour = Validation.GetDecimalGreaterThanEqualToMin(7.5m, decimal.MaxValue, "Pay Per Hour($7.50 Minimum Wage): ");
                            decimal numOfHour = Validation.GetDecimalGreaterThanEqualToMin(1, decimal.MaxValue, "Number Of hours Worked: ");
                            decimal noBenefitsBonus = Validation.GetDecimalGreaterThanEqualToMin(10, 100, "Percent of No Benefits Bonus(10 to 100): ");
                            Contractor contractorEmployee = new Contractor(name,address,payPerHour,numOfHour,noBenefitsBonus);
                            employees.Add(contractorEmployee);
                        }
                        break;
                    case "4":
                    case "salaried":
                        {
                            string name = Validation.CheckForBlank("Employee Name: ");
                            string address = Validation.CheckForBlank("Employee Address: ");
                            decimal salary = Validation.GetDecimalGreaterThanEqualToMin(1, decimal.MaxValue, "Salary: ");
                            Salaried salariedEmployee = new Salaried(name, address, salary);
                            employees.Add(salariedEmployee);
                        }
                        break;
                    case "5":
                    case "manager":
                        {
                            string name = Validation.CheckForBlank("Employee Name: ");
                            string address = Validation.CheckForBlank("Employee Address: ");
                            decimal salary = Validation.GetDecimalGreaterThanEqualToMin(1, decimal.MaxValue, "Salary: ");
                            decimal yearlyBonus = Validation.GetDecimalGreaterThanEqualToMin(1, decimal.MaxValue, "Yearly Bonus: ");
                            Manager managerEmployee = new Manager(name, address, salary, yearlyBonus);
                            employees.Add(managerEmployee);
                        }
                        break;
                    case "6":
                    case "return to previous menu":
                    case "return":
                    case "quit":
                        {
                            stillAddingEmployees = false;
                        }
                        break;
                       

                }
            }
            employees.Sort();
            return employees;
        }
        static List<Employee> RemoveEmployee(List<Employee> employees)
        {
            int counter = 0;
            Console.WriteLine("List of Current Employees:");
            foreach (Employee person in employees)
            {
                counter++;
                Console.WriteLine($"{counter} Name: {person.Name}");

            }
            int usersInput = Validation.GetIntGreaterThanEqualToMin(1, counter, "Choose an Employee to Remove: ");
            usersInput--;
            Console.WriteLine($"Employee: {employees[usersInput].Name} has been removed from payroll.");
            employees.RemoveAt(usersInput);
           
            return employees;
        }

        static void DisplayPayroll(List<Employee> employees)
        {
            
            int counter = 0;
            Console.WriteLine("\r\n");
            Console.WriteLine("|=================|");
            Console.WriteLine("|Employee Records |");
            Console.WriteLine("|=================|");
            foreach (Employee person in employees)
            {
                counter++;
                Console.WriteLine("******************************************************************************************************");
                Console.WriteLine($"Record: {counter}\n\rName: {person.Name}\n\rAddress: {person.Address}\n\rYearly Pay: {person.CalculatePay().ToString("C")}");
                Console.WriteLine("******************************************************************************************************");
            }
        }
        

    }
    
}
