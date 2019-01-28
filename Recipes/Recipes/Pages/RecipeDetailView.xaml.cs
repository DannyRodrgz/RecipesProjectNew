using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Recipes.ViewModels;

namespace Recipes.Pages
{
    [MvxContentPagePresentation]
    public partial class RecipeDetailView : MvxTabbedPage<RecipeDetailViewModel>
    {
        public RecipeDetailView()
        {
            InitializeComponent();
        }
    }
}