using MvvmCross.Forms.Views;
using Recipes.ViewModels;
using Xamarin.Forms;

namespace Recipes.Pages
{
	public partial class RecipesView : MvxContentPage<RecipesViewModel>
    {
		public RecipesView ()
		{
			InitializeComponent ();
		}

        private void RecipeSelected (object sender, SelectedItemChangedEventArgs e)
        {

        }
	}
}