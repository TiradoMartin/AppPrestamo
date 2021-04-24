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
    public partial class RegistPrestamo : ContentPage
    {
        public RegistPrestamo()
        {
            InitializeComponent();
            
        }
          
        private void calcularPrestamo(object sender, EventArgs e)
        {
            int capital = int.Parse(entryCapital.Text);
            float interes = float.Parse(entryInteres.Text);
            int nCuotas = int.Parse(entryNCuotas.Text);
            float total, valorCuota;
           
           total = (capital * interes) / 100 + capital;
            valorCuota = total / nCuotas;
            entryVCuotas.Text =Convert.ToString(valorCuota);
            entryTotal.Text = Convert.ToString(total);
        }
    }
}