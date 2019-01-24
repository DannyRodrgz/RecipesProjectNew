using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipes.ViewModels
{
    public class RecipeDetailViewModel : MvxViewModel<UserModel>
    {
        private UserModel user;
        readonly IRecipeDetailService service;
        private readonly IMvxNavigationService navigationService;
        public RecipeDetailViewModel(IRecipeDetailService recipeDetailService, IMvxNavigationService navigation)
        {
            service = recipeDetailService;
            navigationService = navigation;
        }
        public override void Prepare(UserModel parameter)
        {
            // receive and store the parameter here
            user = parameter;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
        }

        private ICommand toSettingsCommand;
        public ICommand ToSettingsCommand
        {
            get
            {
                toSettingsCommand = toSettingsCommand ?? new MvxCommand(ToSettings);
                return toSettingsCommand;
            }
        }

        public void ToSettings() {
            navigationService.Navigate<SettingsViewModel, UserModel>(new UserModel());
        }
    }
}
