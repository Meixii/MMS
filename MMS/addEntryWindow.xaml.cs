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
    /// Interaction logic for addEntryWindow.xaml
    /// </summary>
    public partial class addEntryWindow : Window 
    {
        public addEntryWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Close the AddEntryView window
        }


        private void AddEntryWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Reopen MainWindow when AddEntryView closes
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
