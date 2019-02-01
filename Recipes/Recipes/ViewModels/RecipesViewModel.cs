using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Recipes.Model;
using Recipes.Services;
using Recipes.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Recipes.ViewModels
{
    public class RecipesViewModel : MvxViewModel<UserModel>
    {
        private UserModel user;
        private ObservableCollection<string> dietLabels;
        readonly IRecipesService recipesService;
        readonly ISettingsService settingsService;
        private readonly IMvxNavigationService navigationService;
        public RecipesViewModel(IRecipesService recipesService, 
            ISettingsService settingsService,  
            IMvxNavigationService navigationService)
        {
            this.recipesService = recipesService;
            this.settingsService = settingsService;
            this.navigationService = navigationService;

        }

        public override void Prepare(UserModel user)
        {
            this.user = user;
        }
        public override async Task Initialize()
        {
            await base.Initialize();
            searchString = "";
            recipes = new ObservableCollection<Recipe>();
            selectedRecipe = new Recipe();
            selectedDiet = "";
            selectedAllergie = "";
        }

        public void Init(string id) 
        {

        }

        private bool searching;

        public bool Searching
        {
            get { return searching; }
            set
            {
                searching = value;
                RaisePropertyChanged(() => Searching);
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

        public ObservableCollection<string> DietLabels
        {
            get { return dietLabels; }
            set
            {
                dietLabels = value;
                RaisePropertyChanged(() => DietLabels);
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
                    Searching = true;
                    Recipes.Clear();
                    Recipes = await recipesService.SearchRecipes(searchString, selectedDiet, selectedAllergie);
                    Searching = false;
                    if(Recipes.Count == 0) {
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
            }
        }

        private ICommand getSelectedRecipeCommand;
        public ICommand GetSelectedRecipeCommand
        {
            get
            {
                getSelectedRecipeCommand = getSelectedRecipeCommand ?? new MvxCommand<Recipe>(GetSelectedRecipe);
                return getSelectedRecipeCommand;
            }
        }

        private void GetSelectedRecipe(Recipe recipeNew)
        {
            navigationService.Navigate<RecipeDetailViewModel, Recipe>(recipeNew);
        }

        private string selectedAllergie;

        public string SelectedAllergie
        {
            get { return selectedAllergie; }
            set
            {
                selectedAllergie = value;
                RaisePropertyChanged(() => SelectedAllergie);
            }
        }

        private string selectedDiet;

        public string SelectedDiet
        {
            get { return selectedDiet; }
            set
            {
                selectedDiet = value;
                RaisePropertyChanged(() => SelectedDiet);
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisePropertyChanged(() => IsSelected);
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
            if(logout)
            {
                settingsService.Logout();
                await navigationService.Navigate<LoginViewModel, UserModel>(new UserModel());
            }
        }

        
    }
}
