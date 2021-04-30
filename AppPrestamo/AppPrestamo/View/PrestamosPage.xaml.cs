
using AppPrestamo.Model;
using System.Collections.Generic;
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
            
            repository();
        }

       async void repository()
        {
            
             /*  client= await listPrestamo.LeerPrestamos();
           var v= client[0];*/
           listViewPrestamo.ItemsSource = await listPrestamo.LeerPrestamos();
           
        }

        private void AddPrestamo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegistPrestamo());
        }

        private void listViewPrestamo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void UpdateList_Clicked(object sender, System.EventArgs e)
        {
            repository();
        }
    }
}