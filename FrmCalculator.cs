using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Calculator_MVP
{
    public partial class FrmCalculator : Form, ICalcView
    {
        CalcPresenter _calcPresenter = null;

        public FrmCalculator()
        {
            InitializeComponent();
            _calcPresenter = new CalcPresenter(this);

        }

        public void ScrollTextBoxToEnd()
        {
            //tbInput.SelectionLength = 0;
            tbInput.SelectionStart = tbInput.Text.Length;
            tbInput.ScrollToCaret();
        }

        public void AutoAdjustFontSizeInc()
        {
            using (Graphics graphics = tbInput.CreateGraphics())
            {
                SizeF textSize = graphics.MeasureString(tbInput.Text, tbInput.Font);
                while (textSize.Width > tbInput.ClientSize.Width && tbInput.Font.Size > 1)
                {
                    tbInput.Font = new Font(tbInput.Font.FontFamily, tbInput.Font.Size - 0.5f, tbInput.Font.Style);
                    textSize = graphics.MeasureString(tbInput.Text, tbInput.Font);
                }
            }
        }
        public void AutoAdjustFontSizeDec()
        {
            using (Graphics graphics = tbInput.CreateGraphics())
            {
                SizeF textSize = graphics.MeasureString(tbInput.Text, tbInput.Font);
                while (textSize.Width <= tbInput.ClientSize.Width && tbInput.Font.Size < 18)
                {
                    tbInput.Font = new Font(tbInput.Font.FontFamily, tbInput.Font.Size + 0.5f, tbInput.Font.Style);
                    textSize = graphics.MeasureString(tbInput.Text, tbInput.Font);
                }
            }
        }
        public void SetTextBoxFocus()
        {
            tbInput.Focus();
        }
        public CalcModel GetCalcData()
        {
            return new CalcModel { InputString = TextDisplay + " " + TextInput };
        }

        public event KeyPressEventHandler NumPressed
        {
            add { tbInput.KeyPress += value; }
            remove { tbInput.KeyPress -= value; }
        }
        public event KeyEventHandler DeletePressed
        {
            add { tbInput.KeyDown += value; }
            remove { tbInput.KeyDown -= value; }
        }

        public string TextInput
        {
            get { return tbInput.Text; }
            set { tbInput.Text = value; }
        }

        public string TextDisplay
        {
            get { return lblDisplay.Text; }
            set { lblDisplay.Text = value; }
        }

        public EventHandler EqualsClick
        {
            set { btnEquals.Click += value; }
        }

        public EventHandler OperationClick
        {
            set
            {
                btnDivide.Click += value;
                btnMultiply.Click += value;
                btnMinus.Click += value;
                btnPlus.Click += value;
            }
        }

    }
    
}
