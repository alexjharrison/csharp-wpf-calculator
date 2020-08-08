using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calculator;
        public MainWindow()
        {
            this.calculator = new Calculator();
            InitializeComponent();
        }


        private void Operand_Click(object sender, RoutedEventArgs e)
        {
            string operand = getContent(sender);

            if (operand == "+") this.calculator.addOperand(Calculator.Operands.Add);
            if (operand == "-") this.calculator.addOperand(Calculator.Operands.Substract);
            if (operand == "*") this.calculator.addOperand(Calculator.Operands.Multiply);
            if (operand == "/") this.calculator.addOperand(Calculator.Operands.Divide);

            this.text_result.Text = this.calculator.displayNumber;

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.clear();
            this.text_result.Text = this.calculator.displayNumber;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.addPeriod();
            this.text_result.Text = this.calculator.displayNumber;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(getContent(sender));
            this.calculator.addNumber(number);
            this.text_result.Text = this.calculator.displayNumber;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            this.calculator.calculate();
            this.text_result.Text = this.calculator.displayNumber;
        }

        private string getContent(object sender)
        {
            Button btn = sender as Button;
            return btn.Content.ToString();
        }
    }
}
