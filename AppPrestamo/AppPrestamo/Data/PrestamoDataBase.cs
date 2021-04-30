using AppPrestamo.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppPrestamo.Data
{
    public class PrestamoDataBase
    {
        private readonly SQLiteAsyncConnection dataBase;

        public PrestamoDataBase(string dbPath)
        {
            dataBase = new SQLiteAsyncConnection(dbPath);
            dataBase.CreateTableAsync<Prestamo>().Wait();
            dataBase.CreateTableAsync<Cliente>().Wait();
            dataBase.CreateTableAsync<Pago>().Wait();
        }

        //Metodos Get de la base da datos prestamodb
        public Task<List<Cliente>> GetClientesAsync()
        {

            return dataBase.Table<Cliente>().ToListAsync();
        }

        public async Task<List<Prestamo>> GetPrestamosAsync()
        {
            return await dataBase.Table<Prestamo>().ToListAsync();
        }

        public async Task<List<Pago>> GetPagosAsync()
        {
            return await dataBase.Table<Pago>().ToListAsync();
        }

        public Task<Cliente> GetClienteAsync(string ident)
        {
            return dataBase.Table<Cliente>()
                .Where(i => i.Identificacion == ident).FirstOrDefaultAsync();
        }
        //Metodo Udate and Create

        public Task<int> CreateAndUdateClienteAsync(Cliente cliente)
        {
            if (cliente.Id != 0) return dataBase.UpdateAsync(cliente);
            else return dataBase.InsertAsync(cliente);

        }

        public Task<int> CreateAndUdatePrestamo(Prestamo prestamo)
        {
            if (prestamo.Id != 0) return dataBase.UpdateAsync(prestamo);
            else return dataBase.InsertAsync(prestamo);
        }

        public Task<int> CreateAndUdatePago(Pago pago)
        {
            if (pago.Id != 0) return dataBase.UpdateAsync(pago);
            else return dataBase.InsertAsync(pago);
        }

        // Metodo eliminar
        public Task<int> DeleteClienteAsync(Cliente cliente)
        {
            return dataBase.DeleteAsync(cliente.Id);

        }
        public Task<int> DeletePrestamoAsync(Prestamo prestamo)
        {
            return dataBase.DeleteAsync(prestamo.Id);
        }

        public Task<int> DeletePagoAsync(Pago pago)
        {
            return dataBase.DeleteAsync(pago.Id);
        }

    }
}

