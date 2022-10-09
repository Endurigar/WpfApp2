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

namespace WpfApp2
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
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string numbers = textReader.Text;
                Calculator calc = new Calculator();
                string result1 = calc.Starter(numbers);
                textReader.Text = result1;
                textReader.CaretIndex = textReader.Text.Length;
            }
        }
        private void Clicl_Enter(object sender, RoutedEventArgs e)
        {
            string numbers = textReader.Text;
            Calculator calc = new Calculator();
            string result1 = calc.Starter(numbers);
            textReader.Text = result1;
            textReader.CaretIndex = textReader.Text.Length;
        }
        private void Click_0(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '0';
        }
        private void Click_1(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '1';
        }

        private void Click_2(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '2';
        }

        private void Click_3(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '3';
        }

        private void Click_4(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '4';
        }

        private void Click_5(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '5';
        }

        private void Click_6(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '6';
        }
        private void Click_7(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '7';
        }

        private void Click_8(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '8';
        }

        private void Click_9(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '9';
        }

        private void Click_Um(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '*';
        }

        private void Clicl_Del(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '/';
        }

        private void Clicl_Plus(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '+';
        }

        private void Click_Minus(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '-';
        }

        private void Click_Skobka1(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + '(';
        }

        private void Click_Skobka2(object sender, RoutedEventArgs e)
        {
            textReader.Text = textReader.Text + ')';
        }
    }
}
