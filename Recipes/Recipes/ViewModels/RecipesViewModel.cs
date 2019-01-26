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
        Recipe recipe1;
        Recipe recipe2;
        public RecipesViewModel(IRecipesService recipesService, ISettingsService settingsService,  IMvxNavigationService navigation)
        {
            this.recipesService = recipesService;
            this.settingsService = settingsService;
            navigationService = navigation;

            recipe1 = new Recipe("Sopa de mani", 12.5, new Uri("https://www.edamam.com/web-img/7a2/7a2f41a7891e8a8f8a087a96930c6463.jpg"));
            recipe2 = new Recipe("Chanka", 17.5, new Uri("https://www.edamam.com/web-img/7a2/7a2f41a7891e8a8f8a087a96930c6463.jpg"));
            
        }

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
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

        private ICommand getRecipesCommand;
        public ICommand GetRecipesCommand
        {
            get
            {
                getRecipesCommand = getRecipesCommand ?? new MvxCommand(GetRecipes);
                return getRecipesCommand;
            }
        }

        public void GetRecipes()
        {
           // recipes.Add(recipe1);
            // recipes.Add(recipe2);

            // navigationService.Navigate<RecipeDetailViewModel, UserModel>(new UserModel());
            /* ListView listView = new ListView();
             listView.ItemsSource = recipes;
             navigationService.Navigate<RecipeDetailViewModel, UserModel>(new UserModel());
             /*if (!string.IsNullOrEmpty(SearchString))
             {
                 var result = await service.GetRecipesResult();
                 if (result != null)
                 {
                     var res = result.hits[0].Recipe.Label;
                 }
                 // Recipes = await service.SearchRecipes(SearchString);
             }    else {  }*/
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
            selectedRecipe = recipe1;
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
