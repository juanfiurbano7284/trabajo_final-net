using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispensador.Models {
    public class Consumable {
        public string Producto {get; set;}
        public int Cantidad {get; set;}
        public int Precio {get; set;}
        public int Cambio {get; set;}

        public void sumarCantidad(int cantidad) {
            this.Cantidad += cantidad;
        }

        public bool validarCantidad() {
            if(this.Cantidad > 0){
                return true;
            }

            return false;
        }

        public bool validarPrecio(int precio) {
            if(this.Precio <= precio) {
                this.Cambio = precio - this.Precio;

                return true;
            }

            return false;
        }

        public void restarProducto() {
            this.Cantidad--;
        }
    }
}