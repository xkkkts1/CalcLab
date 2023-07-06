using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace sillycalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String op;
        String num1;

        private double memory;
        public bool memFlag;

        public MainWindow()
        {
            InitializeComponent();

            MemoryClear.IsEnabled = false;
            MemoryRead.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (TxtResult.Text == "0" || memFlag == true)
            {
                TxtResult.Text = "";
                memFlag = false;
            }
            TxtResult.Text += btn.Content.ToString();
        }

        private void TxtResult_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OP_Click(object sender, RoutedEventArgs e)
        {
            if(TxtResult.Text=="0" || TxtResult.Text == "")
            {
                TxtResult.Text="-";
            }
            else
            {
                Button btn = (Button)sender;
                op = btn.Content.ToString();
                num1 = TxtResult.Text;
                TxtResult.Text = "";
            }   
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (op == "+")
                {
                    TxtResult.Text = (Convert.ToDouble(TxtResult.Text) + Convert.ToDouble(num1)).ToString();
                }
                if (op == "-")
                {
                    TxtResult.Text = (Convert.ToDouble(num1) - Convert.ToDouble(TxtResult.Text)).ToString();
                }
                if (op == "*")
                {
                    TxtResult.Text = (Convert.ToDouble(TxtResult.Text) * Convert.ToDouble(num1)).ToString();
                }
                if (op == "/")
                {
                    TxtResult.Text = (Convert.ToDouble(num1) / Convert.ToDouble(TxtResult.Text)).ToString();
                }
                if (op == "%")
                {
                    TxtResult.Text = (Convert.ToDouble(num1) / 100 * Convert.ToDouble(TxtResult.Text)).ToString();
                }
                op = "";
            }
            catch (Exception ex)
            {
                SoundPlayer player1 = new SoundPlayer(@"C:\Users\Xiaomi\Downloads\vine-boom.wav");
                player1.Load();
                player1.Play();
                MessageBox.Show(ex.Message);
                TxtResult.Text = "0";
            }
        }

            private void CE_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = "0";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if(TxtResult.Text.Length - 1 == 0)
            {
                TxtResult.Text = "0";
            }
            else
            {
                TxtResult.Text = TxtResult.Text.Substring(0,TxtResult.Text.Length - 1);
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = "0";
        }

        private void PlusMinus_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = (-Convert.ToDouble(TxtResult.Text)).ToString();
        }

        private void DivideX_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = (1/ Convert.ToDouble(TxtResult.Text)).ToString();
        }

        private void Sqrt2_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = (Convert.ToDouble(TxtResult.Text) * Convert.ToDouble(TxtResult.Text)).ToString();
        }

        private void SqrtX_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = (Math.Sqrt(Convert.ToDouble(TxtResult.Text)).ToString());
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            if (!TxtResult.Text.Contains(","))
            {
                TxtResult.Text += ",";
            }
        }

        private void MemoryClear_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = "0";
            memory = 0;
            MemoryClear.IsEnabled = false;
            MemoryRead.IsEnabled = false;
        }

        private void MemoryRead_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = memory.ToString();
            memFlag = true;
        }

        private void MemoryPlus_Click(object sender, RoutedEventArgs e)
        {
            memory += Double.Parse(TxtResult.Text);
        }

        private void MemorySave_Click(object sender, RoutedEventArgs e)
        {
            memory = Double.Parse(TxtResult.Text);
            MemoryClear.IsEnabled = true;
            MemoryRead.IsEnabled = true;
            memFlag = true;
        }

        private void MemoryMinus_Click(object sender, RoutedEventArgs e)
        {
            memory -= Double.Parse(TxtResult.Text);
        }
    }
}
