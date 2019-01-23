using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Essentials;

namespace Recipes.Services
{
    public class SettingsService : ISettingsService
    {
        public void logout()
        {
            Preferences.Remove("userId");
            Preferences.Remove("Username");
        }
    }
}
