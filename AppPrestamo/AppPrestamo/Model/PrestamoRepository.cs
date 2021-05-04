using AppPrestamo.Data;
using AppPrestamo.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPrestamo.Model
{
    class PrestamoRepository
    {



        public static PrestamoDataBase dataBase;

        public PrestamoRepository()
        {
            _ = DataBase;
        }



        public PrestamoDataBase DataBase
        {
            get
            {
                if (dataBase == null)

                {
                    dataBase = new PrestamoDataBase(DependencyService.Get<IFileHelper>().GetLocalFilePath("prestamodb.db"));
                    // dataBase = new PrestamoDataBase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Prestamo.db3"));


                }
                return dataBase;
            }


        }
        //Registro y Actualizacion 
        public async void RegistrarCliente(Cliente client)
        {

            await dataBase.CreateAndUdateClienteAsync(client);
        }

        public async void RegistrarPrestamo(Prestamo prestam)
        {

            await dataBase.CreateAndUdatePrestamo(prestam);
        }
        public async void RegistrarPago(Pago pago)
        {

            await dataBase.CreateAndUdatePago( pago);
        }

        // Leer

        public async Task<List<Pago>> LeerPagos(int PrestID)
        {
            return await dataBase.GetPagosAsync(PrestID);
        }
        public async Task<List<Cliente>> LeerClientes()
        {

            return await dataBase.GetClientesAsync();
        }

        public async Task<Cliente> LeerCliente(string indet)
        {

            return await dataBase.GetClienteAsync(indet);
        }
        public Task<List<Prestamo>> LeerPrestamos(string ident = "ident")
        {
            return dataBase.GetPrestamosAsync(ident);

        }
        public Task<List<Prestamo>> LeerPrestamosCancelados(string ident = "ident")
        {
            return dataBase.GetPrestamosCanceladosAsync(ident);
        }

    }
}
