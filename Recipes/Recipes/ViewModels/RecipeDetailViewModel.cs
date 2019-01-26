using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class RecipeDetailViewModel : MvxViewModel<Recipe>
    {
        private Recipe recipe;
        readonly IRecipeDetailService service;
        readonly ISettingsService settingsService;
        private readonly IMvxNavigationService navigationService;
        Ingredient ing1;
        Ingredient ing2;
        Total tot1;
        Total tot2;
        SpecificDigest nutr1;
        SpecificDigest nutr2;

        public RecipeDetailViewModel(IRecipeDetailService recipeDetailService, ISettingsService settingsService, IMvxNavigationService navigation)
        {
            service = recipeDetailService;
            this.settingsService = settingsService;
            navigationService = navigation;
            ing1 = new Ingredient("1 whole chicken", 1700.9713875);
            ing2 = new Ingredient("Kosher salt and freshly ground black pepper", 10.205828325);
            tot1 = new Total("Energy", 2499.628483072875, Unit.G);
            tot2 = new Total("Fat", 174.35943285279748, Unit.G);
            nutr1 = new SpecificDigest("ENERC_KCAL", tot1);
            nutr2 = new SpecificDigest("FAT", tot2);
        }
        public override void Prepare(Recipe parameter)
        {
            recipe = parameter;
            Debug.WriteLine("RECIPEEEEEEEE" + recipe.Label);
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            ingredients = new ObservableCollection<Ingredient>();
            listNutrients = new ObservableCollection<SpecificDigest>();
        }

        private ICommand toSettingsTestCommand;
        public ICommand ToSettingsTestCommand
        {
            get
            {
                toSettingsTestCommand = toSettingsTestCommand ?? new MvxCommand(ToSettingsTest);
                return toSettingsTestCommand;
            }
        }

        public void ToSettingsTest()
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
            if (logout)
            {
                settingsService.logout();
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
    }
}
