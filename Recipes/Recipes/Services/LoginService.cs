using Recipes.Model;
using System.Diagnostics;
using Xamarin.Essentials;

namespace Recipes.Services
{
    class LoginService : ILoginService
    {
        public void SaveUser(UserModel User)
        {
            Preferences.Set("UserId", User.Id);
            Preferences.Set("Username", User.Name);
        }

    }
}
