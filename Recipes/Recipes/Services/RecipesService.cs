using ModernHttpClient;
using MvvmCross;
using MvvmCross.Commands;
using Newtonsoft.Json;
using Recipes.Model;
using System;
using System.Collections.Generic;
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
        // /search? q = chicken & app_id = 7af53792&app_key=c9e91b62013333bebd3abf3adc20e0e8
        private static HttpClient client;

        public RecipesService()
        {
        }

        public async Task<Result> GetRecipesResult() {

            var res = new Result();
            //try
            //{
                client = new HttpClient();
                var response = await client.GetAsync("https://api.edamam.com/search?q=chicken&app_id=7af53792&app_key=c9e91b62013333bebd3abf3adc20e0e8");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Debug.WriteLine("STATUSSS CATCH" + response.Content.ReadAsStringAsync());
                    var jsonString = await response.Content.ReadAsStringAsync();
                    res =  Newtonsoft.Json.JsonConvert.DeserializeObject<Result>(jsonString);
                }
            return res;
          /*  }
            catch {
                Debug.WriteLine("SERVICEEEEE CATCH" + res);
                return res;
            }
            Debug.WriteLine("SERVICEEEEE other" + res);
            return res;*/
        }

        /*private HttpClient BaseClient
        {
            get
            {
                return client ?? (client = new HttpClient(new NativeMessageHandler())
                {
                    BaseAddress = new Uri(BaseURL)
                });
            }
        }
        
        public async Task<List<Recipe>> SearchRecipes(string ingredient)
        {
            try
            {
                Debug.WriteLine("SERVICEEEEEE" + ingredient);
                var res = await BaseClient.GetAsync(string.Format("/search?q="+ ingredient + "&app_id=7af53792&app_key=c9e91b62013333bebd3abf3adc20e0e8", API_KEY,
                    ingredient));
                res.EnsureSuccessStatusCode();

                var json = await res.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json)) return null;

                var allRecipesResult = JsonConvert.DeserializeObject<Result>(json);

                var hitsList = allRecipesResult.hits;

                Debug.WriteLine("SERVICEEEEEE" + res.ToString());

                List<Recipe> recipeList = new List<Recipe>();
                for (int i=0; i<hitsList.Count; i++) {
                    recipeList.Add(hitsList[i].Recipe);
                }
                return recipeList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }*/
        
        public ObservableCollection<Recipe> Recipes { get; set; }

        public Recipe getSpecificRecipe(string label)
        {
            Recipe SpecificRecipe = null;
            for (int index = 0; index < Recipes.Count; index++)
            {
                if (Recipes[index].Label.Equals(label))
                {
                    SpecificRecipe = Recipes[index];
                }
            }
            return SpecificRecipe;
        }

        public ObservableCollection<Recipe> getAllRecipes(string ingredient)
        {
            return Recipes;
        }

        public ObservableCollection<Recipe> getAllRecipes()
        {
            return Recipes;
        }
    }
}
