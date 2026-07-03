using Ejercicio4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Services
{
    public class InventoryService
    {
        
        public void RecordTableInventory(IProduct producto)
        {
            //Ejemplo para simular inserccion en la tabla
            Console.WriteLine("Se inserta en la tabla Inventory:");
            Console.WriteLine($"DealName: {producto.DealName}");
            Console.WriteLine($"LocalId: {producto.LocalId}");
            Console.WriteLine($"Titles: {producto.Titles}");
            Console.WriteLine($"AvailableSince: {producto.AvailableSince}");

        }
    }
}
