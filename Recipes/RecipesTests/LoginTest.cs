using NUnit.Framework;
using Recipes.Model;
using Recipes.Services;

namespace RecipesTests
{
    public class LoginTest
    {
        LoginService loginService;
        UserModel user;

        [SetUp]
        public void Setup()
        {
            user = new UserModel("123", "DannyTest@gmail.com", "12345678");
            loginService = new LoginService();
            loginService.CreateUser(user);
        }

        [Test]
        public void UserIdTest()
        {
            string Id = loginService.User.Id;
            Assert.AreEqual("123", Id);
        }

        [Test]
        public void UserNameTest()
        {
            string username = loginService.User.Name;
            Assert.AreEqual("DannyTest@gmail.com", loginService.User.Name);
        }

        [Test]
        public void UserPasswordTest()
        {
            string password = loginService.User.Password;
            Assert.AreEqual("12345678", loginService.User.Password);
        }
    }
}
