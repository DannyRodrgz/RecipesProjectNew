using MvvmCross;
using MvvmCross.ViewModels;
using Recipes.Services;
using Recipes.ViewModels;
using Xamarin.Essentials;

namespace Recipes
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<ILoginService, LoginService>();
            Mvx.RegisterType<IRecipesService, RecipesService>();
            Mvx.RegisterType<IRecipeDetailService, RecipeDetailService>();
            Mvx.RegisterType<ISettingsService, SettingsService>();

            LoginService loginService = new LoginService();
            if (loginService.IsLoget())
            {
                RegisterAppStart<RecipesViewModel>();
            } else RegisterAppStart<LoginViewModel>();

        }
    }
}
