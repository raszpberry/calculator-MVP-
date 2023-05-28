using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_MVP
{
    public class CalcPresenter
    {
        ICalcView _iCalcView = null;
        bool bClearDigit { get; set; }
        bool bDelIsPressed { get; set; }
        private double previousResult = 0;


        public CalcPresenter(ICalcView iCalcView)
        {
            _iCalcView = iCalcView;
            SetDisplayValues();
            _iCalcView.EqualsClick = new EventHandler(Calculate);
            _iCalcView.OperationClick = new EventHandler(SetOperationValue);

            _iCalcView.NumPressed += new KeyPressEventHandler(KeyPressedHandler);
            _iCalcView.DeletePressed += new KeyEventHandler(DeletePressed);

            _iCalcView.ScrollTextBoxToEnd();
        }

        //Handles delete
        private void DeletePressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _iCalcView.TextDisplay = "";
                _iCalcView.TextInput = "0";
                bDelIsPressed = true;
            }
            _iCalcView.ScrollTextBoxToEnd();
        }

        private void KeyPressedHandler(object sender, KeyPressEventArgs e)
        {
          
            //Handle nums input
            if (char.IsDigit(e.KeyChar))
            {
                string initialVal = _iCalcView.TextInput;
                if (bClearDigit)
                {
                    _iCalcView.TextInput = $"{e.KeyChar}";
                }
                else
                {
                    if (initialVal.Length == 1 && initialVal == "0")
                    {
                        _iCalcView.TextInput = ConvertUtil.ConvertStrToD(initialVal + $"{e.KeyChar}").ToString();
                    }
                    else
                    {
                        _iCalcView.TextInput = initialVal + $"{e.KeyChar}";
                    }
                }

                _iCalcView.AutoAdjustFontSizeInc();
                bClearDigit = false;
            }

            //Handle Operation
            if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '/' || e.KeyChar == '*')
            {
                string initialValue = _iCalcView.TextInput;

                _iCalcView.TextDisplay = initialValue + " " + e.KeyChar;
                _iCalcView.TextInput = initialValue;

                bClearDigit = true;
            }

            //Handle Calculation
            if (e.KeyChar == '=' || e.KeyChar == (char)Keys.Enter)
            {
                CalcModel calcModdata = _iCalcView.GetCalcData();
                List<string> lstInputStr = null;

                lstInputStr = ModifiedInputString(calcModdata.InputString);

                if (lstInputStr.Count == 3)
                {
                   CalculatorServices calcServ = new CalculatorServices();
                   _iCalcView.TextDisplay = $"{lstInputStr[0]} {lstInputStr[1]}";
                   _iCalcView.TextInput = calcServ.Calculate(lstInputStr).ToString();
                   
                   bClearDigit = true;
                }

                _iCalcView.AutoAdjustFontSizeInc();
            }

            //Backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                string initialValue = _iCalcView.TextInput;
                string removeStr = initialValue.Remove(initialValue.Length - 1, 1);
                _iCalcView.TextInput = (removeStr == "") ? "0" : removeStr;
                _iCalcView.TextDisplay = "";
                _iCalcView.AutoAdjustFontSizeDec();
            }

            //Reset clear/delete
            if (bDelIsPressed)
            {
                bDelIsPressed = false;
            }

            _iCalcView.ScrollTextBoxToEnd();
            _iCalcView.SetTextBoxFocus();
        }

        public void SetDisplayValues()
        {
            _iCalcView.TextDisplay = "";
            _iCalcView.TextInput = "0";
        }

        //Handle calculation (button)
        private void Calculate(object sender, EventArgs e)
        {
            CalcModel calcModdata = _iCalcView.GetCalcData();
            List<string> lstInputStr = ModifiedInputString(calcModdata.InputString);

            if (lstInputStr.Count == 3)
            {
                CalculatorServices calcServ = new CalculatorServices();
                double result = calcServ.Calculate(lstInputStr);

                _iCalcView.TextDisplay = $"{lstInputStr[0]} {lstInputStr[1]}";
                _iCalcView.TextInput = result.ToString();

                previousResult = result; // Update the previous result

                bClearDigit = true;
            }
        }

        //Get operation value (button)
        private void SetOperationValue(object sender, EventArgs e)
        {
            _iCalcView.SetTextBoxFocus();
            string initialValue = _iCalcView.TextInput;

            _iCalcView.TextDisplay = initialValue + " " + ((Button)sender).Text;
            _iCalcView.TextInput = initialValue;

            
            bClearDigit = true;
            
        }

        //Turns input string into list for handling calculation
        private List<string> ModifiedInputString(string value)
        {
            List<string> retStr = value.Split(' ').ToList();

            if (retStr.Count == 2)
            {
                retStr = value.Split('+', '-', '/', '*').ToList();
                retStr.Add(retStr[0]);
            }
            return retStr;
        }
    }
}
