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
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        readonly ILoginService LoginService;
        private string Id;
        private UserModel User;

        public LoginViewModel(ILoginService loginService)
        {
            LoginService = loginService;
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
                saveUserCommand = saveUserCommand ?? new MvxCommand(saveUser);
                return saveUserCommand;
            }
        }
        
        private void saveUser()
        {
            Id = "159";
            User = new UserModel(Id, Username, Password);
            if (!string.IsNullOrEmpty(User.Name) || !string.IsNullOrEmpty(User.Password)) {
                if (User.Name.Equals("danny") && User.Password.Equals("123"))
                {
                    LoginService.SaveUser(User);
                } else
                {
                    Application.Current.MainPage.DisplayAlert("Recipes", "Your username or password are not correct.", "Ok");
                }
            } else Application.Current.MainPage.DisplayAlert("Recipes", "Fill in the user and password fields.", "Ok");
        }        
        
    }
}
