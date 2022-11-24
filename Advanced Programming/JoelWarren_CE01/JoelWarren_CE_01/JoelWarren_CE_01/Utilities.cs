using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE_01
{
    class Utilities
    {
        // custom pause with default message if no message is passed during method call
        public static void Pause(string message = "Press any Key to Continue")
        {
            Console.WriteLine($"\n{message}");
            Console.ReadKey();
        }

        
    }
}
