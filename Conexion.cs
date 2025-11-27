using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Conexion
    {
        DatosDeConexion datos = new DatosDeConexion();
        
        public Empleado FindUser(string username, string password)
        {
            using(MySqlConnection connection = new MySqlConnection(datos.Datos()))
            {
                connection.Open();
                string query = "SELECT * FROM EMPLEADOS WHERE USERNAME = @username AND PASSWORD = SHA2(@password, 256) LIMIT 1";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Empleado
                            (
                                Convert.ToInt32(reader["ID_EMPLEADO"]),
                                reader["NOMBRE"].ToString(),
                                reader["APELLIDOS"].ToString(),
                                reader["USERNAME"].ToString(),
                                Convert.ToBoolean(reader["SUPER_USER"]),
                                Convert.ToBoolean(reader["ACTIVO"])
                            );
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public bool CrearEmpleado(Empleado nuevoEmpleado)
        {
            using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
            {
                connection.Open();
                string query = "INSERT INTO EMPLEADOS (NOMBRE, APELLIDOS, USERNAME, PASSWORD, SUPERUSER) " +
                    "VALUES (@nombre, @apellido, @username, @password, @superuser)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nuevoEmpleado.GetNombre());
                    command.Parameters.AddWithValue("@apellido", nuevoEmpleado.GetApellido());
                    command.Parameters.AddWithValue("@username", nuevoEmpleado.GetUsername());
                    command.Parameters.AddWithValue("@password", nuevoEmpleado.GetPassword());
                    command.Parameters.AddWithValue("@superuser", nuevoEmpleado.IsSuperUser());
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.RecordsAffected > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
