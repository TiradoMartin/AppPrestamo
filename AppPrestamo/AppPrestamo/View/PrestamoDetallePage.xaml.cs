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
    public partial class PrestamoDetallePage : ContentPage
    {
        Prestamo prestamo = new Prestamo();

        public PrestamoDetallePage(Prestamo prestamo )
        {
            
            InitializeComponent();
            RepositoryPrestamoDetalle(prestamo);


        }

        private async void RepositoryPrestamoDetalle(Prestamo prestamo)
        {
            float MontoPagado = 0, nCuotas = 0;
            entryIdentificacion.Text = prestamo.IdtificacionCliente;
            PrestamoRepository cliente= new PrestamoRepository();
            var client= await cliente.LeerCliente(prestamo.IdtificacionCliente);
            entryClientNombre.Text = client.Nombre;
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
               MontoPagado+=item.MontoPagado;
                nCuotas += item.CantidadDePagos;
            }
            this.prestamo = prestamo;
            entryCuotasPagadas.Text = Convert.ToString(nCuotas);
            entryTotalPagado.Text = Convert.ToString(MontoPagado);
            entryDeudaRestante.Text = Convert.ToString(prestamo.Total - MontoPagado);
        }

        private void BtnPagos_Clicked(object sender, EventArgs e)
        {   
            Navigation.PushAsync(new PagosPage(this.prestamo));
        }
    }
}