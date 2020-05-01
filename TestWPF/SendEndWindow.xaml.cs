using System.Windows;

namespace TestWPF
{
    public partial class SendEndWindow : Window
    {
        public SendEndWindow()
        {
            Owner = App.Current.MainWindow;
            InitializeComponent();
        }
        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
    }
}
