namespace ibz_backend.Models
{
    public class Miembros
    {
        public int? idmiembro { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public int idgenero { get; set; }
        public int idestado { get; set; }
        public string? telefono { get; set; }
        public string? correo { get; set; }
        public string? direccion { get; set; }
        public DateTime? fecha_ingreso { get; set; }
        public bool bautizado { get; set; }
        public DateTime? fecha_bautizo { get; set; }
        public bool activo { get; set; }
        public int idmunicipio { get; set; }
        public int iddepartamento { get; set; }
    }
}