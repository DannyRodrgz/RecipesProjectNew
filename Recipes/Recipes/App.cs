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
            /*Mvx.RegisterType<ICalculationService, CalculationService>();

             RegisterAppStart<TipViewModel>();*/
             var id = Preferences.Get("UserId", "default");
             if(id.Equals("159")) {

                Mvx.RegisterType<IRecipesService, RecipesService>();

                RegisterAppStart<RecipesViewModel>();
            } else
            {
                Mvx.RegisterType<ILoginService, LoginService>();

                RegisterAppStart<LoginViewModel>();
            }

            /* Mvx.RegisterType<IRecipesService, RecipesService>();

             RegisterAppStart<RecipesViewModel>();

            Mvx.RegisterType<ISettingsService, SettingsService>();

            RegisterAppStart<SettingsViewModel>();*/
        }
    }
}
