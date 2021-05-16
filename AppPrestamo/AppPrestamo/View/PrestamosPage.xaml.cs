
using AppPrestamo.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrestamosPage : ContentPage
    {
        PrestamoRepository listPrestamo = new PrestamoRepository();
        public PrestamosPage()
        {
            InitializeComponent();

            RepositoryPrestamo();
        }

        async void RepositoryPrestamo()
        {

            /*  client= await listPrestamo.LeerPrestamos();
          var v= client[0];*/
            listViewPrestamo.ItemsSource = await listPrestamo.LeerPrestamos();

        }

        private void AddPrestamo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegistPrestamo());
        }

        private async void listViewPrestamo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           Prestamo prestamo = new Prestamo();
               prestamo = (Prestamo)listViewPrestamo.SelectedItem;
           await Navigation.PushAsync(new PrestamoDetallePage(prestamo));
        }

        private void UpdateList_Clicked(object sender, System.EventArgs e)
        {
            RepositoryPrestamo();
        }

        private void Buscar_Clicked(object sender, System.EventArgs e)
        {
            searchBarPrestamo.IsVisible = !searchBarPrestamo.IsVisible;
        }

        private async void SearchBarPrestamo_SearchButtonPressed(object sender, System.EventArgs e)
        {
            if (searchBarPrestamo.Text != "")
            { listViewPrestamo.ItemsSource = await listPrestamo.LeerPrestamos(searchBarPrestamo.Text); }


        }
    }
}