using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Pages;
using Recipes.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class LoginViewModel : MvxViewModel<UserModel>
    {
        readonly ILoginService loginService;
        private string Id;
        private UserModel User;
        private readonly IMvxNavigationService navigationService;
        readonly IFirebaseAuthenticator firebaseAuthenticator;

        public LoginViewModel(ILoginService loginService, 
            IMvxNavigationService navigationService,
            IFirebaseAuthenticator firebaseAuthenticator)
        {
            this.loginService = loginService;
            this.navigationService = navigationService;
            this.firebaseAuthenticator = firebaseAuthenticator;
        }

        public override void Prepare(UserModel parameter)
        {
            User = parameter;
        }

        public async Task Initialize()
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
        /*public ICommand SaveUserSCommand
        {
            get 
            {
                saveUserCommand = saveUserCommand ?? new MvxCommand(SaveUserAsync);
                return saveUserCommand;
            }
        }
        
        private Task SaveUserAsync()
        {
            Id = "159";
            User = new UserModel(Id, Username, Password);
            if (!string.IsNullOrEmpty(User.Name) || !string.IsNullOrEmpty(User.Password)) {
                if (User.Name.Equals("danny") && User.Password.Equals("123"))
                {
                    loginService.SaveUser(User);
                    navigationService.Navigate<RecipesViewModel, UserModel>(new UserModel());
                } else
                {
                    Application.Current.MainPage.DisplayAlert("Recipes", "Your username or password are not correct.", "Ok");
                }
            } else Application.Current.MainPage.DisplayAlert("Recipes", "Fill in the user and password fields.", "Ok");
        }*/

        public ICommand SaveUserCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    Id = "159";
                    User = new UserModel(Id, Username, Password);
                    if (!string.IsNullOrEmpty(User.Name) || !string.IsNullOrEmpty(User.Password))
                    {
                        if (User.Name.Equals("danny") && User.Password.Equals("123"))
                        {
                            loginService.SaveUser(User);
                            await navigationService.Navigate<RecipesViewModel, UserModel>(new UserModel());
                           // var user = await firebaseAuthenticator.LoginWithEmailPassword(Username, Password);
                        }
                        else
                        {
                           await Application.Current.MainPage.DisplayAlert("Recipes", "Your username or password are not correct.", "Ok");
                        }
                    }
                    else await Application.Current.MainPage.DisplayAlert("Recipes", "Fill in the user and password fields.", "Ok");
                });
            }
        }

    }
}
