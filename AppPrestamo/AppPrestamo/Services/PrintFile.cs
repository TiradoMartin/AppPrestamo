using AppPrestamo.Model;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using ESCPOS_NET.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace AppPrestamo.Services
{
  

    class PrintFile
    {
        FacturaPrestamo prestamo;
        static NetworkPrinter  printer;
       public PrintFile(FacturaPrestamo prestamo){
            this.prestamo = prestamo;
         
            _ = Printer;
        
        }

        public NetworkPrinter Printer
        {
            get
            {
                if (printer == null)
                {
                    printer = new NetworkPrinter(ipAddress: "192.168.1.50", port: 9000, reconnectOnTimeout: true);

                }
                return printer;
            }
            
           
        }


        public void Printing() {
            EPSON e = new EPSON();
            printer.Write(
                ByteSplicer.Combine(
                    e.CenterAlign(),
                    e.SetBarcodeHeightInDots(360),
                    e.PrintLine("----------------------------------------------------"),
                    e.SetBarWidth(BarWidth.Default),
                    e.SetBarLabelPosition(BarLabelPrintPosition.None),
                    e.PrintBarcode(BarcodeType.ITF, "0123456789"),
                    e.PrintLine("Fecha" + DateTime.Now),
                    e.PrintLine("No:  " + prestamo.Id),
                    e.PrintLine("Identificacion del cliente  "+ prestamo.IdtificacionCliente),
                    e.PrintLine("Nombre del cliente  " + prestamo.nombreCliente),
                    e.PrintLine(""),
                    e.PrintLine("Tipo de cobro " + prestamo.TipoDeCobro),
                    e.PrintLine("Capital prestado " + prestamo.Capital),
                    e.PrintLine("Interes " + prestamo.Interes),
                    e.PrintLine("Numero de cuotas  " + prestamo.NumeroCuotas),
                    e.PrintLine("Valor de la cuotas " + prestamo.ValorCuota),
                    e.PrintLine("Total de cuotas pagadas  " + prestamo.totalCuotasPagadas),
                    e.PrintLine("Monto Pagado hasta la fecha " + prestamo.montoPagado),
                    e.PrintLine("Deuda pendiente "+prestamo.deudaRestante),
                    e.PrintLine("----------------------------------------------------")

             ) 
                );

            
        
        }


    }



}





