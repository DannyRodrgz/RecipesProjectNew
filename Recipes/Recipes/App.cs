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
            Mvx.RegisterType<ICalculationService, CalculationService>();
            Mvx.RegisterType<ILoginService, LoginService>();
            Mvx.RegisterType<IRecipesService, RecipesService>();
            Mvx.RegisterType<IRecipeDetailService, RecipeDetailService>();
            Mvx.RegisterType<ISettingsService, SettingsService>();

            var id = Preferences.Get("UserId", "default");
             if(id.Equals("159")) {

                RegisterAppStart<RecipesViewModel>();
            } else
            {
                RegisterAppStart<LoginViewModel>();
            }
        }
    }
}
