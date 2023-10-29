using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelaLogin.Services.Usuarios;
using TelaLogin.Models;
using System.Windows.Input;
using TelaLogin.Views.Usuarios;

namespace TelaLogin.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }

        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
        }

        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
        }

        


        #region AtributosPropiedades

        private string nome = string.Empty;
        public string Nome { 
            get { return nome; } 
            set {  
                nome = value;
                OnPropertyChanged();
            } 
        }

        private string senha = string.Empty;
        public string Senha { 
            get { return senha; } 
            set { 
                senha = value; 
                OnPropertyChanged(); 
            } 
        }
        #endregion

        #region Metodos
        public async Task RegistrarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Nome = Nome;
                u.PasswordString = Senha;

                Usuario uRegistrado = await uService.PostRegistrarUsuarioAsync(u);

                if (uRegistrado.Id != 0) 
                { 
                    string mensagem = $"Usuário Id {uRegistrado.Id} registrado com sucesso!";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage
                        .Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Nome = Nome;
                u.PasswordString = Senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Token)) 
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Nome}.";

                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioNome", uAutenticado.Nome);
                    Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);

                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "Ok");

                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :(", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes " + ex.InnerException, "Ok");
            }


        }
        #endregion
    }
}
