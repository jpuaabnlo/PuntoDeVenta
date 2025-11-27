using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Empleado
    {
        private int id;
        private string nombre;
        private string apellido;
        private string username;
        private string password;
        private bool superUser;
        private bool activo;
        public Empleado(int id, string nombre, string apellido, string username, string password, bool superUser, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.username = username;
            this.password = password;
            this.superUser = superUser;
            this.activo = activo;
        }

        public Empleado(int id, string nombre, string apellido, string username, bool superUser, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.username = username;
            this.superUser = superUser;
            this.activo = activo;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public string GetApellido()
        {
            return apellido;
        }

        public string GetUsername()
        {
            return username;
        }
        public string GetPassword()
        {
            return password;
        }
        public bool IsSuperUser()
        {
            return superUser;
        }
        public bool isActivo()
        {
            return activo;
        }
    }
}
