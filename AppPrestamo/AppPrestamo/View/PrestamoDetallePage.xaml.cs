using AppPrestamo.Model;
using AppPrestamo.Services;
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
    public partial class PrestamoDetallePage : ContentPage
    {
        FacturaPrestamo prestamo = new FacturaPrestamo();
        Prestamo prestamoPago = new Prestamo();
        

        public PrestamoDetallePage(Prestamo prestamo )
        {
            
            InitializeComponent();
            RepositoryPrestamoDetalle(prestamo);
           

        }

        public PrestamoDetallePage(Prestamo prestamo,bool print)
        {
           
            InitializeComponent();
            RepositoryPrestamoDetalle(prestamo);
            this.prestamo.print = print;

        }

        private async void RepositoryPrestamoDetalle(Prestamo prestamo)
        {
           float MontoPagado = 0, nCuotas = 0;
            prestamoPago = prestamo;
            entryIdentificacion.Text = prestamo.IdtificacionCliente;
            PrestamoRepository cliente= new PrestamoRepository();
            var client= await cliente.LeerCliente(prestamo.IdtificacionCliente);
            this.prestamo.nombreCliente = client.Nombre + " " + client.Apellido;
            entryClientNombre.Text = client.Nombre + " " + client.Apellido; 
            pikerTipoCobro.SelectedItem = prestamo.TipoDeCobro;
            dateInicio.Date = prestamo.FechaInicial;
            datefinal.Date = prestamo.FechaVencimiento;
            entryCapital.Text =Convert.ToString( prestamo.Capital);
            entryInteres.Text = Convert.ToString(prestamo.Interes);
            entryNCuotas.Text = Convert.ToString(prestamo.NumeroCuotas);
            entryTotal.Text = Convert.ToString(prestamo.Total);
            entryVCuotas.Text = Convert.ToString(prestamo.ValorCuota);

            PrestamoRepository listPago = new PrestamoRepository();
            ;
            foreach (var item in await listPago.LeerPagos(prestamo.Id))
            {
               this.prestamo.montoPagado+=item.MontoPagado;
                this.prestamo.totalCuotasPagadas += item.CantidadDePagos;
            }
           

       this.prestamo.Id = prestamo.Id;
       this.prestamo.TipoDeCobro = prestamo.TipoDeCobro;
       this.prestamo.FechaInicial = prestamo.FechaInicial;
       this.prestamo.FechaVencimiento = prestamo.FechaVencimiento;
       this.prestamo.Capital = prestamo.Capital;
       this.prestamo.Interes = prestamo.Interes;
       this.prestamo.NumeroCuotas = prestamo.NumeroCuotas;
       this.prestamo.ValorCuota = prestamo.ValorCuota;
       this.prestamo.Total = prestamo.Total;
       this.prestamo.IsActive = prestamo.IsActive;
       this.prestamo.IdtificacionCliente = prestamo.IdtificacionCliente;


            this.prestamo.deudaRestante = this.prestamo.Total - this.prestamo.montoPagado;
            entryCuotasPagadas.Text = Convert.ToString(this.prestamo.totalCuotasPagadas);
            entryTotalPagado.Text = Convert.ToString(this.prestamo.montoPagado);
            entryDeudaRestante.Text = Convert.ToString(this.prestamo.deudaRestante);
            
            if (this.prestamo.print) {
                PrintFile Print = new PrintFile(this.prestamo);
                printActivity.IsRunning = true;
                Print.Printing();
                printActivity.IsRunning = false;
            }
        }

        private void BtnPagos_Clicked(object sender, EventArgs e)
        {   
            Navigation.PushAsync(new PagosPage(prestamoPago,this.prestamo.deudaRestante));
        }
    }
}