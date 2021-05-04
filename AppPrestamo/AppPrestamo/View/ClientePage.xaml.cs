
using AppPrestamo.Model;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientePage : ContentPage
    {
        PrestamoRepository listCliente = new PrestamoRepository();
        public ClientePage()
        {
            InitializeComponent();
            RepositoryCliente();
        }

        private async void RepositoryCliente()
        {
            listViewCliente.ItemsSource = await listCliente.LeerClientes();

        }

        private void AddCliente_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RegistClientePage());
        }

        private void listViewCliente_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Cliente cliente =new Cliente();
            cliente = (Cliente) listViewCliente.SelectedItem;
            Navigation.PushAsync(new RegistClientePage(cliente));
        }

        private void Buscar_Clicked(object sender, System.EventArgs e)
        {
            SearchBarCliente.IsVisible = !SearchBarCliente.IsVisible;
        }

        private async void SearchBarCliente_SearchButtonPressed(object sender, System.EventArgs e)
        {
            List<Cliente> clientList = new List<Cliente>();
            if (SearchBarCliente.Text != "")
            {
                clientList.Add(await listCliente.LeerCliente(SearchBarCliente.Text));
                listViewCliente.ItemsSource = clientList;
            }
        }

        private void ActualizarCliente_Clicked(object sender, System.EventArgs e)
        {
            RepositoryCliente();
        }
    }
}