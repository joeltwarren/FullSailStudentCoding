using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JoelWarren_CE09
{
    class LogToFile : Logger
    {

        // log filelocation
        private static string outPutFolder = @"..\..\IOFiles";

        static void Createfiles() { 
            // verifying the directory exists and if it does not we will create it.
            Directory.CreateDirectory(outPutFolder);
            // verifying the file exists and if it does not we will create it.
            File.Create(outPutFolder + @"\StoreLogs.txt").Close();
        }

        public override void Log(string log)
        {
            Utility.ColoredConsole("darkgray", $"Line Number: {_lineNumber} {log}");
            _lineNumber++;
        }
        public override void LogD(string logD)
        {
            Utility.ColoredConsole("yellow", $"Line Number: {_lineNumber} Debug: {logD}");
            _lineNumber++;
        }
        public override void LogW(string logW)
        {
            if (File.Exists(outPutFolder + @"\StoreLogs.txt"))
            {
                using (StreamWriter outStream = File.AppendText(outPutFolder + @"\StoreLogs.txt"))
                {
                    outStream.WriteLine($"{_lineNumber}. {logW}");
                }
                _lineNumber++;
            }
            else
            {
                Createfiles();
                using (StreamWriter outStream = File.AppendText(outPutFolder + @"\StoreLogs.txt"))
                {
                    outStream.WriteLine($"{_lineNumber}. {logW}");
                }
                _lineNumber++;
            }
        }
    }
}

