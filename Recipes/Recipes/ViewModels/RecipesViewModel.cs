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
        Ingredients recipe1;
        Ingredients recipe2;
        public RecipesViewModel(IRecipesService recipesService, IMvxNavigationService navigation)
        {
            service = recipesService;
            navigationService = navigation;

            recipe1 = new Ingredients("Sopa de mani", 12.5, new Uri("https://www.edamam.com/web-img/7a2/7a2f41a7891e8a8f8a087a96930c6463.jpg"));
            recipe2 = new Ingredients("Chanka", 17.5, new Uri("https://www.edamam.com/web-img/7a2/7a2f41a7891e8a8f8a087a96930c6463.jpg"));
            
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
            recipes = new ObservableCollection<Ingredients>();
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

        private ObservableCollection<Ingredients> recipes;

        public ObservableCollection<Ingredients> Recipes
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

            navigationService.Navigate<RecipeDetailViewModel, UserModel>(new UserModel());
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
}
}
