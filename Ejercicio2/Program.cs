namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Deposito> depositos = new() //Se simula la tabla de depósitos con una lista de objetos Deposito
            {
                new Deposito { Titular = "Ana", Monto = 50 },
                new Deposito { Titular = "Paco", Monto = 10 },
                new Deposito { Titular = "Ana", Monto = 20 },
                new Deposito { Titular = "Jorge", Monto = 55 },
                new Deposito { Titular = "Laura", Monto = 75 },
                new Deposito { Titular = "Laura", Monto = 3 },
                new Deposito { Titular = "Laura", Monto = 50 }

            };

            var depositosPorTitular = depositos.GroupBy(d => d.Titular) //Se agrupan los depósitos y se calcula el mínimo, máximo, cantidad y promedio por medio de LINQ
                .Select(g => new
                {
                    Titular = g.Key,
                    Minimo = g.Min(d => d.Monto),
                    Maximo = g.Max(d => d.Monto),
                    Cantidad = g.Count(),
                    Promedio = g.Average(d => d.Monto),
                });

            var depositosFiltrados = depositosPorTitular.Where(d => d.Cantidad > 1 && d.Promedio > 50); //Se filtran los titulares que tienen más de un depósito y cuyo promedio es mayor a 50

            if (depositosFiltrados.Any()) // Si hay titulares que cumplen con los criterios, mostrar solo esos titulares
            {
                Console.WriteLine("Resumen de depósitos filtrados (más de un depósito y promedio mayor a 50):");
                Console.WriteLine("Titular\tMínimo\tMáximo\tNumero de Depositos\tPromedio");
                foreach (var deposito in depositosFiltrados)
                {
                    Console.WriteLine($"{deposito.Titular}\t{deposito.Minimo}\t{deposito.Maximo}\t{deposito.Cantidad}\t\t\t{deposito.Promedio}");
                }
                return;
            }
            else // Si no hay titulares que cumplan con los criterios, mostrar todos los titulares sin filtrar para demostrar que no hay ninguno que cumpla con los criterios
            {
                Console.WriteLine("No hay titulares con más de un depósito y promedio mayor a 50.");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Resumen de depósitos sin filtrar:");
                Console.WriteLine("Titular\tMínimo\tMáximo\tNumero de Depositos\tPromedio");
                foreach (var deposito in depositosPorTitular)
                {
                    Console.WriteLine($"{deposito.Titular}\t{deposito.Minimo}\t{deposito.Maximo}\t{deposito.Cantidad}\t\t\t{deposito.Promedio}");
                }
            }

            Console.ReadKey(); // Espera a que el usuario presione una tecla antes de cerrar la consola
        }
    }
}
