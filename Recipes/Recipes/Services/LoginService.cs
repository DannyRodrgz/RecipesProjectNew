using Recipes.Model;
using System.Diagnostics;
using Xamarin.Essentials;

namespace Recipes.Services
{
    public class LoginService : ILoginService
    {
        public UserModel User { get; set; }
        public void CreateUser(UserModel User)
        {
            this.User = new UserModel(User.Id, User.Name, User.Password);
        }
        public void SaveUserLocalStorage(UserModel User)
        {
            Preferences.Set("UserId", User.Id);
            Preferences.Set("Username", User.Name);
        }
    }
}
