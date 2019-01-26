using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class SettingsViewModel : MvxViewModel<UserModel>
    {
        readonly ISettingsService service;
        private UserModel user;
        private readonly IMvxNavigationService navigationService;
        public SettingsViewModel(ISettingsService settingsService, IMvxNavigationService navigation)
        {
            service = settingsService;
            navigationService = navigation;
        }
        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        public override void Prepare(UserModel parameter)
        {
            // receive and store the parameter here
            user = parameter;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            username = Preferences.Get("Username", "Default");
        }

        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                logoutCommand = logoutCommand ?? new MvxCommand(Logout);
                return logoutCommand;
            }
        }

        private void Logout()
        {
            service.logout();
            navigationService.Navigate<LoginViewModel, UserModel>(new UserModel());
        }

        private ICommand toSearchCommand;
        public ICommand ToSearchCommand
        {
            get
            {
                toSearchCommand = toSearchCommand ?? new MvxCommand(ToSearch);
                return toSearchCommand;
            }
        }

        private void ToSearch()
        {
            navigationService.Navigate<RecipesViewModel, UserModel>(new UserModel());
        }

        private ICommand logoutIconCommand;
        public ICommand LogoutIconCommand
        {
            get
            {
                logoutIconCommand = logoutIconCommand ?? new MvxCommand(LogoutIcon);
                return logoutIconCommand;
            }
        }

        private async void LogoutIcon()
        {
            bool logout = await Application.Current.MainPage.DisplayAlert("Recipes", "Sign out", "Ok", "Cancel");
            if (logout)
            {
                service.logout();
                await navigationService.Navigate<LoginViewModel, UserModel>(new UserModel());
            }
        }
    }
}
