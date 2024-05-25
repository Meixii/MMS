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
using System.Windows.Shapes;

namespace MMS
{
    /// <summary>
    /// Interaction logic for signin.xaml
    /// </summary>
    public partial class signin : Window
    {
        public signin()
        {
            InitializeComponent();
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
