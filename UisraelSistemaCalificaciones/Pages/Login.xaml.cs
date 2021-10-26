using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UisraelSistemaCalificaciones
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Declarar variables
                string TxtUser = txtUser.Text;
                string TxtPassword = txtPassword.Text;

                //Vlidar campos vacìos o nulos
                validateNullOrEmpty(TxtUser);
                validateNullOrEmpty(TxtPassword);

                //Verificar contraseña
               await validateAccess(TxtUser, TxtPassword);
            }
            catch (Exception ex)
            {
               await DisplayAlert("No se pudo realizar la operaciòn", ex.Message, "Ok");
            }
        }

        private void validateNullOrEmpty(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new Exception($"Ingrese los valores solicitados");
            }
        }

        private async Task validateAccess(string user, string password)
        {
            if (user == "estudiante2021" && password == "uisrael2021")
            {
                await Navigation.PushAsync(new Calificaciones(user));
            }
            else
            {
                throw new Exception($"Las credenciales son incorrectas");
            }
        }
    }
}