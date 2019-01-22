using MvvmCross.Forms.Views;
using Recipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipes.Pages
{
	public partial class RecipesView : MvxContentPage<RecipesViewModel>
    {
        RecipesViewModel contexto = new RecipesViewModel();
		public RecipesView ()
		{
			InitializeComponent ();
            // BindingContext = contexto;
		}
	}
}