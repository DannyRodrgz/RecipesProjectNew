using MvvmCross.Forms.Views;
using Recipes.Services;
using Recipes.ViewModels;

namespace Recipes.Pages
{
	public partial class LoginView : MvxContentPage<LoginViewModel>
    {
        public LoginView ()
		{
			InitializeComponent ();
		}
	}
}