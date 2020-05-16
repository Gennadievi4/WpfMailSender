using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infrastructure.Services;
using MailSender.Infrastructure.Services.Interfaces;
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
            services.Register<IMaleStore, MailstStoreInMemory>();
            services.Register<ISenderStore, SenderstStoreInMemory>();
            services.Register<IServerStore, ServerstStoreInMemory>();
            services.Register<ISenderEditor, WindowSenderEditor>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static void Cleanup()
        {

        }
    }
}