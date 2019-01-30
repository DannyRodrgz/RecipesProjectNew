using ModernHttpClient;
using Newtonsoft.Json;
using Recipes.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recipes.Services
{
    public class RecipesService : IRecipesService
    {
        const string BaseURL = "https://api.edamam.com";
        const string APP_ID = "7af53792";
        const string API_KEY = "c9e91b62013333bebd3abf3adc20e0e8";
        private static HttpClient client;
        public ObservableCollection<Recipe> recipes;

        public RecipesService()
        {
            recipes = new ObservableCollection<Recipe>();
        }

        private HttpClient BaseClient
        {
            get
            {
                return client ?? (client = new HttpClient(new NativeMessageHandler())
                {
                    BaseAddress = new Uri(BaseURL)
                });
            }
        }
        public async Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient)
        {
            try
            {
                var response = await BaseClient.GetAsync(string.Format("/search?q=" + ingredient + "&app_id=7af53792&app_key=c9e91b62013333bebd3abf3adc20e0e8", API_KEY,
                    ingredient));
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json)) return null;

                var allRecipesResult = JsonConvert.DeserializeObject<Result>(json);

                var result = new Result(allRecipesResult.hits);
                
                for (int i=0; i<result.hits.Count; i++)
                {
                    recipes.Add(result.hits[i].Recipe);
                }
                return recipes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEPTION" + ex);
                return null;
            }
        }
    }
}
