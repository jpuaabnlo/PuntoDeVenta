using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Empleado
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool SuperUser { get; private set; }
        public bool Activo { get; private set; }
        public Empleado(int id, string nombre, string apellido, string username, string password, bool superUser, bool activo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Username = username;
            this.Password = password;
            this.SuperUser = superUser;
            this.Activo = activo;
        }

        public Empleado(int id, string nombre, string apellido, string username, bool superUser, bool activo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Username = username;
            this.SuperUser = superUser;
            this.Activo = activo;
        }
    }
}
