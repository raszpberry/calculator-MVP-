using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator_MVP
{
    public interface ICalcView
    {
        string TextDisplay { get; set; }
        string TextInput { get; set; }
        CalcModel GetCalcData();
        EventHandler OperationClick { set; }
        EventHandler EqualsClick { set; }

        event KeyPressEventHandler NumPressed;
        event KeyEventHandler DeletePressed;

        //Keeps the focus to textbox and places the textbox cursor to the end
        void SetTextBoxFocus();
        void ScrollTextBoxToEnd();

        //Handling font size change when the text input length exceeds textbox width
        void AutoAdjustFontSizeInc();
        void AutoAdjustFontSizeDec();
    }

}
