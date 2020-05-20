using Microsoft.Extensions.Configuration;
using System;

namespace MailSender
{
    public partial class App
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
