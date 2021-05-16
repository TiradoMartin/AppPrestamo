using AppPrestamo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPrestamo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagosPage : ContentPage
    {
       Prestamo prestamo = new Prestamo();
        bool print;
        float deudaRestante = 0;

        PrestamoRepository PagoRegist = new PrestamoRepository();
        public PagosPage()
        {
            InitializeComponent();
        }
        public PagosPage(Prestamo prestamo,float deudaRestante)
        {
            this.deudaRestante = deudaRestante;
            this.prestamo = prestamo;
            print = false;
            InitializeComponent();
          
            entryIdPrestamo.Text = Convert.ToString( prestamo.Id);
            entryIdPrestamo.IsReadOnly = true;
            entryMonto.Text = Convert.ToString(prestamo.ValorCuota);


        }

        private void BtnPago_Clicked(object sender, EventArgs e)
        {
            Pago pago = new Pago();
            if (entryIdPrestamo.Text == null || entryNcuotas.Text == null || entryMonto.Text == null) { DisplayAlert("Alerta", "No puede dejar ningun campo vacio", " Ok"); }
            else
            {
                pago.IdPrestamo = int.Parse(entryIdPrestamo.Text);
                pago.CantidadDePagos = int.Parse(entryNcuotas.Text);
                if (pago.CantidadDePagos > 1 && int.Parse(entryMonto.Text) == prestamo.ValorCuota) { pago.MontoPagado = pago.CantidadDePagos * prestamo.ValorCuota; }
                else pago.MontoPagado = float.Parse(entryMonto.Text);
                PagoRegist.RegistrarPago(pago);
                DisplayAlert("Aviso", " Pago realizado con exito", "Ok");
               
                if (this.deudaRestante - pago.MontoPagado <= 0)
                {
                    //Desactivando el prestamo si la deuda se paga por completo.
                    this.prestamo.IsActive = false;
                    PagoRegist.RegistrarPrestamo(this.prestamo);
                }

                entryMonto.Text = "";
                entryNcuotas.Text = "";
                Navigation.PushAsync(new PrestamoDetallePage(prestamo, print));

            }
        }

        private void SwitchPago_Toggled(object sender, ToggledEventArgs e)
        {
            print = !print;
        }
    }
}