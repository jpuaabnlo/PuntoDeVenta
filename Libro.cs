using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Libro
    {
        public string ISBN { get; private set; }
        public string Nombre { get; private set; }
        public string Autor { get; private set; }
        public string Descripcion { get; private set; }
        public decimal Precio { get; private set; }
        public int Stock { get; private set; }
        public bool Activo { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de un Libro.
        /// </summary>
        /// <param name="isbn">El identificador único (ISBN-13).</param>
        /// <param name="nombre">Título completo de la obra.</param>
        /// <param name="precio">Precio unitario en moneda local.</param>
        public Libro(string isbn, string nombre, string autor, string descripcion, decimal precio, int stock, bool activo)
        {
            ISBN = isbn;
            Nombre = nombre;
            Autor = autor;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Activo = activo;
        }
    }
}
