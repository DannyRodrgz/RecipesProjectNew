using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class LoginViewModel : MvxViewModel<UserModel>
    {
        readonly ILoginService loginService;
        private string Id;
        private UserModel User;
        private readonly IMvxNavigationService navigationService;

        public LoginViewModel(ILoginService loginService, IMvxNavigationService navigationService)
        {
            this.loginService = loginService;
            this.navigationService = navigationService;
        }

        public override void Prepare(UserModel User)
        {
            this.User = User;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
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

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        private ICommand saveUserCommand;
        public ICommand SaveUserCommand
        {
            get 
            {
                saveUserCommand = saveUserCommand ?? new MvxCommand(SaveUser);
                return saveUserCommand;
            }
        }

        private void SaveUser()
        {
            Id = "159";
            User = new UserModel(Id, Username, Password);
            if (!string.IsNullOrEmpty(User.Name) || !string.IsNullOrEmpty(User.Password)) {
                if (User.Name.Equals("danny") && User.Password.Equals("123"))
                {
                    loginService.SaveUserLocalStorage(User);
                    // navigationService.Navigate<RecipesViewModel, UserModel>(new UserModel());
                    navigationService.Navigate("mvx://test/?id=" + Guid.NewGuid().ToString("N"));
                } else
                {
                    Application.Current.MainPage.DisplayAlert("Recipes", "Your username or password are not correct.", "Ok");
                }
            } else Application.Current.MainPage.DisplayAlert("Recipes", "Fill in the user and password fields.", "Ok");
        }

    }
}
