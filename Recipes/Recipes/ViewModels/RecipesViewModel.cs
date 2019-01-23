using MvvmCross.Commands;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Pages;
using Recipes.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class RecipesViewModel : MvxViewModel
    {
        readonly IRecipesService service;
        public RecipesViewModel(IRecipesService recipesService)
        {
            service = recipesService;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            
            searchString = "";
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
                getRecipesCommand = getRecipesCommand ?? new MvxCommand(getRecipes);
                return getRecipesCommand;
            }
        }

        public async void getRecipes()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                var result = await service.GetRecipesResult();
                if (result != null)
                {
                    var res = result.hits[0].Recipe.Label;
                    Debug.WriteLine("RESULTTTTTTTTTT" + res);
                }
                // Recipes = await service.SearchRecipes(SearchString);
            }    else { Debug.WriteLine("NULLLLLLLLLL"); }
        }      
    }
}
