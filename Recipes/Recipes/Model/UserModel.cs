using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public class UserModel : IUserModel
    {
        public UserModel(String IdUser, String UserName, String UserPassword)
        {
            Id = IdUser;
            Name = UserName;
            Password = UserPassword;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
