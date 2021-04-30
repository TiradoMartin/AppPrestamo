using System;
using Xamarin.Forms;

namespace AppPrestamo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Autentication(object sender, EventArgs e)
        {
            string user = inputName.Text;
            string pass = inputPass.Text;
            if (user == "Martin" && pass == "Martin") Navigation.PushAsync(new View.MenuPage());
            else DisplayAlert("Aviso", "El usuario o la contraseña no es correcto. Por favor intentelo de nuevo", "Aceptar");
        }
    }
}
