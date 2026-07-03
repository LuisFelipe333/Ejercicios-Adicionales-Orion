using Ejercicio4.Clases;
using Ejercicio4.Services;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryService service = new InventoryService();
            Cetes testCete = new Cetes { LocalId = "A12", DealName = "CeteName", SettlementDate = DateTime.Now, Precio = 123.45M, Titulos = 32 };
            service.RecordTableInventory(testCete);
            ReverseRepo testRepo = new ReverseRepo("B12", 123, DateTime.Now, "RepoName");
            service.RecordTableInventory(testRepo);
            Console.ReadKey();
        }
    }
}
