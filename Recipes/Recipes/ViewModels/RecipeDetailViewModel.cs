using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class RecipeDetailViewModel : MvxViewModel<Recipe>
    {
        public Recipe recipe;
        readonly IRecipeDetailService recipeDetailService;
        readonly ISettingsService settingsService;
        private readonly IMvxNavigationService navigationService;

        public RecipeDetailViewModel(IRecipeDetailService recipeDetailService, 
            ISettingsService settingsService, 
            IMvxNavigationService navigationService)
        {
            this.recipeDetailService = recipeDetailService;
            this.settingsService = settingsService;
            this.navigationService = navigationService;
        }
        public override void Prepare(Recipe recipe)
        {
            this.recipe = recipe;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
        }

        private ICommand toRecipeSourceCommand;
        public ICommand ToRecipeSourceCommand
        {
            get
            {
                toRecipeSourceCommand = toRecipeSourceCommand ?? new MvxCommand(ToRecipeSource);
                return toRecipeSourceCommand;
            }
        }

        public void ToRecipeSource()
        {
            recipeDetailService.OpenBrowser(recipe.Url);
        }        
        public Recipe Recipe
        {
            get { return recipe; }
            set
            {
                recipe = value;
                RaisePropertyChanged(() => Recipe);
            }
        }

        private ICommand logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                logoutCommand = logoutCommand ?? new MvxCommand(Logout);
                return logoutCommand;
            }
        }

        private async void Logout()
        {
            bool logout = await Application.Current.MainPage.DisplayAlert("Recipes", "Sign out", "Ok", "Cancel");
            if (logout)
            {
                settingsService.Logout();
                await navigationService.Navigate<LoginViewModel, UserModel>(new UserModel());
            }
        }

        private ICommand toSearchCommand;
        public ICommand ToSearchCommand
        {
            get
            {
                toSearchCommand = toSearchCommand ?? new MvxCommand(ToSearch);
                return toSearchCommand;
            }
        }

        private void ToSearch()
        {
            navigationService.Navigate<RecipesViewModel, UserModel>(new UserModel());
           
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

        private void ToSettings()
        {
            navigationService.Navigate<SettingsViewModel, UserModel>(new UserModel());
        }
    }
}
