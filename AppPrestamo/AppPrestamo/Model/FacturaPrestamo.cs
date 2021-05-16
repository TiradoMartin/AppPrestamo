using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrestamo.Model
{
   public class FacturaPrestamo:Prestamo
    {
      
    
        public FacturaPrestamo() { }
       public int totalCuotasPagadas { get; set; }
       public float montoPagado { get; set; }
       public float deudaRestante { get; set; }
       public bool print { get; set; }
        public string nombreCliente { get; set; }
    }
}
