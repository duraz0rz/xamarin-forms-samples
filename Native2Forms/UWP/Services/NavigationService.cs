using Phoneword.SharedProject.Services.Interfaces;
using Phoneword.SharedProject.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

namespace Phoneword.UWP.Services
{
    class NavigationService : INavigationService
    {
        public void NavigateToCallHistory()
        {
            var currentContent = Window.Current.Content as Frame;
            currentContent.Navigate(new CallHistoryPage());
        }
    }
}
