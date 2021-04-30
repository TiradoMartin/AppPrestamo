using SQLite;
using System;

namespace AppPrestamo.Model
{
    public class Prestamo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TipoDeCobro { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Capital { get; set; }
        public float Interes { get; set; }
        public int NumeroCuotas { get; set; }
        public float ValorCuota { get; set; }
        public float Total { get; set; }
        public bool IsActive { get; set; }
        [Indexed]
        public string IdtificacionCliente { get; set; }

    }
}
