using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_MVP
{
    class ConvertUtil
    {
        public static double ConvertStrToD(string strVal)
        {
            double retDouble = 0;
            retDouble = Convert.ToDouble(strVal);
            return retDouble;
        }
    }
}
