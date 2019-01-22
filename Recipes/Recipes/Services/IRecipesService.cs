using Recipes.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IRecipesService
    {
        ObservableCollection<Recipe> Recipes { get; set; }
        Recipe getSpecificRecipe(string label);
        ObservableCollection<Recipe> getAllRecipes(string ingredient);
        ObservableCollection<Recipe> getAllRecipes();
        Task<List<Recipe>> SearchRecipes(string ingredient);
    }
}
