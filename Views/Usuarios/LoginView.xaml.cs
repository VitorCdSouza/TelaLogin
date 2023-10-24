using TelaLogin.ViewModels.Usuarios;

namespace TelaLogin.Views.Usuarios;

public partial class LoginView : ContentPage
{
	UsuarioViewModel usuarioViewModel;
	public LoginView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;
	}
}