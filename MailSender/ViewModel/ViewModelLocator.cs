using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using MailSender.Infrastructure.Services;
using MailSender.Infrastructure.Services.Interfaces;
using MailSender.lib.Data.EF;
using MailSender.lib.Services;
using MailSender.lib.Services.EF;
using MailSender.lib.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
            services.Register<IRecipientStore, RecipientStoreEF>();
            services.Register<IMaleStore, MailstStoreInMemory>();
            services.Register<ISenderStore, SenderstStoreInMemory>();
            services.Register<IServerStore, ServerstStoreInMemory>();
            services.Register<ISenderEditor, WindowSenderEditor>();
            services.Register<MailSenderDB>();
            services.Register(() => new DbContextOptionsBuilder<MailSenderDB>().UseSqlServer(App.Configuration.GetConnectionString("DefaultConnection")).Options);
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static void Cleanup()
        {

        }
    }
}