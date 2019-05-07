using Phoneword.SharedProject.Services.Interfaces;
using Phoneword.SharedProject.Views;
using Xamarin.Forms;

namespace Phoneword.iOS.Services
{
    class NavigationService : INavigationService
    {
        public void NavigateToCallHistory()
        {
            var callHistoryPage = new CallHistoryPage().CreateViewController();
            callHistoryPage.Title = "Call History";

            var navigationController = AppDelegate.Instance.NavigationController;
            navigationController.PushViewController(callHistoryPage, true);
        }
    }
}