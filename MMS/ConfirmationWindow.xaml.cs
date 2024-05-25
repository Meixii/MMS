using System.Windows;


namespace MMS
{
    /// <summary>
    /// Interaction logic for ConfirmationWindow.xaml
    /// </summary>
    public partial class ConfirmationWindow : Window
    {
        public bool Confirmed { get; private set; } = false;

        public ConfirmationWindow()
        {
            InitializeComponent();
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Confirmed = true;
            Close();
        }
    }
}
