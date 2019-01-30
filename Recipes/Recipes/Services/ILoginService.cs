using Recipes.Model;

namespace Recipes.Services
{
    public interface ILoginService
    {
        void SaveUserLocalStorage(UserModel User);
        void CreateUser(UserModel User);
    }
}
