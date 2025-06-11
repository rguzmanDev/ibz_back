using ibz_backend.Models;
using System;
using System.Data;
using System.Data.SqlClient;


namespace ibz_backend.Data
{
    public class miembroData
    {

        private readonly string conexion;

        public miembroData(IConfiguration configuration)// sirve para acceder al archivo de appsettings.json
        {
            conexion = configuration.GetConnectionString("cadenaSQL")!; // el simbolo "!" es para indicar que el string nunca sera null
        }

        public async Task<List<Miembros>> get_listarMiembros()
        {
            List<Miembros> lista = new List<Miembros>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync(); //indica que la conexion puede abrirse
                SqlCommand cmd = new SqlCommand("get_listarMiembros", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync()) 
                {
                    while ( await reader.ReadAsync())
                    {
                        lista.Add(new Miembros
                        {
                            idmiembro = Convert.ToInt32(reader["idmiembro"]),
                            nombres = reader["nombres"].ToString(),
                            apellidos = reader["apellidos"].ToString(),
                            activo = Convert.ToBoolean(reader["activo"]),
                            bautizado = Convert.ToBoolean(reader["bautizado"]),
                            correo = reader["correo"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            telefono = reader["telefono"].ToString(),
                            fecha_bautizo = Convert.ToDateTime(reader["fecha_bautizo"]),
                            fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                            fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                            iddepartamento = Convert.ToInt32(reader["iddepartamento"]),
                            idestado = Convert.ToInt32(reader["idestado"]),
                            idgenero = Convert.ToInt32(reader["idgenero"]),
                            idmunicipio = Convert.ToInt32(reader["idmunicipio"]),

                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Miembros> get_miembro(int _idmiembro)
        {
            Miembros objeto= new Miembros();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync(); 
                SqlCommand cmd = new SqlCommand("get_miembro", con);
                cmd.Parameters.AddWithValue("@idMiembro", _idmiembro);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        objeto = new Miembros
                        {
                            idmiembro = Convert.ToInt32(reader["idmiembro"]),
                            nombres = reader["nombres"].ToString(),
                            apellidos = reader["apellidos"].ToString(),
                            activo = Convert.ToBoolean(reader["activo"]),
                            bautizado = Convert.ToBoolean(reader["bautizado"]),
                            correo = reader["correo"].ToString(),
                            direccion = reader["direccion"].ToString(),
                            telefono = reader["telefono"].ToString(),  // <-- Aquí
                            fecha_bautizo = Convert.ToDateTime(reader["fecha_bautizo"]),
                            fecha_ingreso = Convert.ToDateTime(reader["fecha_ingreso"]),
                            fecha_nacimiento = Convert.ToDateTime(reader["fecha_nacimiento"]),
                            iddepartamento = Convert.ToInt32(reader["iddepartamento"]),
                            idestado = Convert.ToInt32(reader["idestado"]),
                            idgenero = Convert.ToInt32(reader["idgenero"]),
                            idmunicipio = Convert.ToInt32(reader["idmunicipio"]),
                        };

                    }
                }
            }
            return objeto;
        }

        public async Task<bool> create_miembro(Miembros objeto)

        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("create_miembro", con);
                cmd.Parameters.AddWithValue("@nombres", objeto.nombres);
                cmd.Parameters.AddWithValue("@apellidos", objeto.apellidos);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", objeto.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@idgenero", objeto.idgenero);
                cmd.Parameters.AddWithValue("@idestado", objeto.idestado);
                cmd.Parameters.AddWithValue("@telefono", objeto.telefono);
                cmd.Parameters.AddWithValue("@correo", objeto.correo);
                cmd.Parameters.AddWithValue("@direccion", objeto.direccion);
                cmd.Parameters.AddWithValue("@fecha_ingreso", objeto.fecha_ingreso);
                cmd.Parameters.AddWithValue("@bautizado", objeto.bautizado);
                cmd.Parameters.AddWithValue("@fecha_bautizo", objeto.fecha_bautizo);
                cmd.Parameters.AddWithValue("@activo", objeto.activo);
                cmd.Parameters.AddWithValue("@idmunicipio", objeto.idmunicipio);
                cmd.Parameters.AddWithValue("@iddepartamento", objeto.iddepartamento);
                cmd.CommandType = CommandType.StoredProcedure;

                try {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true: false;

                }
                catch(Exception ex) { 
                    respuesta=false;
                    Console.WriteLine($"Error en create_miembro: {ex.Message}");
                }

                return respuesta;
            }
        }

        public async Task<bool> update_miembro(Miembros objeto)

        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("update_miembro", con);
                cmd.Parameters.AddWithValue("@idmiembro", objeto.idmiembro);
                cmd.Parameters.AddWithValue("@nombres", objeto.nombres);
                cmd.Parameters.AddWithValue("@apellidos", objeto.apellidos);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", objeto.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@idgenero", objeto.idgenero);
                cmd.Parameters.AddWithValue("@idestado", objeto.idestado);
                cmd.Parameters.AddWithValue("@telefono", objeto.telefono);
                cmd.Parameters.AddWithValue("@correo", objeto.correo);
                cmd.Parameters.AddWithValue("@direccion", objeto.direccion);
                cmd.Parameters.AddWithValue("@fecha_ingreso", objeto.fecha_ingreso);
                cmd.Parameters.AddWithValue("@bautizado", objeto.bautizado);
                cmd.Parameters.AddWithValue("@fecha_bautizo", objeto.fecha_bautizo);
                cmd.Parameters.AddWithValue("@activo", objeto.activo);
                cmd.Parameters.AddWithValue("@idmunicipio", objeto.idmunicipio);
                cmd.Parameters.AddWithValue("@iddepartamento", objeto.iddepartamento);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;

                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Console.WriteLine($"Error en update_miembro: {ex.Message}");
                }

                return respuesta;
            }
        }

        public async Task<bool> delete_miembro(int _idmiembro)

        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("delete_miembro", con);
                cmd.Parameters.AddWithValue("@idmiembro", _idmiembro);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;

                }
                catch (Exception ex)
                {
                    respuesta = false;
                    Console.WriteLine($"Error en delete_miembro: {ex.Message}");
                }

                return respuesta;
            }
        }
    }
}