using AppPrestamo.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrestamosCanceladosPage : ContentPage
    {
        PrestamoRepository listPrestamoCancel = new PrestamoRepository();
        public PrestamosCanceladosPage()
        {
            InitializeComponent();
            RepositoryPrestamoCancel();
        }
        private async void RepositoryPrestamoCancel()
        {

            listViewPrestamoCancelados.ItemsSource = await listPrestamoCancel.LeerPrestamosCancelados();

        }

        private void Buscar_Clicked(object sender, EventArgs e)
        {
            searchBarPrestamoCancelados.IsVisible = !searchBarPrestamoCancelados.IsVisible;

        }

        private async void searchBarPrestamo_SearchButtonPressed(object sender, EventArgs e)
        {
            if (searchBarPrestamoCancelados.Text != "") listViewPrestamoCancelados.ItemsSource = await listPrestamoCancel.LeerPrestamosCancelados(searchBarPrestamoCancelados.Text);

        }

        private async void listViewPrestamoCancelados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        { Prestamo prestamo = new Prestamo();

            prestamo = (Prestamo)listViewPrestamoCancelados.SelectedItem;

            bool respuesta = await DisplayAlert("Alerta","Esta seguro de reactivar el prestamo número "+prestamo.Id,"Activar","Cancelar");
            if (respuesta) { 
                prestamo.IsActive = true;
                listPrestamoCancel.RegistrarPrestamo(prestamo);
               await DisplayAlert("Aviso", "el prestamo fue activado", "Ok");
                    }

                }
        private void UdateList_Clicked(object sender, EventArgs e)
        {
            RepositoryPrestamoCancel();
        }

       
    }
}