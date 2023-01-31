using AutoCompleteWindowsReference.Interfaces;
using Xamarin.Forms;

namespace AutoCompleteWindowsReference.Services
{
    public class NavigationService : INavigationService
    {
        private readonly INavigation navigation;

        public NavigationService(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public INavigation Current => navigation;
    }
}
