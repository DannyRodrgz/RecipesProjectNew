using Recipes.Model;

namespace Recipes.Services
{
    public interface ILoginService
    {
        void SaveUser(UserModel User);
    }
}
