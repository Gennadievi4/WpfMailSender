using MailSender.Infrastructure.Services.Interfaces;
using MailSender.lib.Entities;
using System.Windows;

namespace MailSender.Infrastructure.Services
{
    public class WindowSenderEditor : ISenderEditor
    {
        public void Edit(Sender Sender)
        {
            var current_main_window = (MainWindow)Application.Current.MainWindow;
            var editor = new SenderEditor(Sender, current_main_window);
            editor.Owner = current_main_window;

            if (editor.ShowDialog() != true) return;

            Sender.Name = editor.NameValue;
            Sender.Adress = editor.AdressValue;
        }
    }
}