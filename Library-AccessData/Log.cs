using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_AccessData
{
    public static class Log
    {
        public static void WriteLog(string message)
        {
            using (StreamWriter s = new StreamWriter("C:\\Users\\VERS\\source\\repos\\Library-Domain\\Library-AccessData\\errors.txt", true))
            {
                s.WriteLine(message);
            }
        }
    }
}
