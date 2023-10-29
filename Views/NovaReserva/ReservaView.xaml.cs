using TelaLogin.ViewModels.Usuarios;

namespace TelaLogin.Views.NovaReserva;

public partial class ReservaView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public ReservaView()
	{
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;
    }
}