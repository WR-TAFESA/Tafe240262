using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class TitlePage : Page
	{
		public TitlePage()
		{
			this.InitializeComponent();
		}

		private void mathGoToButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage)); // Goes to universal calculator
		}

		private void currencyGoToButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CurrencyConverter)); // Goes to Currency Converter
		}

		private void mortgageGoToButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MortgageCalculator)); // Goes to Mortgage Calculator
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			// TO DO - Close program
		}
	}
}
