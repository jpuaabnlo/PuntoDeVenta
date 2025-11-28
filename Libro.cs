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
        public string Descripcion { get; private set; }
        public double Precio { get; private set; }
        public int Stock { get; private set; }

        /// <summary>
        /// Inicializa una nueva instancia de un Libro.
        /// </summary>
        /// <param name="isbn">El identificador único (ISBN-13).</param>
        /// <param name="nombre">Título completo de la obra.</param>
        /// <param name="precio">Precio unitario en moneda local.</param>
        public Libro(string isbn, string nombre, string descripcion, double precio, int stock)
        {
            // En C# las variables locales/parámetros usan camelCase (minúscula al inicio)
            // Y las propiedades Públicas usan PascalCase (Mayúscula al inicio)
            ISBN = isbn;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }
    }
}
