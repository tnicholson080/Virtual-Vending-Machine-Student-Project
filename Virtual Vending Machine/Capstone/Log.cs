using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public static class Log
    {
        public static void CapstoneLog(string logMessage)
        {
            string cdirectory = @"C:\Users\Student\workspace\c-sharp-mini-capstone-module-1-team-4\Capstone\bin\Debug\netcoreapp3.1";
            string outputfile = "logs/vendinglog.log";
            string outputfullpath = Path.Combine(cdirectory, outputfile);

            using (StreamWriter sw = new StreamWriter(outputfullpath, true))
            {
                sw.WriteLine(logMessage);

            }
        }


    }
}
