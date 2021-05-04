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
        PrestamoRepository PagoRegist = new PrestamoRepository();
        public PagosPage()
        {
            InitializeComponent();
        }
        public PagosPage(Prestamo prestamo)
        {
            this.prestamo = prestamo;
            InitializeComponent();

            entryIdPrestamo.Text = Convert.ToString( prestamo.Id);
            entryIdPrestamo.IsReadOnly = true;
            entryMonto.Text = Convert.ToString(prestamo.ValorCuota);

        }

        private void BtnPago_Clicked(object sender, EventArgs e)
        {
            Pago pago = new Pago();
            pago.IdPrestamo = int.Parse(entryIdPrestamo.Text);
            pago.CantidadDePagos = int.Parse(entryNcuotas.Text);
            if (pago.CantidadDePagos > 1 && int.Parse(entryMonto.Text) == prestamo.ValorCuota) { pago.MontoPagado = pago.CantidadDePagos * prestamo.ValorCuota; }
            else pago.MontoPagado = float.Parse(entryMonto.Text);
            PagoRegist.RegistrarPago(pago);
            DisplayAlert("Aviso", " Pago realizado con exito", "Ok");

         
            entryMonto.Text ="";
            entryNcuotas.Text = "";
            Navigation.PopAsync();
        }
    }
}