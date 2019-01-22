using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Text;
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
