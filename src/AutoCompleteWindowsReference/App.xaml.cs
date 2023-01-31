using AutoCompleteWindowsReference.Services;
using AutoCompleteWindowsReference.ViewModels;
using AutoCompleteWindowsReference.Views;
using Xamarin.Forms;

namespace AutoCompleteWindowsReference
{
    public partial class App : Application
    {
        public App()
        {
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
