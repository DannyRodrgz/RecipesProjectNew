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
            /* Mvx.RegisterType<ICalculationService, CalculationService>();

             RegisterAppStart<TipViewModel>();*/

             Mvx.RegisterType<ILoginService, LoginService>();

             RegisterAppStart<LoginViewModel>();

           /* Mvx.RegisterType<IRecipesService, RecipesService>();

            RegisterAppStart<RecipesViewModel>();*/
        }
    }
}
