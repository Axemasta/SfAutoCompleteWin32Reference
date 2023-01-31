using AutoCompleteWindowsReference.Services;
using AutoCompleteWindowsReference.ViewModels;
using AutoCompleteWindowsReference.Views;
using Syncfusion.Licensing;
using Xamarin.Forms;

namespace AutoCompleteWindowsReference
{
    public partial class App : Application
    {
        public App()
        {
            SyncfusionLicenseProvider.RegisterLicense(Constants.SyncFusionLicenseKey);

            InitializeComponent();

            var mainPage = new MainPage();

            mainPage.BindingContext = new MainViewModel(new MyService())
            {
                Navigation = mainPage.Navigation,
            };

            MainPage = new NavigationPage(mainPage);
        }
    }
}
