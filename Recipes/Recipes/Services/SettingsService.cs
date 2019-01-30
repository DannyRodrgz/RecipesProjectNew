using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;

namespace Recipes.Services
{
    public class SettingsService : ISettingsService
    {
        public void Logout()
        {
            Preferences.Remove("UserId");
            Preferences.Remove("Username");
        }

        public UserModel RemoveUser(UserModel user)
        {
            return user = null;
        }
    }
}
