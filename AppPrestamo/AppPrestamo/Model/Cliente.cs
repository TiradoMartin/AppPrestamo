using SQLite;

namespace AppPrestamo.Model
{
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Unique]
        public string Identificacion { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        //Garante 
        public string NombreGarante { get; set; }
        public string ApellidoGarante { get; set; }
        public string IdentificacionGarante { get; set; }
        public string CelularGarante { get; set; }
        public string TelefonoGarante { get; set; }
        public string DireccionGarante { get; set; }

    }
}
