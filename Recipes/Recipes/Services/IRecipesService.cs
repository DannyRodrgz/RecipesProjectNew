using Recipes.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IRecipesService
    {
        Recipe getSpecificRecipe(string label);
        Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient);
    }
}
