using Microsoft.Extensions.Configuration;

using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

using System;

namespace MyMvvmCrossTemplate.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            // Register all classes that are ending with "Service" as interfaces
            // This is the automatic way of doing :
            //      Mvx.IoCProvider.ConstructAndRegisterSingleton<ICryptoService, CryptoService>();
            //      Mvx.IoCProvider.ConstructAndRegisterSingleton<IAccountService, AccountService>();
            //      etc..
            // This does all of it for you
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();


            // Create configuration from appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
               .AddJsonFile("AppSettings.json", true, true)
               .Build();

            // Register app settings
            Mvx.IoCProvider.RegisterSingleton(configuration);


            // Register db context
            //Mvx.IoCProvider.RegisterSingleton(new MyDbContext());

            // Define the view model that will be injected first
            // and whos corresponding view would be displayed
            RegisterCustomAppStart<AppStart>();
        }
    }
}
