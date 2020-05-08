using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Services;
using MailSender.lib.Services.Interfaces;

namespace MailSender.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var services = SimpleIoc.Default;

            services.Register<MainViewModel>();
            services.Register<IRecipientManager, RecipientsManager>();
            services.Register<IRecipientStore, RecipientStoreInMemory>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static void Cleanup()
        {

        }
    }
}