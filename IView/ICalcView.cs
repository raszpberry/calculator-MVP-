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

        void SetTextBoxFocus();
        void ScrollTextBoxToEnd();
        void AutoAdjustFontSizeInc();
        void AutoAdjustFontSizeDec();
    }

}
