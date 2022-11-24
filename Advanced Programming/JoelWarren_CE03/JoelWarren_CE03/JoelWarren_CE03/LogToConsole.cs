using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE03
{
    class LogToConsole : Logger
    {
        public override void Log(string log)
        {
            Utility.ColoredConsole("darkgray",$"Line Number: {_lineNumber} {log}");
            _lineNumber++;
        }
        public override void LogD(string logD)
        {
            Utility.ColoredConsole("yellow", $"Line Number: {_lineNumber} Debug: {logD}");
            _lineNumber++;
        }
        public override void LogW(string logW)
        {
            Utility.ColoredConsole("red", $"Line Number: {_lineNumber} Warning: {logW}");
            _lineNumber++;
        }
    }
}
