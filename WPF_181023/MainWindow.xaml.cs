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

namespace WPF_181023
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string input = string.Empty;
		private string operand1 = string.Empty;
		private string operand2 = string.Empty;
		private char operation;
		private double result = 0.0;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			if (button.Content.ToString() != "=") {
				input += button.Content.ToString();
				txtDisplay.Text = input;
			} else {
				operand2 = input;
				double num1, num2;
				double.TryParse(operand1, out num1);
				double.TryParse(operand2, out num2);

				switch (operation) {
					case '+': result = num1 + num2; break;
					case '-': result = num1 - num2; break;
					case '*': result = num1 * num2; break;
					case '/': result = num1 / num2; break;
				}
				txtDisplay.Text = result.ToString();
				operand1 = result.ToString();
				input = string.Empty;
				operand2 = string.Empty;
			}
		}

		private void Operation_Click(object sender, RoutedEventArgs e)
		{
			Button button = (Button)sender;
			operation = Convert.ToChar(button.Content.ToString());
			operand1 = input;
			input = string.Empty;
		}

		private void Clear_Click(object sender, RoutedEventArgs e)
		{
			txtDisplay.Text = string.Empty;
			input = string.Empty;
			operand1 = string.Empty;
			operand2 = string.Empty;
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key >= Key.D0 && e.Key <= Key.D9) {
				input += e.Key.ToString().Last();
				txtDisplay.Text = input;
			} else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) {
				input += (e.Key - Key.NumPad0).ToString();
				txtDisplay.Text = input;
			}
		}
	}
}
