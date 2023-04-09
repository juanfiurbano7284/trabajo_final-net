using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispensador.Models;
using Dispensador.Controllers;

namespace Dispensador {
    class Programa {
        static void Main(string[] args) {
            MDispensador dispensador = new MDispensador();

            while(true) {
                Console.WriteLine("Dispensador");

                Console.WriteLine(dispensador.listarProducto());

                Console.WriteLine("Usuario: proveedor o cliente");

                string usuario = Console.ReadLine();

                if(usuario == "proveedor") {
                    Console.WriteLine("1. Comprar");
                    Console.WriteLine("2. Agregar");
                    Console.WriteLine("3. Eliminar");
                }

                else {
                    Console.WriteLine("1. Comprar");
                }

                string opcion = Console.ReadLine();

                switch(opcion) {
                    case "1":
                        Console.Write("Nombre ");
                        string producto = Console.ReadLine();

                        Console.Write("Dinero (500-200-100-50)");
                        dispensador.Ingreso = Console.ReadLine();

                        Consumable p_comprado = dispensador.venta(producto);

                        if (p_comprado == null) {
                            Console.WriteLine("No existe");
                        }

                        else {
                            Console.WriteLine("Su producto es {0} y la devuelta es {1}", p_comprado.Producto, p_comprado.Cambio);
                        }

                        break;

                    case "2":
                        Consumable consumable = new Consumable();

                        Console.Write("Producto ");
                        consumable.Producto = Console.ReadLine();

                        Console.Write("Cantidad ");
                        consumable.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Precio ");
                        consumable.Precio = Convert.ToInt32(Console.ReadLine());

                        dispensador.agregrarProducto(consumable);

                        break;

                    case "3":
                        Console.Write("Producto ");
                        string nombre = Console.ReadLine();

                        dispensador.eliminarProducto(nombre);

                        break;

                }
                Console.WriteLine("Continuar si/no");

                if(Console.ReadLine() == "no") {
                    break;
                }
            }
        }
    }
}