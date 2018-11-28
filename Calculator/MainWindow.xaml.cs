using Calculator.Classses;
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


namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            string leftop = ""; // left operand
            string operation = ""; // sign of operation
            string rightop = ""; // right operand


        public MainWindow()
        {

            InitializeComponent();

            // Add handler for all buttons on the grid
            foreach (UIElement c in LayoutRoot.Children)
            {
                if (c is Button)
                {
                    ((Button)c).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // get the button text
            string s = (string)((Button)e.OriginalSource).Content;
            // add it in textbox
            textBox.Text += s;

            int num;
            // trying convert it to number
            bool result = Int32.TryParse(s, out num);

            // if text is number
            if (result == true)
            {
                if (operation == "")
                {
                    leftop += s;
                }
                else
                {
                    rightop += s;
                }
            }
            // if text is not number
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    //textBox.Text += rightop;
                    textBox.Text = rightop;
                    operation = "";
                }
                // clear field
                else if (s == "C")
                {
                    leftop = "";
                    rightop = "";
                    operation = "";
                    textBox.Text = "";
                }
                // get operation
                else
                {
                    if (rightop != "")
                    {
                        //Update_RightOp();
                        leftop = rightop;
                        rightop = "";
                    }
                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            int num1 = Int32.Parse(leftop);
            int num2 = Int32.Parse(rightop);

            Calculate calc = new Calculate();
            rightop = (calc.PerformOperation(operation, num1, num2)).ToString();

        }
    }
}
