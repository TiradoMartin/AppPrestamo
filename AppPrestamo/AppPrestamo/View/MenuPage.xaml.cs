
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtnPrestamoMenu_Clicked(object sender, System.EventArgs e)
        {

              Navigation.PushAsync(new PrestamosPage());
        }

        private void BtnClienteMenu_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ClientePage());
        }
    }

}