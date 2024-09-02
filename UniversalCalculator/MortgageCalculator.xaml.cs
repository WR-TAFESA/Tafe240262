using System;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
	/// A page that calculates mortgage repayments.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private async void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				// Get values from text boxes
				double principal;
				int years;
				int months;
				double annualInterestRate;

				// Check if inputs are valid
				bool isPrincipalValid = double.TryParse(PrincipalTextBox.Text, out principal);
				bool isYearsValid = int.TryParse(YearsTextBox.Text, out years);
				bool isMonthsValid = int.TryParse(MonthsTextBox.Text, out months);
				bool isInterestRateValid = double.TryParse(InterestRateTextBox.Text, out annualInterestRate);

				if (!isPrincipalValid || !isYearsValid || !isMonthsValid || !isInterestRateValid)
				{
					// Show error message if inputs are invalid
					var errorDialog = new ContentDialog
					{
						Title = "Input Error",
						Content = "Please enter valid numbers in all fields.",
						CloseButtonText = "OK"
					};
					await errorDialog.ShowAsync();
					return;
				}

				// Check for positive values
				if (principal <= 0 || years < 0 || months < 0 || annualInterestRate < 0)
				{
					// Show error message if inputs are not positive
					var errorDialog = new ContentDialog
					{
						Title = "Input Error",
						Content = "Please enter positive numbers.",
						CloseButtonText = "OK"
					};
					await errorDialog.ShowAsync();
					return;
				}

				// Calculate total months and monthly interest rate
				int totalMonths = (years * 12) + months;
				double monthlyInterestRate = (annualInterestRate / 12) / 100;

				// Calculate monthly repayment
				double numerator = principal * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, totalMonths);
				double denominator = Math.Pow(1 + monthlyInterestRate, totalMonths) - 1;
				double monthlyRepayment = numerator / denominator;

				// Display results
				MonthlyInterestRateTextBox.Text = (monthlyInterestRate * 100).ToString("P2");
				MonthlyRepaymentTextBox.Text = monthlyRepayment.ToString("C");
			}
			catch (Exception ex)
			{
				// Show general error message
				var errorDialog = new ContentDialog
				{
					Title = "Error",
					Content = "An error occurred: " + ex.Message,
					CloseButtonText = "OK"
				};
				await errorDialog.ShowAsync();
			}
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			// Navigate to Title Page (Main Page which shows the Currency Calculator and Mortgage Calculator)
			Frame.Navigate(typeof(TitlePage));
		}
	}
}