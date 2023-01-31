using System;
using System.Threading.Tasks;
using AutoCompleteWindowsReference.Interfaces;
using AutoCompleteWindowsReference.Views;
using MvvmHelpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AutoCompleteWindowsReference.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMyService myService;

        public IAsyncCommand DoSomethingCommand { get; }

        public IAsyncCommand NavigateCommand { get; }

        public INavigation Navigation { get; set; }

        private bool canExecute = true;

        public bool CanExecute
        {
            get => canExecute;
            set
            {
                if (SetProperty(ref canExecute, value))
                {
                    DoSomethingCommand.RaiseCanExecuteChanged();
                    NavigateCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public MainViewModel(IMyService myService)
        {
            this.myService = myService;

            Title = "Rogue Windows Reference";

            DoSomethingCommand = new AsyncCommand(OnDoSomething, () => CanExecute);
            NavigateCommand = new AsyncCommand(OnNavigate, () => CanExecute);
        }

        private async Task OnDoSomething()
        {
            CanExecute = false;

            try
            {
                await myService.DoSomethingAsync();
            }
            finally
            {
                CanExecute = true;
            }
        }

        private async Task OnNavigate()
        {
            CanExecute = false;

            try
            {
                var secondPage = new SecondPage()
                {
                    BindingContext = new SecondViewModel()
                };

                await Navigation.PushAsync(secondPage);
            }
            finally
            {
                CanExecute = true;
            }
        }
    }
}
