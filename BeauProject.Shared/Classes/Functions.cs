using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeauProject.Shared.Classes
{
    public class Functions
    {
        public static string GetTime()
        => DateTime.Now.ToString("HH:mm:ss");

        public static string GetDate()
        => DateTime.Now.ToString("yyyy/MM/dd");
    }
}
