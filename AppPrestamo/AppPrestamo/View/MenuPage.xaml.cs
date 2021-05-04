
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

        private async void BtnPrestamoMenu_Clicked(object sender, System.EventArgs e)
        {

             await Navigation.PushAsync(new PrestamosPage());
        }

        private async void BtnClienteMenu_Clicked(object sender, System.EventArgs e)
        {
             await Navigation.PushAsync(new ClientePage());
        }

        private async void BtnPrestamoCancelado_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PrestamosCanceladosPage());
        }

        private  async void BtnPagosMenu_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PagosPage());
        }
    }

}