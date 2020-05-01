using System.ComponentModel;
using System.Windows;

namespace TestWPF
{
    public partial class ErrorWindow : Window, INotifyPropertyChanged
    {
        private string message;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Message
        {
            get => message;
            set
            {
                if (message != null) return;
                message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ErrorWindow()
        {
            Owner = App.Current.MainWindow;
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
