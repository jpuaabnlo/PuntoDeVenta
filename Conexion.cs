using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;

namespace PuntoDeVenta
{
    internal class Conexion
    {
        DatosDeConexion datos = new DatosDeConexion();

        /// <summary>
        /// Retrieves an employee record from the database that matches the specified username and password.
        /// </summary>
        /// <remarks>The method hashes the provided password using SHA-256 before comparing it with the
        /// stored password in the database. The search is case-sensitive and limited to one matching record.</remarks>
        /// <param name="username">The username of the employee to find. This value cannot be null or empty.</param>
        /// <param name="password">The password of the employee to find. This value cannot be null or empty.</param>
        /// <returns>An <see cref="Empleado"/> object representing the employee if a matching record is found; otherwise, <see
        /// langword="null"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while connecting to or querying the database.</exception>
        public Empleado FindUser(string username, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
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
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }


        public List<Libro> GetLibros()
        {
            try
            {
                List<Libro> libros = new List<Libro>();
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SELECT * FROM LIBROS WHERE ACTIVO = TRUE";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                libros.Add(
                                    new Libro(
                                        Convert.ToString(reader["ISBN"]),
                                        reader["NOMBRE"].ToString(),
                                        reader["AUTOR"].ToString(),
                                        reader["DESCRIPCION"].ToString(),
                                        Convert.ToDecimal(reader["PRECIO"]),
                                        Convert.ToInt32(reader["STOCK"]),
                                        Convert.ToBoolean(reader["ACTIVO"])
                                    )
                                );
                            }
                        }
                    }
                }
                return libros;
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }
        public static MySqlConnection GetConnection()
        {
            DatosDeConexion d = new DatosDeConexion();
            return new MySqlConnection(d.Datos());
        }

        public List<Libro> FindLibro(string keyword)
        {
            try
            {
                Console.WriteLine(keyword);
                List<Libro> libros = new List<Libro>();
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SELECT * FROM LIBROS WHERE ISBN LIKE @keyword OR NOMBRE LIKE @keyword OR AUTOR LIKE @keyword OR DESCRIPCION LIKE @keyword";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                libros.Add(
                                    new Libro(
                                        Convert.ToString(reader["ISBN"]),
                                        reader["NOMBRE"].ToString(),
                                        reader["AUTOR"].ToString(),
                                        reader["DESCRIPCION"].ToString(),
                                        Convert.ToDecimal(reader["PRECIO"]),
                                        Convert.ToInt32(reader["STOCK"]),
                                        Convert.ToBoolean(reader["ACTIVO"])
                                    )
                                );
                            }
                        }
                    }
                }
                return libros;
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        public bool ExisteISBN(string isbn)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SELECT 1 FROM LIBROS WHERE ISBN = @isbn LIMIT 1";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isbn", isbn);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        public bool CrearLibro(Libro nuevoLibro)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SP_CREAR_LIBRO";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("P_ISBN", nuevoLibro.ISBN);
                        command.Parameters.AddWithValue("P_NOMBRE", nuevoLibro.Nombre);
                        command.Parameters.AddWithValue("P_AUTOR", nuevoLibro.Autor);
                        command.Parameters.AddWithValue("P_DESCRIPCION", nuevoLibro.Descripcion);
                        command.Parameters.AddWithValue("P_PRECIO", nuevoLibro.Precio);
                        command.Parameters.AddWithValue("P_STOCK", nuevoLibro.Stock);
                        int filasAfectadas = command.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actualizarLibro"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool ActualizarLibro(Libro actualizarLibro)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SP_ACTUALIZAR_LIBRO";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("P_ISBN", actualizarLibro.ISBN);
                        command.Parameters.AddWithValue("P_NOMBRE", actualizarLibro.Nombre);
                        command.Parameters.AddWithValue("P_AUTOR", actualizarLibro.Autor);
                        command.Parameters.AddWithValue("P_DESCRIPCION", actualizarLibro.Descripcion);
                        command.Parameters.AddWithValue("P_PRECIO", actualizarLibro.Precio);
                        command.Parameters.AddWithValue("P_STOCK", actualizarLibro.Stock);
                        command.Parameters.AddWithValue("P_ACTIVO", actualizarLibro.Activo);
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        public void EliminarLibro(string isbn)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "UPDATE LIBROS SET ACTIVO = FALSE WHERE ISBN = @isbn";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@isbn", isbn);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Retrieves a list of active employees from the database.
        /// </summary>
        /// <remarks>This method queries the database for employees where the "ACTIVO" field is set to
        /// <see langword="true"/>. It returns a list of <see cref="Empleado"/> objects representing the active
        /// employees.</remarks>
        /// <returns>A list of <see cref="Empleado"/> objects representing the active employees.  The list will be empty if no
        /// active employees are found.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while connecting to the database or executing the query.</exception>
        public List<Empleado> GetEmpleadosActivos()
        {
            try
            {
                List<Empleado> empleados = new List<Empleado>();
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SELECT * FROM EMPLEADOS WHERE ACTIVO = TRUE";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empleados.Add(
                                    new Empleado(
                                           Convert.ToInt32(reader["ID_EMPLEADO"]),
                                           reader["NOMBRE"].ToString(),
                                           reader["APELLIDOS"].ToString(),
                                           reader["USERNAME"].ToString(),
                                           Convert.ToBoolean(reader["SUPER_USER"]),
                                           Convert.ToBoolean(reader["ACTIVO"])
                                    )
                                );
                            }
                        }
                    }
                }
                return empleados;
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Searches for employees whose name, surname, or username matches the specified keyword.
        /// </summary>
        /// <remarks>This method performs a database query to search for employees whose name, surname, or
        /// username contains  the specified keyword. The search uses a SQL LIKE clause with wildcard characters to
        /// match partial strings.</remarks>
        /// <param name="keyword">The search term used to filter employees. The search is case-insensitive and matches any part of the  name,
        /// surname, or username. Cannot be null or empty.</param>
        /// <returns>A list of <see cref="Empleado"/> objects that match the search criteria. Returns <see langword="null"/>  if
        /// no employees are found.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while connecting to or querying the database.</exception>
        public List<Empleado> BuscarEmpleados(string keyword)
        {
            try
            {
                List<Empleado> empleados = new List<Empleado>();
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SELECT * FROM EMPLEADOS WHERE NOMBRE LIKE @keyword OR APELLIDOS LIKE @keyword OR USERNAME LIKE @keyword";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empleados.Add(
                                    new Empleado(
                                        Convert.ToInt32(reader["ID_EMPLEADO"]),
                                        reader["NOMBRE"].ToString(),
                                        reader["APELLIDOS"].ToString(),
                                        reader["USERNAME"].ToString(),
                                        Convert.ToBoolean(reader["SUPER_USER"]),
                                        Convert.ToBoolean(reader["ACTIVO"])
                                    )
                                );
                            }
                        }
                    }
                }
                if (empleados.Count == 0)
                    return null;
                return empleados;
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }
        
        /// <summary>
        /// Creates a new employee record in the database.
        /// </summary>
        /// <remarks>This method uses a stored procedure named "SP_CREAR_EMPLEADO" to insert the employee
        /// record. The password is hashed using SHA-256 before being stored in the database.</remarks>
        /// <param name="nuevoEmpleado">An instance of the <see cref="Empleado"/> class containing the details of the employee to be created. The
        /// properties <see cref="Empleado.Nombre"/>, <see cref="Empleado.Apellidos"/>,  <see
        /// cref="Empleado.Username"/>, <see cref="Empleado.Password"/>, and <see cref="Empleado.SuperUser"/>  must be
        /// set before calling this method.</param>
        /// <returns><see langword="true"/> if the employee record was successfully created; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="Exception">Thrown when an error occurs while connecting to the database or executing the operation. The exception
        /// message provides additional details about the error.</exception>
        public bool CrearEmpleado(Empleado nuevoEmpleado)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SP_CREAR_EMPLEADO";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@P_NOMBRE", nuevoEmpleado.Nombre);
                        command.Parameters.AddWithValue("@P_APELLIDOS", nuevoEmpleado.Apellidos);
                        command.Parameters.AddWithValue("@P_USERNAME", nuevoEmpleado.Username);
                        command.Parameters.AddWithValue("@P_PASSWORD", Sha256Hash(nuevoEmpleado.Password));
                        command.Parameters.AddWithValue("@P_SUPER_USER", nuevoEmpleado.SuperUser);
                        int filasAfectadas = command.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Updates the information of an existing employee in the database.
        /// </summary>
        /// <remarks>This method uses a stored procedure named "SP_ACTUALIZAR_EMPLEADO" to update the
        /// employee's details. The password is hashed using SHA-256 before being sent to the database, if
        /// provided.</remarks>
        /// <param name="actualizarEmpleado">An <see cref="Empleado"/> object containing the updated information for the employee. The object's <see
        /// cref="Empleado.Id"/> property must correspond to the employee to be updated.</param>
        /// <returns><see langword="true"/> if the employee's information was successfully updated; otherwise, <see
        /// langword="false"/>.</returns>
        /// <exception cref="Exception">Thrown when there is an error connecting to the database or executing the update operation. The exception
        /// message provides additional details about the error.</exception>
        public bool ActualizarEmpleado(Empleado actualizarEmpleado)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SP_ACTUALIZAR_EMPLEADO";
                    string password = actualizarEmpleado.Password;
                    if (password.Length > 0) password = Sha256Hash(actualizarEmpleado.Password);
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("P_ID_EMPLEADO", actualizarEmpleado.Id);
                        command.Parameters.AddWithValue("P_NOMBRE", actualizarEmpleado.Nombre);
                        command.Parameters.AddWithValue("P_APELLIDOS", actualizarEmpleado.Apellidos);
                        command.Parameters.AddWithValue("P_USERNAME", actualizarEmpleado.Username);
                        command.Parameters.AddWithValue("P_PASSWORD", password);
                        command.Parameters.AddWithValue("P_SUPER_USER", actualizarEmpleado.SuperUser);
                        command.Parameters.AddWithValue("P_ACTIVO", actualizarEmpleado.Activo);
                        int filasAfectadas = command.ExecuteNonQuery();

                        return filasAfectadas > 0;
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Marks an employee as inactive in the database by setting their "Activo" status to false.
        /// </summary>
        /// <remarks>This method updates the "Activo" field of the specified employee in the "EMPLEADOS"
        /// table to indicate that the employee is no longer active. The operation is performed using a SQL UPDATE
        /// statement. Ensure that the database connection string is correctly configured.</remarks>
        /// <param name="idEmpleado">The unique identifier of the employee to be marked as inactive. Must correspond to a valid employee ID in
        /// the database.</param>
        /// <exception cref="Exception">Thrown if an error occurs while connecting to the database or executing the query.</exception>
        public void EliminarEmpleado(int idEmpleado)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "UPDATE EMPLEADOS SET ACTIVO = FALSE WHERE ID_EMPLEADO = @idEmpleado";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }
        public static void AgregarDetalle(int idVenta, string isbn, int cantidad)
        {
            using (MySqlConnection cn = GetConnection())
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_DETALLE_VENTA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_ID_VENTA", idVenta);
                cmd.Parameters.AddWithValue("@P_ISBN", isbn);
                cmd.Parameters.AddWithValue("@P_CANTIDAD", cantidad);

                cmd.ExecuteNonQuery();
            }
        }

        public static int CrearVenta(int idEmpleado)
        {
            using (MySqlConnection cn = GetConnection())
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand("SP_CREAR_VENTA", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@P_ID_EMPLEADO", idEmpleado);

                MySqlParameter salida = new MySqlParameter("@P_ID_VENTA", MySqlDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(salida);

                cmd.ExecuteNonQuery();

                return Convert.ToInt32(salida.Value);
            }
        }

        /// <summary>
        /// Determines whether the specified username exists in the database.
        /// </summary>
        /// <remarks>This method queries the database to check if the specified username is already in
        /// use. It is recommended to handle exceptions appropriately when calling this method, as database connectivity
        /// issues or query errors may occur.</remarks>
        /// <param name="username">The username to check for existence. Cannot be null or empty.</param>
        /// <returns><see langword="true"/> if the username exists in the database; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="Exception">Thrown if an error occurs while connecting to the database or executing the query. The inner exception
        /// provides additional details about the specific error.</exception>
        public bool VerificarUsername(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(datos.Datos()))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM EMPLEADOS WHERE USERNAME = @username";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                throw new Exception("Error de MySQL al conectar con la base de datos: " + mySqlEx.Message, mySqlEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar con la base de datos: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Computes the SHA-256 hash of the specified password string.
        /// </summary>
        /// <param name="password">The input string to hash. Cannot be <see langword="null"/> or empty.</param>
        /// <returns>A hexadecimal string representation of the SHA-256 hash of the input string.</returns>
        /// <exception cref="Exception">Thrown if an error occurs during the hash computation.</exception>
        private static string Sha256Hash(string password)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error al generar el hash SHA-256: " + ex.Message);
            }
        }
        public DataTable GenerarReporteVentas(DateTime inicio, DateTime fin)
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection cn = GetConnection())
            {
                string sql = @"
            SELECT 
                V.ID_VENTA,
                V.FECHA,
                V.TOTAL,
                E.NOMBRE AS EMPLEADO
            FROM VENTAS V
            INNER JOIN EMPLEADOS E ON V.ID_EMPLEADO = E.ID_EMPLEADO
            WHERE DATE(V.FECHA) BETWEEN @ini AND @fin
            ORDER BY V.FECHA ASC";

                using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                {
                    cmd.Parameters.AddWithValue("@ini", inicio);
                    cmd.Parameters.AddWithValue("@fin", fin);

                    cn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(tabla);
                }
            }

            return tabla;
        }

    }

}
