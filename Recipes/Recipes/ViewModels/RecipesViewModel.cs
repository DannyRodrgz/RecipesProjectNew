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
        readonly IRecipesService service;
        private readonly IMvxNavigationService navigationService;
        public List<Recipe> listRecipes;
        Recipe recipe1;
        Recipe recipe2;
        public RecipesViewModel(IRecipesService recipesService, IMvxNavigationService navigation)
        {
            service = recipesService;
            navigationService = navigation;
            listRecipes = new List<Recipe>();
            recipe1 = new Recipe("Sopa de mani", 12.5);
            recipe2 = new Recipe("Chanka", 17.5);
        }

        public override void Prepare()
        {
            // first callback. Initialize parameter-agnostic stuff here
        }

        public override void Prepare(UserModel parameter)
        {
            // receive and store the parameter here
            user = parameter;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            
            searchString = "";
            recipes = new List<Recipe>();
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

        private List<Recipe> recipes;

        public List<Recipe> Recipes
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
            Recipes.Add(recipe1);
            Recipes.Add(recipe2);
            Debug.WriteLine("NULLLLLLLLLL" + Recipes[1].Label);
            ListView listView = new ListView();
            listView.ItemsSource = recipes;

            Debug.WriteLine("NULLLLLLLLLLaaaaaaa" + listView.ItemsSource);
            // navigationService.Navigate<RecipeDetailViewModel, UserModel>(new UserModel());
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
}
}
