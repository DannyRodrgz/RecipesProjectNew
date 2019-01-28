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
        readonly ISettingsService settingsService;
        private UserModel user;
        private readonly IMvxNavigationService navigationService;
        public SettingsViewModel(ISettingsService settingsService, IMvxNavigationService navigationService)
        {
            this.settingsService = settingsService;
            this.navigationService = navigationService;
        }
        public override void Prepare()
        {
        }

        public override void Prepare(UserModel parameter)
        {
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
            settingsService.logout();
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
                settingsService.logout();
                await navigationService.Navigate<LoginViewModel, UserModel>(new UserModel());
            }
        }
    }
}
