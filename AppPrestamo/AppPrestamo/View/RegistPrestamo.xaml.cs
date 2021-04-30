using AppPrestamo.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistPrestamo : ContentPage
    {


        Prestamo prestamo = new Prestamo();
        PrestamoRepository registrarPrestamo = new PrestamoRepository();
        string mensaje = "Por favor verifique que los " +
            "campos del formulario no esten vacios  ";
        public RegistPrestamo()
        {


            InitializeComponent();
            pikerTipoCobro.SelectedItem = "Cobro Diario";
            dateInicio.Date = DateTime.Now;

        }


        private void CalcularPrestamo(object sender, EventArgs e)
        {
            if (entryCapital.Text == null || entryInteres.Text == null || entryNCuotas.Text == null || entryIdentificacion == null || entryIdentificacion == null) DisplayAlert("Aviso", mensaje, "ok");
            else
            {
                prestamo.TipoDeCobro = pikerTipoCobro.SelectedItem.ToString();
                prestamo.FechaInicial = dateInicio.Date;
                prestamo.FechaVencimiento = datefinal.Date;
                prestamo.Capital = int.Parse(entryCapital.Text);
                prestamo.Interes = float.Parse(entryInteres.Text);
                prestamo.NumeroCuotas = int.Parse(entryNCuotas.Text);
                prestamo.IsActive = true;
                //Operaciones
                prestamo.Total = (prestamo.Capital * prestamo.Interes) / 100 + prestamo.Capital;
                prestamo.ValorCuota = prestamo.Total / prestamo.NumeroCuotas;
                entryVCuotas.Text = Convert.ToString(prestamo.ValorCuota);
                entryTotal.Text = Convert.ToString(prestamo.Total);
                BtnCrearPrestamo.IsEnabled = true;
            }
        }

        private void BtnCrearPrestamo_Clicked(object sender, EventArgs e)
        {

            registrarPrestamo.RegistrarPrestamo(prestamo);
            entryIdentificacion.Text = ""; entryClientNombre.Text = ""; entryCapital.Text = ""; entryInteres.Text = "";
            entryNCuotas.Text = ""; entryVCuotas.Text = ""; entryTotal.Text = "";
            DisplayAlert("Aviso", "Prestamo registrado", "Ok");

        }

        private async void entryIdentificacion_Completed(object sender, EventArgs e)
        {
            Cliente client;
            if (entryIdentificacion.Text != null)
            {
                client = await registrarPrestamo.LeerCliente(entryIdentificacion.Text);
                if (client != null)
                {

                    entryClientNombre.Text = client.Nombre;
                    prestamo.IdtificacionCliente = client.Identificacion;
                }
                else await DisplayAlert("Aviso", "No se encontro el cliente", "Ok");


            }
            else await DisplayAlert("Aviso", "El campo identificacion no puede estar vacio", "Ok");




        }
    }
}