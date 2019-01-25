using MvvmCross.Forms.Views;
using Recipes.ViewModels;

namespace Recipes.Pages
{
    public partial class RecipeDetailView : MvxTabbedPage<RecipeDetailViewModel>
    {
        public RecipeDetailView()
        {
            InitializeComponent();
        }
    }
}