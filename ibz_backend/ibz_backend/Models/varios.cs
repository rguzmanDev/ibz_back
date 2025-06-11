namespace ibz_backend.Models
{
    public class EstadoCivil
    {
        public int idestado { get; set; }
        public string? descripcion { get; set; }
    }

    public class Genero
    {
        public int idgenero { get; set; }
        public string? descripcion { get; set; }
    }

    public class Municipio
    {
        public int idmunicipio { get; set; }
        public int iddepartamento { get; set; }
        public string? descripcion { get; set; }
    }

    public class Departamento
    {
        public int iddepartamento { get; set; }
        public string? descripcion { get; set; }
    }
}
