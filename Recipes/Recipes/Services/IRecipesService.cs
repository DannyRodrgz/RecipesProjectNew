using Recipes.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public interface IRecipesService
    {
        Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient);
    }
}
