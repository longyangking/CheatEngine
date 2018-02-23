using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CheatEngine
{
    class MemoryManager
    {
        public static Process[] GetProcesses()
        {
            Process[] ps = Process.GetProcesses();
            return ps;
        }
        
    }
}
