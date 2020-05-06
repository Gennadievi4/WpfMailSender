using MailSender.lib.Entities;

namespace MailSender
{
    public partial class SenderEditor
    {
        public string NameValue { get => txtName.Text; set => txtName.Text = value; }
        public string AdressValue { get => txtAdress.Text; set => txtAdress.Text = value; }

        public SenderEditor(Sender sender)
        {
            InitializeComponent();
            NameValue = sender.Name;
            AdressValue = sender.Adress;
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
