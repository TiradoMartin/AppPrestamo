
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePage : ContentPage
    {
        public ClientePage()
        {
            InitializeComponent();
        }

        private void AddCliente_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegistClientePage());
        }
    }
}