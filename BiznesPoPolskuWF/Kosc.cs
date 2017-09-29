using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesPoPolskuWF
{
    public static class Kosc
    {
        private static Random rnd = new Random();
        public static bool CzyRzucano { get; set; } = false;
        public static int RzutKoscia()
        {
            CzyRzucano = true;
            return rnd.Next(1, 7);//1-7
        }
    }
}
