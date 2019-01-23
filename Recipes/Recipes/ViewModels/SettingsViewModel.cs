using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Recipes.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace Recipes.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        readonly ISettingsService service;
        public SettingsViewModel(ISettingsService settingsService)
        {
            service = settingsService;
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
        }
    }
}
