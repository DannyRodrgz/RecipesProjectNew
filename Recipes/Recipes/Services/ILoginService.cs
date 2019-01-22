using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Services
{
    public interface ILoginService
    {
        void SaveUser(UserModel User);
    }
}
