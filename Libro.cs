using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta
{
    internal class Libro
    {
        private string ISBN;
        private string nombre;
        private string descripcion;
        private double precio;
        private int stock;

        public Libro(string ISBN, string nombre, string descripcion, double precio, int stock)
        {
            this.ISBN = ISBN;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
        }
        public string getISBN()
        {
            return ISBN;
        }
        public string getNombre()
        {
            return nombre;
        }
        public string getDescripcion()
        {
            return descripcion;
        }
        public double getPrecio()
        {
            return precio;
        }
        public int getStock()
        {
            return stock;
        }
    }
}
