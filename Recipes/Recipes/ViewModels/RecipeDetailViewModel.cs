using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        Ingredient ing1;
        Ingredient ing2;
        Total tot1;
        Total tot2;
        SpecificDigest nutr1;
        SpecificDigest nutr2;

        public RecipeDetailViewModel(IRecipeDetailService recipeDetailService, IMvxNavigationService navigation)
        {
            service = recipeDetailService;
            navigationService = navigation;
            ing1 = new Ingredient("1 whole chicken", 1700.9713875);
            ing2 = new Ingredient("Kosher salt and freshly ground black pepper", 10.205828325);
            tot1 = new Total("Energy", 2499.628483072875, Unit.G);
            tot2 = new Total("Fat", 174.35943285279748, Unit.G);
            nutr1 = new SpecificDigest("ENERC_KCAL", tot1);
            nutr2 = new SpecificDigest("FAT", tot2);
        }
        public override void Prepare(UserModel parameter)
        {
            user = parameter;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            ingredients = new ObservableCollection<Ingredient>();
            listNutrients = new ObservableCollection<SpecificDigest>();
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

        public void ToSettings()
        {
            ingredients.Add(ing1);
            ingredients.Add(ing2);
            listNutrients.Add(nutr1);
            listNutrients.Add(nutr2);
            // navigationService.Navigate<SettingsViewModel, UserModel>(new UserModel());
        }

        private ObservableCollection<Ingredient> ingredients;

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set
            {
                ingredients = value;
                RaisePropertyChanged(() => Ingredients);
            }
        }

        private ObservableCollection<SpecificDigest> listNutrients;

        public ObservableCollection<SpecificDigest> ListNutrients
        {
            get { return listNutrients; }
            set
            {
                listNutrients = value;
                RaisePropertyChanged(() => ListNutrients);
            }
        }
    }
}
