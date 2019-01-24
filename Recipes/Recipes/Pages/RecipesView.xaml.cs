using MvvmCross.Forms.Views;
using Recipes.ViewModels;

namespace Recipes.Pages
{
	public partial class RecipesView : MvxContentPage<RecipesViewModel>
    {
		public RecipesView ()
		{
			InitializeComponent ();
		}
	}
}