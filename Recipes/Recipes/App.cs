using MvvmCross;
using MvvmCross.ViewModels;
using Recipes.Services;
using Recipes.ViewModels;

namespace Recipes
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<ILoginService, LoginService>();
            Mvx.IoCProvider.RegisterType<IRecipesService, RecipesService>();
            Mvx.IoCProvider.RegisterType<IRecipeDetailService, RecipeDetailService>();
            Mvx.IoCProvider.RegisterType<ISettingsService, SettingsService>();

            LoginService loginService = new LoginService();
            if (loginService.IsLoget())
            {
                RegisterAppStart<RecipesViewModel>();
            } else RegisterAppStart<LoginViewModel>();

        }
    }
}
