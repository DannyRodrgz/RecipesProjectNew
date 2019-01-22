using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Pages;
using Recipes.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        readonly ILoginService LoginService;
        private string Id;
        private string Username;
        private string Password;
        private UserModel User;
        LoginView loginView;

        public LoginViewModel(ILoginService loginService)
        {
            LoginService = loginService;
            saveUserCommand = new Command(async () => await SaveUser());
        }

        public LoginViewModel(LoginView loginViewApp)
        {
            LoginService = new LoginService();
            loginView = loginViewApp;
            saveUserCommand = new Command(async () => await SaveUser());
        }

        public Command saveUserCommand { get; set; }

        private async Task SaveUser()
        {
            Id = "159";
            Username = "danny@gmail.com";
            Password = "123";
            User = new UserModel(Id, Username, Password);
            await loginView.DisplayAlert("Recipes", "Ingrese su username y contraseña", "Aceptar");
            LoginService.SaveUser(User);
        }

        /*private void BtnSaveClicked(object sender, EventArgs eventArgs)
        {
            if (string.IsNullOrEmpty(User.Name) || string.IsNullOrEmpty(User.Password))
            {
                DisplayAlert("Recipes", "Ingrese su username y contraseña", "Aceptar");
            }
            else if (User.Name.Equals("danny@gmail.com") && User.Password.Equals("123"))
            {
                SaveUser();
                this.Navigation.PushModalAsync(new SearcherScreen(User));
            }
            else DisplayAlert("Recipes", "Ingrese datos correctos", "Aceptar");
        }*/
    }
}
