using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE03
{
    class Program
    {
        private static Logger currentLogger = null;
        public static Logger GetLogger()
        {
            return currentLogger;
        }
        static void Main(string[] args)
        {
            Car currentCar = null;
            bool programIsRunning = true;

            while (programIsRunning)
            {
                string usersMenuChoice = MainMenu();

                // Do what the user asks with a switch
                //Menu must handle numeric selection “1, 2, 3, etc” as well as typed out options like “disable logging”.
                switch (usersMenuChoice)
                {
                    case "1":
                    case "disable logging":
                        {
                            DisableLogging();
                        }

                        break;
                    case "2":
                    case "enable logging":
                        {
                            EnableLogging();
                        }
                        break;
                    case "3":
                    case "create a car":
                        {
                            currentCar = CreateCar(currentCar);
                        }
                        break;
                    case "4":
                    case "drive the car":
                        {
                            currentCar = DriveCar(currentCar);
                        }
                        break;
                    case "5":
                    case "destory the car":
                        {
                            currentCar = DestoryCar(currentCar);
                        }
                        break;
                    case "6":
                    case "exit":
                        {
                            //Exit - stop the program
                            programIsRunning = false;
                        }
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
                "1. Disable logging\n" +
                "2. Enable logging\n" +
                "3. Create a car\n" +
                "4. Drive the car\n" +
                "5. Destory the car\n" +
                "6. Exit\n" +
                "Select an option: ");

            // take input from the user
            string input = Console.ReadLine().ToLower();

            return input;
        }

        private static void DisableLogging()
        {
            if (currentLogger == null || currentLogger is DoNotLog)
            {
                Utility.ColoredConsole("red", "Logging is Already Disabled");
            }
            else
            {

                DoNotLog notLogging = new DoNotLog();
                //Disable logging - create a new DoNotLog object and store it in Program’s static Logger field.
                currentLogger = notLogging;
                Utility.ColoredConsole("darkyellow", "Logging Disabled");

            }

        }

        private static void EnableLogging()
        {
            if (currentLogger is LogToConsole)
            {
                Utility.ColoredConsole("red", "Logging is Already Enabled");
            }
            else
            {
                //Enable logging - create a new LogToConsole object and store it in Program’s static Logger field.
                LogToConsole loggedToConsole = new LogToConsole();
                currentLogger = loggedToConsole;
                Utility.ColoredConsole("darkyellow", "Logging Enabled");
            }
        }

        private static Car CreateCar(Car currentCar)
        {
            //Create a car - prompt the user for values to create a car object and store the object in currentCar.

            string make = Validation.CheckforBlank("Please enter a Make: ");
            string model = Validation.CheckforBlank("Please enter a Model: ");
            string color = Validation.CheckforBlank("Please enter a Color: ");
            float mileage = Validation.GetFloatGreaterThanEqualToMin(0, float.MaxValue, "Please Enter the Mileage: ");
            int year = Validation.GetIntGreaterThanEqualToMin(1885, 2019, "Please Enter a Year(1885 - 2019): ");
            Car newCurrentCar = new Car(make, model, color, mileage, year);
            currentCar = newCurrentCar;
            if (currentLogger is DoNotLog)
            {
                Console.WriteLine($"\nA new car was created: Make: {currentCar.Make}, Model: {currentCar.Model}, Color: {currentCar.Color}, Mileage: {currentCar.Mileage.ToString()}, Year: {currentCar.Year.ToString()}");
            }
            return currentCar;
        }

        private static Car DriveCar(Car currentCar)
        {
            if (currentCar != null)
            {
                //Drive the car - prompt the user for how far they are driving the car and call the Drive method on currentCar.
                float mileage = Validation.GetFloatGreaterThanEqualToMin(1, float.MaxValue, $"How many miles did you drive your {currentCar.Color} {currentCar.Make} {currentCar.Model}? ");
                currentCar.Drive(mileage);
                if(currentLogger is DoNotLog)
                {
                    Console.WriteLine($"\nYou have driven your {currentCar.Color} {currentCar.Make} {currentCar.Model} your new mileage is: {currentCar.Mileage.ToString()}");
                }
            }
            else
            {
                Utility.ColoredConsole("red", "\nYou do not have a car please create one!");

            }
            return currentCar;
        }

        private static Car DestoryCar(Car currentCar)
        {
            if (currentCar != null)
            {
                //Destroy the car - set currentCar to null.
                Utility.ColoredConsole("darkyellow", $"You destroyed your {currentCar.Color} {currentCar.Make} {currentCar.Model}.");
                currentCar = null;
            }
            else
            {
                Utility.ColoredConsole("red","\nYou do not have a car please create one first!");
            }

            return currentCar;
        }
    }
}
