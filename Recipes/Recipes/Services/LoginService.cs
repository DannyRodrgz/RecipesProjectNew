using Recipes.Model;
using Xamarin.Essentials;

namespace Recipes.Services
{
    class LoginService : ILoginService
    {
        public void SaveUser(UserModel User)
        {
            Preferences.Set("UserId", User.Id);
        }

    }
}
