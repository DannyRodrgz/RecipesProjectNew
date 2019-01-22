using MvvmCross;
using MvvmCross.ViewModels;
using Recipes.Services;
using Recipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<ICalculationService, CalculationService>();

            RegisterAppStart<TipViewModel>();
        }
    }
}
