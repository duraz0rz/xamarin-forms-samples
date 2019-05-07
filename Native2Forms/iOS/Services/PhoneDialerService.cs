using Foundation;
using Phoneword.SharedProject.Services.Interfaces;
using UIKit;

namespace Phoneword.iOS.Services
{
    public class PhoneDialerService : IPhoneDialerService
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + number));
        }
    }
}