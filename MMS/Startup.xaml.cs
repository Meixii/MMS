using MMS.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace MMS
{
    public partial class Startup : Window
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _); // Allow only numbers
        }

        private void Digit_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = sender as TextBox;

            if (textbox.Text.Length > 0)
            {
                textbox.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#B8860B"); // Change to brown when filled
                textbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
            else
            {
                int tag = int.Parse(textbox.Tag.ToString());
                if (tag > 1)
                {
                    // Move focus to the previous textbox if empty
                    TextBox previousTextBox = FindName($"digit{tag - 1}") as TextBox;
                    previousTextBox.Focus();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            ConfirmationWindow confirmationWindow = new ConfirmationWindow();
            confirmationWindow.Owner = this;
            confirmationWindow.ShowDialog();

            if (confirmationWindow.Confirmed)
            {
                Application.Current.Shutdown(); // Exit if confirmed
            }
        }

    }


}