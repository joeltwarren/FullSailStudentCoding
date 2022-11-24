using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoelWarren_CE03
{
    abstract class Logger : ILog
    {
        // this field will track the number of lines used for when data is logged.
        protected static int _lineNumber;

        abstract public void Log(string log);
        abstract public void LogD(string logD);
        abstract public void LogW(string logW);
    }
}
