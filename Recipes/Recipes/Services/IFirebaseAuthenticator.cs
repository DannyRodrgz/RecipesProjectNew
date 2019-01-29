using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
    }
}
