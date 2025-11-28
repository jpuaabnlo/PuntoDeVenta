using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace PuntoDeVenta
{
    internal class Conexion
    {
        DatosDeConexion datos = new DatosDeConexion();
        /// <summary>
        /// Finds and retrieves an employee based on the provided username and password.
        /// </summary>
        /// <remarks>The method performs a case-sensitive search for an employee in the database using the
        /// provided credentials. The password is hashed using SHA-256 before being compared to the stored value. Ensure
        /// that the database connection string is properly configured and that the credentials are valid.</remarks>
        /// <param name="username">The username of the employee to find. Cannot be null or empty.</param>
        /// <param name="password">The password of the employee to find. Cannot be null or empty.</param>
        /// <returns>An <see cref="Empleado"/> object representing the employee if the username and password match an existing
        /// record; otherwise, <see langword="null"/>.</returns>
        public Empleado FindUser(string username, string password)
        {
            using(MySqlConnection connection = new MySqlConnection(datos.Datos()))
            {
                connection.Open();
                password = Sha256Hash(password);
                string query = "SELECT * FROM EMPLEADOS WHERE USERNAME = @username AND PASSWORD = @password LIMIT 1";
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
        /// <summary>
        /// Creates a new employee record in the database.
        /// </summary>
        /// <remarks>This method uses a stored procedure named "SP_CREAR_EMPLEADO" to insert the employee
        /// data into the database. The password is hashed using SHA-256 before being stored. Ensure that the database
        /// connection string is properly configured and that the stored procedure exists and is accessible.</remarks>
        /// <param name="nuevoEmpleado">An instance of the <see cref="Empleado"/> class containing the details of the employee to be created. The
        /// properties <see cref="Empleado.Nombre"/>, <see cref="Empleado.Apellido"/>, <see cref="Empleado.Username"/>, 
        /// <see cref="Empleado.Password"/>, and <see cref="Empleado.SuperUser"/> must be set.</param>
        /// <returns><see langword="true"/> if the employee record was successfully created; otherwise, <see langword="false"/>.</returns>
        public bool CrearEmpleado(Empleado nuevoEmpleado)
        {
            using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
            {
                connection.Open();
                string query = "SP_CREAR_EMPLEADO";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nuevoEmpleado.Nombre);
                    command.Parameters.AddWithValue("@apellido", nuevoEmpleado.Apellido);
                    command.Parameters.AddWithValue("@username", nuevoEmpleado.Username);
                    command.Parameters.AddWithValue("@password", Sha256Hash(nuevoEmpleado.Password));
                    command.Parameters.AddWithValue("@superuser", nuevoEmpleado.SuperUser);
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

        /// <summary>
        /// Computes the SHA-256 hash of the specified password string and returns it as a hexadecimal string.
        /// </summary>
        /// <remarks>This method uses the SHA-256 cryptographic hash function to generate a fixed-length
        /// hash value from the input string. The resulting hash is represented as a lowercase hexadecimal
        /// string.</remarks>
        /// <param name="password">The input string to hash. Cannot be <see langword="null"/>.</param>
        /// <returns>A hexadecimal string representation of the SHA-256 hash of the input string.</returns>
        private static string Sha256Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
