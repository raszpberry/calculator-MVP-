using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_MVP
{
    public class FormulaUtil
    {
        public static double Sum(double fNum, double sNum)
        {
            double retSum = fNum + sNum;
            return retSum;
        }

        public static double Difference(double fNum, double sNum)
        {
            double retDiff = fNum - sNum;
            return retDiff;
        }

        public static double Product(double fNum, double sNum)
        {
            double retProd = fNum * sNum;
            return retProd;
        }

        public static double Quotient(double fNum, double sNum)
        {
            double retQuo = fNum / sNum;
            return retQuo;
        }

    }
}

