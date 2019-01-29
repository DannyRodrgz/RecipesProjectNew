using System.Threading.Tasks;
using Firebase.Auth;
using Recipes.Services;

namespace Recipes.iOS.Services
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            //var user = await Auth.DefaultInstance.SignInAsync(email, password);
            return null;
        }
    }
}