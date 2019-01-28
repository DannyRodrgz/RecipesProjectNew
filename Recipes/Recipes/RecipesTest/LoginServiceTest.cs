using NUnit.Framework;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Recipes.RecipesTest
{
    [TestFixture]
    class LoginServiceTest
    {
        LoginService loginService = new LoginService();

        [TestCase]
        public void saveUserTest()
        {
            UserModel user = new UserModel("159", "danny", "123");
            Preferences.Set("UserIdTest", user.Id);
            loginService.SaveUser(user);
            Assert.AreEqual("159", Preferences.Get("UserId", "default"));
        }
    }
}
