using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class CurrencyConverter : Page
	{
		/* Constants for conversion */
		double USD_TO_USD = 1;
		double USD_TO_EUR = 0.85189982;
		double USD_TO_GBP = 0.72872436;
		double USD_TO_INR = 74.257327;

		double EUR_TO_USD = 1.1739732;
		double EUR_TO_EUR = 1;
		double EUR_TO_GBP = 0.8556672;
		double EUR_TO_INR = 87.00755;

		double GBP_TO_USD = 1.371907;
		double GBP_TO_EUR = 1.168692;
		double GBP_TO_GBP = 1;
		double GBP_TO_INR = 101.68635;

		double INR_TO_USD = 0.011492628;
		double INR_TO_EUR = 0.013492774;
		double INR_TO_GBP = 0.0098339397;
		double INR_TO_INR = 1;

		/* Variable for amount entered */
		double amount;
		double conversion;

		/* Initialization */
		public CurrencyConverter()
		{
			this.InitializeComponent();
		}

		/* Code for Convert Currency button */
		private async void conversionButton_Click(object sender, RoutedEventArgs e)
		{
			/* Checks if the Amount text box is empty */
			if (string.IsNullOrEmpty(amountTextBox.Text))
			{
				var dialogMessage = new MessageDialog("The amount field is blank.");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			/* Checks if Amount text box contains a double */
			try
			{
				amount = double.Parse(amountTextBox.Text);
			}
			catch
			{
				var dialogMessage = new MessageDialog("Amount entered is invalid. ");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			/* Checks if From ComboBox is blank */
			if (currencyFromComboBox.SelectedIndex == -1)
			{
				var dialogMessage = new MessageDialog("Please select an option in the From box.");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			/* Checks if To ComboBox is blank */
			if (currencyToComboBox.SelectedIndex == -1)
			{
				var dialogMessage = new MessageDialog("Please select an option in the To box.");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			/* Outputs to amountTextBlock */
			if (currencyFromComboBox.SelectedIndex == 0)
			{
				amountTextBlock.Text = "$" + amount.ToString() + " US Dollars =";
			} else if (currencyFromComboBox.SelectedIndex == 1)
			{
				amountTextBlock.Text = "€" + amount.ToString() + " Euros =";
			} else if (currencyFromComboBox.SelectedIndex == 2)
			{
				amountTextBlock.Text = "£" + amount.ToString() + " British Pounds =";
			} else if (currencyFromComboBox.SelectedIndex == 3)
			{
				amountTextBlock.Text = "₹" + amount.ToString() + " Indian Rupees =";
			} else
			{
				amountTextBlock.Text = "Congrats, you broke it!";
			}

			/* Outputs to conversionTextBlock */
			if (currencyFromComboBox.SelectedIndex == 0) // USD section
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					conversionTextBlock.Text = "$" + (amount * USD_TO_USD) + " US Dollars";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					conversionTextBlock.Text = "€" + (amount * USD_TO_EUR) + " Euros";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					conversionTextBlock.Text = "£" + (amount * USD_TO_GBP) + " British Pounds";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					conversionTextBlock.Text = "₹" + (amount * USD_TO_INR) + " Indian Rupees";
				}
				else
				{
					conversionTextBlock.Text = "Congrats, you broke it!";
				}
			}
			else if (currencyFromComboBox.SelectedIndex == 1) // EUR Section 
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					conversionTextBlock.Text = "$" + (amount * EUR_TO_USD) + " US Dollars";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					conversionTextBlock.Text = "€" + (amount * EUR_TO_EUR) + " Euros";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					conversionTextBlock.Text = "£" + (amount * EUR_TO_GBP) + " British Pounds";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					conversionTextBlock.Text = "₹" + (amount * EUR_TO_INR) + " Indian Rupees";
				}
				else
				{
					conversionTextBlock.Text = "Congrats, you broke it!";
				}
			}
			else if (currencyFromComboBox.SelectedIndex == 2) // GBP Section 
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					conversionTextBlock.Text = "$" + (amount * GBP_TO_USD) + " US Dollars";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					conversionTextBlock.Text = "€" + (amount * GBP_TO_EUR) + " Euros";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					conversionTextBlock.Text = "£" + (amount * GBP_TO_GBP) + " British Pounds";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					conversionTextBlock.Text = "₹" + (amount * GBP_TO_INR) + " Indian Rupees";
				}
				else
				{
					conversionTextBlock.Text = "Congrats, you broke it!";
				}
			}
			else if (currencyFromComboBox.SelectedIndex== 3) // INR section
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					conversionTextBlock.Text = "$" + (amount * INR_TO_USD) + " US Dollars";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					conversionTextBlock.Text = "€" + (amount * INR_TO_EUR) + " Euros";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					conversionTextBlock.Text = "£" + (amount * INR_TO_GBP) + " British Pounds";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					conversionTextBlock.Text = "₹" + (amount * INR_TO_INR) + " Indian Rupees";
				}
				else
				{
					conversionTextBlock.Text = "Congrats, you broke it!";
				}
			}

			/* Outputs to fromTextBlock */
			if (currencyFromComboBox.SelectedIndex == 0) // USD section
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					fromTextBlock.Text = "1 USD = " + USD_TO_USD + " USD";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					fromTextBlock.Text = "1 USD = " + USD_TO_EUR + " EUR";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					fromTextBlock.Text = "1 USD = " + USD_TO_GBP + " GBP";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					fromTextBlock.Text = "1 USD = " + USD_TO_INR + " INR";
				}
				else
				{
					fromTextBlock.Text = "Congrats, you broke it!";
				}
			}
			else if (currencyFromComboBox.SelectedIndex == 1) // EUR Section
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					fromTextBlock.Text = "1 EUR = " + EUR_TO_USD + " USD";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					fromTextBlock.Text = "1 EUR = " + EUR_TO_EUR + " EUR";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					fromTextBlock.Text = "1 EUR = " + EUR_TO_GBP + " GBP";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					fromTextBlock.Text = "1 EUR = " + EUR_TO_INR + " INR";
				}
				else
				{
					fromTextBlock.Text = "Congrats, you broke it!";
				}
			}
			else if (currencyFromComboBox.SelectedIndex == 2) // GBP section
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					fromTextBlock.Text = "1 GBP = " + GBP_TO_USD + " USD";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					fromTextBlock.Text = "1 GBP = " + GBP_TO_EUR + " EUR";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					fromTextBlock.Text = "1 GBP = " + GBP_TO_GBP + " GBP";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					fromTextBlock.Text = "1 GBP = " + GBP_TO_INR + " INR";
				}
				else
				{
					fromTextBlock.Text = "Congrats, you broke it!";
				}
			}
			else if (currencyFromComboBox.SelectedIndex == 3) // INR section
			{
				if (currencyToComboBox.SelectedIndex == 0)
				{
					fromTextBlock.Text = "1 INR = " + INR_TO_USD + " USD";
				}
				else if (currencyToComboBox.SelectedIndex == 1)
				{
					fromTextBlock.Text = "1 INR = " + INR_TO_EUR + " EUR";
				}
				else if (currencyToComboBox.SelectedIndex == 2)
				{
					fromTextBlock.Text = "1 INR = " + INR_TO_GBP + " GBP";
				}
				else if (currencyToComboBox.SelectedIndex == 3)
				{
					fromTextBlock.Text = "1 INR = " + INR_TO_INR + " INR";
				}
				else
				{
					fromTextBlock.Text = "Congrats, you broke it!";
				}
			}
			else
			{
				fromTextBlock.Text = "Congrats, you broke it!";
			}

			/* Outputs to toTextBlock */
			if (currencyToComboBox.SelectedIndex == 0) // USD section
			{
				if (currencyFromComboBox.SelectedIndex == 0)
				{
					toTextBlock.Text = "1 USD = " + USD_TO_USD + " USD";
				} else if (currencyFromComboBox.SelectedIndex == 1)
				{
					toTextBlock.Text = "1 USD = " + USD_TO_EUR + " EUR";
				} else if (currencyFromComboBox.SelectedIndex == 2)
				{
					toTextBlock.Text = "1 USD = " + USD_TO_GBP + " GBP";
				} else if (currencyFromComboBox.SelectedIndex == 3)
				{
					toTextBlock.Text = "1 USD = " + USD_TO_INR + " INR";
				} else
				{
					toTextBlock.Text = "Congrats, you broke it!";
				}
			} else if (currencyToComboBox.SelectedIndex == 1) // EUR Section
			{
				if (currencyFromComboBox.SelectedIndex == 0)
				{
					toTextBlock.Text = "1 EUR = " + EUR_TO_USD + " USD";
				}
				else if (currencyFromComboBox.SelectedIndex == 1)
				{
					toTextBlock.Text = "1 EUR = " + EUR_TO_EUR + " EUR";
				}
				else if (currencyFromComboBox.SelectedIndex == 2)
				{
					toTextBlock.Text = "1 EUR = " + EUR_TO_GBP + " GBP";
				}
				else if (currencyFromComboBox.SelectedIndex == 3)
				{
					toTextBlock.Text = "1 EUR = " + EUR_TO_INR + " INR";
				}
				else
				{
					toTextBlock.Text = "Congrats, you broke it!";
				}
			} else if (currencyToComboBox.SelectedIndex == 2) // GBP section
			{
				if (currencyFromComboBox.SelectedIndex == 0)
				{
					toTextBlock.Text = "1 GBP = " + GBP_TO_USD + " USD";
				}
				else if (currencyFromComboBox.SelectedIndex == 1)
				{
					toTextBlock.Text = "1 GBP = " + GBP_TO_EUR + " EUR";
				}
				else if (currencyFromComboBox.SelectedIndex == 2)
				{
					toTextBlock.Text = "1 GBP = " + GBP_TO_GBP + " GBP";
				}
				else if (currencyFromComboBox.SelectedIndex == 3)
				{
					toTextBlock.Text = "1 GBP = " + GBP_TO_INR + " INR";
				}
				else
				{
					toTextBlock.Text = "Congrats, you broke it!";
				}
			} else if (currencyToComboBox.SelectedIndex == 3) // INR section
			{
				if (currencyFromComboBox.SelectedIndex == 0)
				{
					toTextBlock.Text = "1 INR = " + INR_TO_USD + " USD";
				}
				else if (currencyFromComboBox.SelectedIndex == 1)
				{
					toTextBlock.Text = "1 INR = " + INR_TO_EUR + " EUR";
				}
				else if (currencyFromComboBox.SelectedIndex == 2)
				{
					toTextBlock.Text = "1 INR = " + INR_TO_GBP + " GBP";
				}
				else if (currencyFromComboBox.SelectedIndex == 3)
				{
					toTextBlock.Text = "1 INR = " + INR_TO_INR + " INR";
				}
				else
				{
					toTextBlock.Text = "Congrats, you broke it!";
				}
			} else
			{
				toTextBlock.Text = "Congrats, you broke it!";
			}
		}

		/* Code for Exit Button */
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(TitlePage)); // Goes back to Title Page
		}


	}
}
