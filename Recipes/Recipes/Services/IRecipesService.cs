using Recipes.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IRecipesService
    {
        ObservableCollection<Ingredients> Recipes { get; set; }
        Ingredients getSpecificRecipe(string label);
        ObservableCollection<Ingredients> getAllRecipes(string ingredient);
        ObservableCollection<Ingredients> getAllRecipes();
        // Task<List<Recipe>> SearchRecipes(string ingredient);
        Task<Result> GetRecipesResult();
    }
}
