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


        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!hasDecimal)
            {
                if (isLastButtonOperator) { resultBox.Text = ""; isLastButtonOperator = false; }
                resultBox.Text += ((Button)sender).Text;
                hasDecimal = true;
            }
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
