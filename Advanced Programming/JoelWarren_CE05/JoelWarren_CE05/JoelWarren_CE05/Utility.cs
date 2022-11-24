using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE05
{
    class Utility
    {
        
        // This Pauses the application and waits for a users key press.
        public static void PauseBeforeContinuing(string message = "Press a key to continue.")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }


        // this joins an array of stirngs for console output primarily for testing.
        public static string StringToArrayUsingJoin(string[] array)
        {
            // Use string Join to concatenate the string elements.
            string result = string.Join(", ", array);
            return result;
        }

        // allows me to change the console FOREGROUNDCOLOR using two string inputs (color, comment)
        public static void ColoredConsole(string color = "yellow", string input = "Your Comment Goes Here!")
        {
            color = color.ToLower();
            ConsoleColor orginalColor = Console.ForegroundColor;
            if (color == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (color == "black")
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (color == "cyan")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (color == "darkblue")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else if (color == "darkcyan")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (color == "darkgray")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (color == "darkgreen")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (color == "darkmagenta")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (color == "darkred")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (color == "darkyellow")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            else if (color == "gray")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (color == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (color == "magenta")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (color == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "white")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else 
            {
                Console.ForegroundColor = orginalColor;
            }

            Console.WriteLine(input);
            Console.ForegroundColor = orginalColor;
            
        }
    }
}
