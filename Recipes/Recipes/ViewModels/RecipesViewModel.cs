using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Pages;
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
    public class RecipesViewModel : MvxViewModel<UserModel>
    {
        private UserModel user;
        readonly IRecipesService recipesService;
        readonly ISettingsService settingsService;
        private readonly IMvxNavigationService navigationService;
        public RecipesViewModel(IRecipesService recipesService, ISettingsService settingsService,  IMvxNavigationService navigation)
        {
            this.recipesService = recipesService;
            this.settingsService = settingsService;
            navigationService = navigation;
        }

        public override void Prepare()
        {
        }

        public override void Prepare(UserModel parameter)
        {
            user = parameter;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            
            searchString = "";
            recipes = new ObservableCollection<Recipe>();
            selectedRecipe = new Recipe();
        }

        private string searchString;

        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                RaisePropertyChanged(() => SearchString);
            }
        }

        private ObservableCollection<Recipe> recipes;

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set
            {
                recipes = value;
                RaisePropertyChanged(() => Recipes);
            }
        }
        public ICommand GetRecipesCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    Recipes.Clear();
                    Recipes = await recipesService.SearchRecipes(searchString);
                    if(Recipes.Count== 0) {
                        await Application.Current.MainPage.DisplayAlert("Recipes", "No results for your search", "Ok");
                    }
                });
            }
        }

        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get { return selectedRecipe; }
            set
            {
                selectedRecipe = value;
                RaisePropertyChanged(() => SelectedRecipe);

                GetSelectedRecipeCommand.Execute(null);
            }
        }

        private ICommand getSelectedRecipeCommand;
        public ICommand GetSelectedRecipeCommand
        {
            get
            {
                getSelectedRecipeCommand = getSelectedRecipeCommand ?? new MvxCommand(getSelectedRecipe);
                return getSelectedRecipeCommand;
            }
        }

        private void getSelectedRecipe()
        {
            navigationService.Navigate<RecipeDetailViewModel, Recipe>(new Recipe());
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
            if(logout)
            {
                settingsService.logout();
                await navigationService.Navigate<LoginViewModel, UserModel>(new UserModel());
            }
        }
        
    }
}
