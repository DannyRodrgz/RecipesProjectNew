using MvvmCross.Forms.Views;
using Recipes.ViewModels;

namespace Recipes.Pages
{
	public partial class LoginView : MvxContentPage<LoginViewModel>
    {
        LoginViewModel loginViewModel;
        public LoginView ()
		{
			InitializeComponent ();
            loginViewModel = new LoginViewModel(this);
		}
	}
}