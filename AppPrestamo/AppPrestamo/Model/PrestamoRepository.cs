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
            _ = DataBase;
            await dataBase.CreateAndUdateClienteAsync(client);
        }

        public async void RegistrarPrestamo(Prestamo prestam)
        {

            await dataBase.CreateAndUdatePrestamo(prestam);
        }
        // Leer
        public async Task<List<Cliente>> LeerClientes()
        {

            return await dataBase.GetClientesAsync();
        }

        public async Task<Cliente> LeerCliente(string indet)
        {

            return await dataBase.GetClienteAsync(indet);
        }
        public Task<List<Prestamo>> LeerPrestamos()
        {
            return dataBase.GetPrestamosAsync();

        }

    }
}
