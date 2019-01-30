using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Recipes.Services
{
    public class RecipeDetailService : IRecipeDetailService
    {
        public void OpenBrowser(Uri url)
        {
            Device.OpenUri(url);
        }
    }
}
