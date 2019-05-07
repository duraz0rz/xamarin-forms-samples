using Phoneword.SharedProject.Models;
using Phoneword.SharedProject.Services;
using Phoneword.SharedProject.Services.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Phoneword.SharedProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhonewordPage : ContentPage
    {
        string _translatedNumber;
        private readonly IPhoneDialerService _phoneDialerService;
        private readonly INavigationService _navigationService;

        public PhonewordPage(IPhoneDialerService phoneDialerService, INavigationService navigationService)
        {
            InitializeComponent();
            _phoneDialerService = phoneDialerService;
            _navigationService = navigationService;
        }

        void OnTranslate(object sender, EventArgs e)
        {
            _translatedNumber = PhonewordTranslatorService.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrWhiteSpace(_translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + _translatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            if (await DisplayAlert(
                    "Dial a Number",
                    "Would you like to call " + _translatedNumber + "?",
                    "Yes",
                    "No"))
            {
                AppModel.PhoneNumbers.Add(_translatedNumber);
                callHistoryButton.IsEnabled = true;
                _phoneDialerService.Dial(_translatedNumber);
            }
        }

        void OnCallHistory(object sender, EventArgs e)
        {
            _navigationService.NavigateToCallHistory();
        }
    }
}
