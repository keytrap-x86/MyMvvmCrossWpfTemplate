
using Microsoft.Extensions.Logging;

using MvvmCross.Navigation;
using MvvmCross.ViewModels;

using System.Threading.Tasks;

namespace MyMvvmCrossTemplate.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly ILogger<AppStart> _logger;

        public AppStart(
            IMvxApplication application,
            IMvxNavigationService navigationService,
            ILogger<AppStart> logger)
            : base(application, navigationService)
        {
            _logger = logger;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            try
            {
                // You need to run Task sync otherwise code would continue before completing.
                NavigationService.Navigate<FirstViewModel>().GetAwaiter().GetResult();
            }
            catch (System.Exception exception)
            {
                _logger.LogError("{ex}", exception);
            }

            return Task.CompletedTask;
        }
    }
}