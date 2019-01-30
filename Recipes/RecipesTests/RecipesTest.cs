using NUnit.Framework;
using Recipes.Model;
using Recipes.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RecipesTests
{
    public class RecipesTest
    {
        Recipe recipe;
        Recipe recipeTest;
        RecipesService recipeService;
        ObservableCollection<Recipe> recipes;

        [SetUp]
        public void Setup()
        {
            recipeService = new RecipesService();
            recipeTest = new Recipe("Flourless Chocolate Almond Butter Cookies",
            new Uri("https://www.edamam.com/web-img/18a/18a14f2fc10f3805f6b67a23009b32f1.jpg"),
            new Uri("http://www.thekitchenofdanielle.com/flourless-chocolate-almond-butter-cookies-vgf/"),
            10,
            2418.673499998057);
            recipes = new ObservableCollection<Recipe>();
        }

        [Test]
        public async Task LabelRecipeTest()
        {
            recipes = await recipeService.SearchRecipes("cocca", "", "");
            string recipeLabel = recipes[0].Label;
            Assert.AreEqual(recipeTest.Label, recipeLabel);
        }

        [Test]
        public async Task RecipesNotFound()
        {
            recipes = await recipeService.SearchRecipes("759257854", "", "");
            ObservableCollection<Recipe> recipeEmpty = new ObservableCollection<Recipe>();
            Assert.AreEqual(recipeEmpty, recipes);
        }

        [Test]
        public async Task RecipeCaloriesTest()
        {
            recipes = await recipeService.SearchRecipes("cocca", "", "");
            recipe = recipes[0];
            Assert.AreEqual(recipeTest.Calories, recipe.Calories);
        }

        [Test]
        public async Task RecipeCaloriesPerRecipeTest()
        {
            recipes = await recipeService.SearchRecipes("cocca", "", "");
            recipe = recipes[0];
            Assert.AreEqual(recipeTest.RecipeCalories, recipe.RecipeCalories);
        }
    }
}
