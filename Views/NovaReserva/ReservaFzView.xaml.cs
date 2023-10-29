using TelaLogin.ViewModels.Usuarios;

namespace TelaLogin.Views.NovaReserva;

public partial class ReservaFzView : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public ReservaFzView()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;
    }
    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedIndex = ((Picker)sender).SelectedIndex;
        var selectedOption = ((Picker)sender).Items[selectedIndex];
        // Do something with the selected option
    }
}