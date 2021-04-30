using SQLite;

namespace AppPrestamo.Model
{
    public class Pago
    {
        public int Id { get; set; }
        [Indexed]
        public int IdPrestamo { get; set; }
        public int CantidadDePagos { get; set; }
        public int MontoPagado { get; set; }
    }
}
