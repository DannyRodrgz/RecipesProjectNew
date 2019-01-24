using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

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
                logoutCommand = logoutCommand ?? new MvxCommand(logout);
                return logoutCommand;
            }
        }

        private void logout()
        {
            service.logout();
            navigationService.Navigate<LoginViewModel, UserModel>(new UserModel());
        }
    }
}
