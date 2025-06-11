using ibz_backend.Models;
using System;
using System.Data;
using System.Data.SqlClient;



namespace ibz_backend.Data
{
    public class variosData
    {

        private readonly string conexion;

        public variosData(IConfiguration configuration)// sirve para acceder al archivo de appsettings.json
        {
            conexion = configuration.GetConnectionString("cadenaSQL")!; // el simbolo "!" es para indicar que el string nunca sera null
        }

        public async Task<List<Genero>> get_genero()
        {
            List<Genero> lista = new List<Genero>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("get_genero", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Genero
                        {
                            idgenero = Convert.ToInt32(reader["idgenero"]),
                            descripcion = reader["descripcion"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public async Task<List<EstadoCivil>> get_estadoCivil()
        {
            List<EstadoCivil> lista = new List<EstadoCivil>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("get_estadoCivil", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new EstadoCivil
                        {
                            idestado = Convert.ToInt32(reader["idestado"]),
                            descripcion = reader["descripcion"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public async Task<List<Departamento>> get_departamento()
        {
            List<Departamento> lista = new List<Departamento>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("get_departamento", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Departamento
                        {
                            iddepartamento = Convert.ToInt32(reader["iddepartamento"]),
                            descripcion = reader["descripcion"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public async Task<List<Municipio>> get_municipios(int _iddepartamento)
        {
            List<Municipio> lista = new List<Municipio>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("get_municipios", con);
                cmd.Parameters.AddWithValue("@iddepartamento", _iddepartamento);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Municipio
                        {
                            iddepartamento = Convert.ToInt32(reader["iddepartamento"]),
                            idmunicipio = Convert.ToInt32(reader["idmunicipio"]),
                            descripcion = reader["descripcion"].ToString(),
                        });
                    }
                }
            }

            return lista;
        }


    }
}
