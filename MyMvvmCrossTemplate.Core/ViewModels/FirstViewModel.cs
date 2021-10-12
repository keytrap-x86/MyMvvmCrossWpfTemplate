using Microsoft.Extensions.Logging;

using MvvmCross.ViewModels;

namespace MyMvvmCrossTemplate.Core
{
    public class FirstViewModel : MvxViewModel
    {

        public FirstViewModel(ILogger<FirstViewModel> logger)
        {
            _logger = logger;
        }


        #region Private fields

        private readonly ILogger<FirstViewModel> _logger;

        #endregion
    }
}
