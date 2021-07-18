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


namespace Project2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Employee
        {
            public string fName, lName;
            public int age;
            public double standardHours = 40;
            public double overtimeRate = 1.5;
            public double workHours;
            public double payRate;

            public Employee(string fName,string lName, int age, double payRate, double workHours )
            {
                this.fName = fName;
                this.lName = lName;
                this.age = age;
                this.payRate = payRate;
                this.workHours = workHours;
             

            }

            public double Calculate()
            {
                double totalPay;

                if(workHours < 40)
                {
                    totalPay = workHours * payRate;
                }
                else
                {
                    double regularPay = workHours * payRate;
                    double overtimePay = (workHours - standardHours) * (payRate * overtimeRate);
                    totalPay = regularPay + overtimePay;
                }

                return totalPay;
                
            }
        }

        private void calculatePay(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee worker = new Employee(fnameBox.Text, lnameBox.Text, Convert.ToInt32(ageBox.Text),
                    Convert.ToDouble(payrateBox.Text), Convert.ToDouble(hourBox.Text));

                MessageBox.Show(worker.fName + " " + worker.lName + ", Age: " +
                    worker.age + ", Weekly pay is " + worker.Calculate().ToString());

            }
            catch(FormatException)
            {
                MessageBox.Show("Error, invalid input, please try again");
            }

        }
    }
}
