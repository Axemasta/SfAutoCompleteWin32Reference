using System;
using System.Threading.Tasks;
using AutoCompleteWindowsReference.Interfaces;
using AutoCompleteWindowsReference.Tests.Helpers;
using AutoCompleteWindowsReference.ViewModels;
using AutoCompleteWindowsReference.Views;
using Moq;
using Xamarin.Forms;
using Xunit;

namespace AutoCompleteWindowsReference.Tests
{
    public class MainViewModelTests
    {
        private MainViewModel _sut;

        private Mock<IMyService> myService;
        private Mock<INavigationService> navigationService;
        private Mock<INavigation> navigation;

        public MainViewModelTests()
        {
            myService = new Mock<IMyService>();
            navigationService = new Mock<INavigationService>();
            navigation = new Mock<INavigation>();

            navigationService.SetupGet(m => m.Current)
                .Returns(navigation.Object);

            _sut = new MainViewModel(myService.Object);
        }

        [Fact]
        public async Task DoSomethingCommand_ExecuteAsync_ShouldCallService()
        {
            // Arrange

            // Act
            await _sut.DoSomethingCommand.ExecuteAsync();

            // Assert
            myService.Verify(m => m.DoSomethingAsync(), Times.Once());
        }

        [Fact]
        public async Task DoSomethingCommand_WhenExecuting_ShouldChangeCanExecute()
        {
            // Arrange
            var initialCanExecute = _sut.CanExecute;

            var executingCanExecute = true;

            myService.Setup(m => m.DoSomethingAsync())
                .Callback(() =>
                {
                    executingCanExecute = _sut.CanExecute;
                });

            // Act
            await _sut.DoSomethingCommand.ExecuteAsync();

            // Assert
            Assert.True(initialCanExecute);
            Assert.False(executingCanExecute);
        }

        [Fact]
        public async Task NavigateCommand_Should_PushSecondPage()
        {
            /*
             * This test will fail on mac if the app.xaml has a style that applies to SfAutoComplete
             * 
             * Commenting out the styles in the app.xaml will cause the tests to pass
             * Commenting in will cause the exception:
             * Could not load type 'System.Windows.Freezable'
             */

            // Arrange
            MockSetup.Init();

            _sut.Navigation = Application.Current.MainPage.Navigation;

            // Act
            await _sut.NavigateCommand.ExecuteAsync();

            // Assert
            var navigationPage = Application.Current.MainPage as NavigationPage;

            Assert.True(navigationPage.CurrentPage is SecondPage);
        }
    }
}
