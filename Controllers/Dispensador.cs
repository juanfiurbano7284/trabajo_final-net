using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispensador.Models;

namespace Dispensador.Controllers {
    public class MDispensador {
        public List<Consumable> Consumables {get; set;}
        public string Ingreso {get; set;}

        public MDispensador() {
            this.Consumables = new List<Consumable>();

            Consumable chocoramo = new Consumable();
            chocoramo.Producto = "Choco Ramo";
            chocoramo.Cantidad = 20;
            chocoramo.Precio = 2000;

            Consumable doritos = new Consumable();
            doritos.Producto = "Doritos";
            doritos.Cantidad = 20;
            doritos.Precio = 1500;

            this.Consumables.Add(chocoramo);
            this.Consumables.Add(doritos);
        }

        public int validarProducto(string nombre) {
            int encontrado = -1;
            
            for(int i = 0; i < this.Consumables.Count; i++) {
                if(this.Consumables[i].Producto == nombre) {
                    encontrado = i;
                }
            }

            return encontrado;
        }

        public bool agregrarProducto(Consumable consumable) {
            int encontrado = this.validarProducto(consumable.Producto);

            if(encontrado >= 0) {
                this.Consumables[encontrado].sumarCantidad(consumable.Cantidad);
            }

            else {
                this.Consumables.Add(consumable);
            }

            return true;
        }

        public bool eliminarProducto(string nombre) {
            int encontrado = this.validarProducto(nombre);

            if(encontrado >= 0) {
                this.Consumables.RemoveAt(encontrado);
                return true;
            }

            return false;
        }

        public int validarDinero(string[] Dinero) {
            int total = 0;

            foreach(string item in Dinero) {
                total += int.Parse(item);
            }

            return total;
        }

        public Consumable venta(string nombre) {
            int encontrado = this.validarProducto(nombre);

            if(encontrado >= 0) {
                if(this.Consumables[encontrado].validarCantidad()) {
                    string[] dinero = this.Ingreso.Split('-');

                    int total = this.validarDinero(dinero);

                    if(this.Consumables[encontrado].validarPrecio(total)) {
                        this.Consumables[encontrado].restarProducto();

                        return this.Consumables[encontrado];
                    }
                }
            }

            return null;
        }

        public string listarProducto() {
            string lista = "";

            foreach(Consumable item in this.Consumables) {
                lista += item.Producto + " " + item.Cantidad + " " + item.Precio + "\n";
            }

            return lista;
        }
    }
}