
using AppPrestamo.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistClientePage : ContentPage
    {
        Cliente cliente = new Cliente();
        public RegistClientePage()
        {
            InitializeComponent();
        }

        public RegistClientePage(Cliente cliente)
        {

            InitializeComponent();
            this.cliente.Id = cliente.Id;
            nombreCliente.Text = cliente.Nombre;
           apellCliente.Text = cliente.Apellido;
            celularCliente.Text= cliente.Celular;
            telefonoCliente.Text = cliente.Telefono;
            direccionCliente.Text = cliente.Direccion;
            CedulaCliente.Text= cliente.Identificacion;
            //Datos del Garante
             nombreGarante.Text= cliente.NombreGarante;
            apellGarante.Text = cliente.ApellidoGarante;
            celularGarante.Text= cliente.CelularGarante;
            telefonoGarante.Text = cliente.TelefonoGarante;
            direccionGarante.Text = cliente.DireccionGarante;
            CedulaGarante.Text = cliente.IdentificacionGarante;


        }
        private void BtnRegistrarCliente_Clicked(object sender, EventArgs e)
        {
            if (nombreCliente.Text != null || apellCliente.Text != null || CedulaCliente.Text != null)
            {
                
                cliente.Nombre = nombreCliente.Text;
                cliente.Apellido = apellCliente.Text;
                cliente.Celular = celularCliente.Text;
                cliente.Telefono = telefonoCliente.Text;
                cliente.Direccion = direccionCliente.Text;
                cliente.Identificacion = CedulaCliente.Text;
                //Datos del Garante
                cliente.NombreGarante = nombreGarante.Text;
                cliente.ApellidoGarante = apellGarante.Text;
                cliente.CelularGarante = celularGarante.Text;
                cliente.TelefonoGarante = telefonoGarante.Text;
                cliente.DireccionGarante = direccionGarante.Text;
                cliente.IdentificacionGarante = CedulaGarante.Text;
                PrestamoRepository registClient = new PrestamoRepository();
                registClient.RegistrarCliente(cliente);
                MenssageAndResetControl();
            }
            else DisplayAlert("Aviso", "Los campos de identificacion, " +
                "nombre y apellido del cliente no pueden estar vacios", "Ok");
        }

        public void MenssageAndResetControl()
        {
            nombreCliente.Text = "";
            apellCliente.Text = "";
            celularCliente.Text = "";
            telefonoCliente.Text = "";
            direccionCliente.Text = "";
            CedulaCliente.Text = "";
            nombreGarante.Text = "";
            apellGarante.Text = "";
            celularGarante.Text = "";
            telefonoGarante.Text = "";
            direccionGarante.Text = "";
            CedulaGarante.Text = "";
            DisplayAlert("Aviso", "El cliente se a guardado correctamente", "Ok");
        }
    }
}
