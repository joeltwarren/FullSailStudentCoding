using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Joel Warren
// 1806
// Project & Portfolio 1
// This coding challenge will be used to create two arrays and allow the user to pick a color and then identify the biggest fish of that color.

namespace DVP1.CE1
{
    class BigBlueFish
    {
        public static void FindTheFish() {

            Console.Clear();
            Console.WriteLine(@"
  ___ _        _    _ _   _   _     ___ _    _    
 | _ |_)__ _  | |  (_) |_| |_| |___| __(_)__| |_  
 | _ \ / _` |_| |__| |  _|  _| / -_) _|| (_-< ' \ 
 |___/_\__, ( )____|_|\__|\__|_\___|_| |_/__/_||_|
       |___/|/                                    
                            
======================================================================
======================================================================

Welcome to BigBlueFish: 
Lets see how the fish finder works shall we?");

            Console.WriteLine("Please select a color of fish and press return.");
            Console.WriteLine("\r\n");

            // creating two arrays to for static data
            string[] colors = new string[] { "Blue", "Green", "Red", "White", "Pink", "Pink", "White", "Red", "Green", "Blue", "Blue", "White" };
            float[] length = new float[] { 12.3f, 19.2f, 14.5f, 6.4f, 27.4f, 18.9f, 32.8f, 26.6f, 44.4f, 2.5f, 11.9f, 9.9f };

            // creating a list to add colors to basically removing duplicates to auto create a menu that will not break if you change the static data
            List<string> colorsList = new List<string>();

            // looping through and adding colors to the colorsList if the color does not exist already
            foreach (string color in colors) {
                if (!colorsList.Contains(color)) {
                    colorsList.Add(color);
                }
            }

            // created a counter outside of the foreach loop to track index changes
            // then I auto populate a menu based on the counter to represent the menu options EX: [1] Blue [2] Green etc...
            int counter = 0;
            List<int> validSelections = new List<int>();
            foreach (string i in colorsList) {
                counter++;
                validSelections.Add(counter);
                Console.WriteLine($"[{counter}] {i}");
                
            }

            // capture the users choice from the auto menu and validate that choice.
            string usersSelection = Console.ReadLine();
            int usersSelectedColor;
            int.TryParse(usersSelection, out usersSelectedColor);

            while (!validSelections.Contains(usersSelectedColor)) {
                Console.WriteLine("Please enter a vaild menu option:");
                usersSelection = Console.ReadLine();
                int.TryParse(usersSelection, out usersSelectedColor);

            }
            
            // variable used to store the uses current selected fish
            string usersChosenColor = colorsList[usersSelectedColor - 1];

            // request user to choose an action of biggest or smallest
            Console.WriteLine($"Please tell me if you want to know the biggest or smallest {usersChosenColor} fish");
            Console.WriteLine(@"
[1] Biggest
[2] Smallest
");
            // capture users choice and validate it using an array of possible answers.
            string usersBigOrSmallChoice = Console.ReadLine();
            int usersBigOrSmallChoiceConverted;
            int[] validMenuOptions = new int[] {1, 2 };
            while (!int.TryParse(usersBigOrSmallChoice, out usersBigOrSmallChoiceConverted) || !validMenuOptions.Contains(usersBigOrSmallChoiceConverted)) {
                Console.WriteLine("Please enter a valid menu option and press return");
                usersBigOrSmallChoice = Console.ReadLine();
            }

            
            // create a list of all the index numbers that contain the users select color of fish
            List<int> colorIndexs = new List<int>();


            // after much struggle I realized how to simplify my collection of indexs issue...
            for (int i = 0; i < colors.Length; i++) {
                if (colors[i].Contains(usersChosenColor)) {
                    colorIndexs.Add(i);
                }

            }
            // created a variable to hold the biggest length fish
            var biggestFish = 0f;
            var smallestFish = 1000f;
            // iterate or loop through my list of index numbers and set biggest fish lenght and smallest fish length.
            foreach (var index in colorIndexs) {
                if (biggestFish < length[index]) {
                    biggestFish = length[index];
                }
                if (smallestFish > length[index]) {
                    smallestFish = length[index];
                }
            }


            // output final comparison results and chosen color of fish to the user
            if (usersBigOrSmallChoiceConverted == 1)
            {

                Console.WriteLine($"The biggest {usersChosenColor} fish is {biggestFish.ToString()} inches");
            }
            else if (usersBigOrSmallChoiceConverted == 2)
            {

                Console.WriteLine($"The Smallest {usersChosenColor} fish is {smallestFish.ToString()} inches");

            }
            else {
                Console.WriteLine("something went wrong try again! Press Return");
                Console.ReadKey();
                FindTheFish();

            }


            // the below commented out code I do not want to delete because I learned a lot here with lists
            /*
            var indexs = colors.Select((f, index) => new { Color = f, Index = index }).Where(r => r.Color == usersChosenColor).ToList();
            foreach (var i in indexs) {
                Console.WriteLine(i);
                
            }
            foreach (var item in colors.Where(i => i.Contains(usersChosenColor))) {
                Console.WriteLine(item);
                
            }
            */

            Console.WriteLine(@"
======================================================================
Press any key to return to the main menu: ");

        }
    }
}
