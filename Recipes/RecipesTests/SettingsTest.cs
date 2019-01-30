using NUnit.Framework;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesTests
{
    public class SettingsTest
    {
        UserModel user;
        SettingsService settingsService;
        LoginService loginService;

        [SetUp]
        public void Setup()
        {
            user = new UserModel("123", "DannyTest@gmail.com", "12345678");
            settingsService = new SettingsService();
            loginService = new LoginService();
            loginService.CreateUser(user);
        }

        [Test]
        public void UserIdTest()
        {
            UserModel userTest = settingsService.RemoveUser(user);
            Assert.AreEqual(null, userTest);
        }
    }
}
