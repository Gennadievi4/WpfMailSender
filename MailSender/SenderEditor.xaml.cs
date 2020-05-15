using MailSender.lib.Entities;

namespace MailSender
{
    public partial class SenderEditor
    {
        public string NameValue { get => txtName.Text; set => txtName.Text = value; }
        public string AdressValue { get => txtAdress.Text; set => txtAdress.Text = value; }
        private MainWindow _MainWindow;

        public SenderEditor(Sender sender, MainWindow mainWindow)
        {
            InitializeComponent();
            NameValue = sender.Name;
            AdressValue = sender.Adress;
            _MainWindow = mainWindow;
        }

        private void OnOkButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void OnCancelButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
