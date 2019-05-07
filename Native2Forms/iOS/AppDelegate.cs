using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Phoneword.SharedProject.Views;
using Autofac;
using Phoneword.iOS.Services;
using Phoneword.SharedProject;

namespace Phoneword.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public static AppDelegate Instance;
        public static IContainer Container;

        UIWindow _window;
        public UINavigationController NavigationController;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Forms.Init();

            Instance = this;
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                TextColor = UIColor.Black
            });

            BuildIoCContainer();

            using (var scope = Container.BeginLifetimeScope())
            {
                var mainPage = scope.Resolve<PhonewordPage>().CreateViewController();
                mainPage.Title = "Phoneword";

                NavigationController = new UINavigationController(mainPage);
                _window.RootViewController = NavigationController;
                _window.MakeKeyAndVisible();
            }

            return true;
        }

        private void BuildIoCContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<NavigationService>().AsImplementedInterfaces();
            builder.RegisterType<PhoneDialerService>().AsImplementedInterfaces();

            builder.RegisterModule<CommonModule>();

            Container = builder.Build();
        }
    }
}
