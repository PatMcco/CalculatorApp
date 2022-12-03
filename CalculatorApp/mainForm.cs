using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class mainForm : Form
    {
        string firstNumString = "0";
        string secondNumString = "0";
        string operation = "";
        bool isLastButtonOperator = false;
        bool hasDecimal = false;
        float firstNonStringNum = 0;
        float secondNonStringNum = 0;
        string modifiedString = null;

        public mainForm()
        {
            InitializeComponent();
        }

        private void btn_Num_Click(object sender, EventArgs e)
        {
            if (isLastButtonOperator || resultBox.Text == "0")
            {
                //clears the box to prevent bad input
                resultBox.Text = "";
                secondNonStringNum = 0;
                secondNumString = "0";
                isLastButtonOperator = false;


            }

            resultBox.Text += ((Button)sender).Text;
        }


        private void btnEquals_Click(object sender, EventArgs e)
        {
            float result = 0;
            secondNumString = resultBox.Text;
            firstNonStringNum = float.Parse(firstNumString);
            secondNonStringNum = float.Parse(secondNumString);
            //divide by zero check
            if((firstNonStringNum == 0) || (secondNonStringNum == 0) && (operation == "/"))
            {
                resetCalc();
            }
            else
                switch (operation)
                {
                    case "":
                        break;
                    case "+":
                        result = firstNonStringNum + secondNonStringNum;
                        break;
                    case "-":
                        result = firstNonStringNum - secondNonStringNum;
                        break;
                    case "X":
                        result = firstNonStringNum * secondNonStringNum;
                        break;
                    case "/":
                        result = firstNonStringNum / secondNonStringNum;
                        break;
                }

            if (operation != "")
            {
                resultBox.Text = result.ToString();
                firstNumString = result.ToString();
                secondNonStringNum = 0;
                secondNumString = "0";
                isLastButtonOperator = false;
                operation = "";

            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if ((operation == "") && (resultBox.Text != ""))
            {
                firstNumString = resultBox.Text;
                resultBox.Text = "-";
                operation = "-";
                isLastButtonOperator = true;
                hasDecimal = false;
            }
            else
            {
                return;
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if ((operation == "") && (resultBox.Text != ""))
            {
                firstNumString = resultBox.Text;
                resultBox.Text = "X";
                operation = "X";
                isLastButtonOperator = true;
                hasDecimal = false;
            }
            else
            {
                return;
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if ((operation == "") && (resultBox.Text != ""))
            {
                firstNumString = resultBox.Text;
                resultBox.Text = "/";
                operation = "/";
                isLastButtonOperator = true;
                hasDecimal = false;
            }
            else
            {
                return;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if ((operation == "") && (resultBox.Text != ""))
            {
                firstNumString = resultBox.Text;
                resultBox.Text = "+";
                operation = "+";
                isLastButtonOperator = true;
                hasDecimal = false;
            }
            else
            {
                return;
            }
        }

        private void btnPosNeg_Click(object sender, EventArgs e)
        {
            modifiedString = resultBox.Text;
            char firstChar = modifiedString.First();
            if (firstChar == '-')
            {
                modifiedString = modifiedString.TrimStart('-');
                resultBox.Text = modifiedString;
            }
            else
            {
                modifiedString = modifiedString.Insert(0, "-");
                resultBox.Text = modifiedString;
            }
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!hasDecimal)
            {
                if (isLastButtonOperator) { resultBox.Text = ""; isLastButtonOperator = false; }
                resultBox.Text += ((Button)sender).Text;
                hasDecimal = true;
            }
        }

        private void btnbackSpace_Click(object sender, EventArgs e)
        {
            //make sure resultbox is not empty
            if(resultBox.Text != "")
            {
                //get last char in string
                modifiedString = resultBox.Text;
                char lastChar = resultBox.Text.Last();
                //if it's a decimal, remove decimal and set hasDecimal to false
                if (resultBox.Text.Last() == '.')
                {
                    modifiedString = resultBox.Text.Remove(resultBox.Text.Length - 1, 1);
                    hasDecimal = false;
                    resultBox.Text = modifiedString;
                }
                //if its not a decimal but is numeric, remove the number
                else if (char.IsNumber(lastChar))
                {
                    modifiedString = resultBox.Text.Remove(resultBox.Text.Length - 1, 1);
                    resultBox.Text = modifiedString;
                }
                //if none of the above, it's a negative symbol, remove it.
                else
                {
                    modifiedString = resultBox.Text.Remove(resultBox.Text.Length - 1, 1);
                    resultBox.Text = modifiedString;
                }
            }
        }

        private void btnclearEntry_Click(object sender, EventArgs e)
        {//clears the last entry since pressing an operator, allows decimals again
            if (resultBox.Text != "")
            {
                resultBox.Text = "";
                if (hasDecimal) { hasDecimal = false; };
            }
        }

        private void btnglobalClear_Click(object sender, EventArgs e)
        {
            resetCalc();
        }
        //return calculator to empty state
        private void resetCalc()
        {
            firstNonStringNum = 0;
            secondNonStringNum = 0;
            firstNumString = "0";
            secondNumString = "0";
            operation = "";
            isLastButtonOperator = false;
            resultBox.Text = "";
            hasDecimal = false;
        }
    }
}
