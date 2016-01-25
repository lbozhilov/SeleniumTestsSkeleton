using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public static class Logger
    {
        public static StringBuilder log = new StringBuilder();
        public static StringBuilder Log(string error)
        {
            log.Append(error + "\n");
            return log;
        }
    }
}
