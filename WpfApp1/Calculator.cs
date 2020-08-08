using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace WpfApp1
{
    class Calculator
    {
        public string displayNumber;
        public enum Operands { Add, Substract, Multiply, Divide }

        private Nullable<Operands> operand;
        private Nullable<double> firstNumber;
        private Nullable<double> secondNumber;
        private bool decimalPressed;

        public Calculator()
        {
            this.displayNumber = "";
            this.firstNumber = 0;
            this.decimalPressed = false;
            this.secondNumber = 0;
            this.operand = null;
        }

        public void addNumber(double newNumber)
        {
            bool isFirstNumber = this.operand == null;

            if (isFirstNumber && !this.decimalPressed)
            {
                this.firstNumber = (this.firstNumber * 10) + newNumber;
                this.displayNumber = this.firstNumber.ToString();
            } 

            else if (isFirstNumber && this.decimalPressed)
            {
                int decimals = this.getDecimals((double)this.firstNumber);
                this.firstNumber += newNumber * Math.Pow(10, -decimals);
                this.firstNumber = Math.Round((double)this.firstNumber, decimals + 2);
                this.displayNumber = this.firstNumber.ToString();
            }

            else if (!isFirstNumber && !this.decimalPressed)
            {
                this.secondNumber = (this.secondNumber * 10) + newNumber;
                this.displayNumber = this.secondNumber.ToString();
            }

            else if (!isFirstNumber && this.decimalPressed)
            {
                int decimals = this.getDecimals((double)this.secondNumber);
                this.secondNumber += newNumber * Math.Pow(10, -decimals);
                this.secondNumber= Math.Round((double)this.secondNumber, decimals + 2);
                this.displayNumber = this.secondNumber.ToString();
            }
            else
            {
                this.displayNumber = "Broken";
            }
            Console.WriteLine("stop");
        }

        public void addOperand(Operands operand)
        {
            this.operand = operand;
            this.decimalPressed = false;
        }

        public void addPeriod()
        {
            this.decimalPressed = true;
        }

        public void calculate()
        {
            if (this.firstNumber == null || this.secondNumber == null) return;
            double result = 0;
            switch (this.operand) 
            {
                case Operands.Add:
                    result = (double)(this.firstNumber + this.secondNumber);
                    break;
                case Operands.Substract:
                    result = (double)(this.firstNumber - this.secondNumber);
                    break;
                case Operands.Multiply:
                    result = (double)(this.firstNumber * this.secondNumber);
                    break;
                case Operands.Divide:
                    result = (double)(this.firstNumber / this.secondNumber);
                    break;
            }
            this.displayNumber = result.ToString();
            this.reset();
        }

        public void reset()
        {
            this.firstNumber = 0;
            this.secondNumber = 0;
            this.operand = null;
            this.decimalPressed = false;
        }

        public void clear()
        {
            this.reset();
            this.displayNumber = "";
        }

        private int getDecimals(double argument)
        {
            if (!argument.ToString().Contains('.')) return 1;
            return argument.ToString().Split(".")[1].Length + 1;
        }
    }
}
