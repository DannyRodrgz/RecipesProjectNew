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
        public RecipesViewModel()
        {
        }
        public override async Task Initialize()
        {
            await base.Initialize();

            _subTotal = 100;
            searchString = "";
        }

        private double _subTotal;
        public double SubTotal
        {
            get => _subTotal;
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);
            }
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

        public ICommand GetRecipesCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    Recipes = await service.SearchRecipes(SearchString);
                });
            }
        }
    }
}
