using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Calculator_MVP
{
    class CalculatorServices
    {
        public double Calculate(List<string> lstDisplay)
        {
            double retAns = 0;

            for (int i = 0; i < lstDisplay.Count;)
            {
                string caseSwitch = lstDisplay[i + 1];

                switch (caseSwitch)
                {
                    case "+":
                        retAns = FormulaUtil.Sum(Convert.ToDouble(lstDisplay[i]), Convert.ToDouble(lstDisplay[i + 2]));
                        return retAns;
                    case "-":
                        retAns = FormulaUtil.Difference(Convert.ToDouble(lstDisplay[i]), Convert.ToDouble(lstDisplay[i + 2]));
                        return retAns;
                    case "*":
                        retAns = FormulaUtil.Product(Convert.ToDouble(lstDisplay[i]), Convert.ToDouble(lstDisplay[i + 2]));
                        return retAns;
                    default:
                        retAns = FormulaUtil.Quotient(Convert.ToDouble(lstDisplay[i]), Convert.ToDouble(lstDisplay[i + 2]));
                        return retAns;
                }
            }
            return retAns;
        }
    }
}