namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ImprimirFibonacci(11);
        }

        public static void ImprimirFibonacci(int position)
        { 

            int prevNumber = 0;
            int nextNumber = 1;
            string fibonacciSequence = "";  //Usamos string en lugar de StringBuilder porque se trata de una secuencia pequeña

            if (position <= 0 )
            {
                Console.WriteLine("Debe ser un numero mayor a 0"); //Validacion nada mas por si algun dia deseamos cambiar el valor de position
                return;
            }
            else
            {
                fibonacciSequence += nextNumber; 
                //Utilizamos un bucle for para mantener una complejidad menor a la version recursiva
                for (int i = 1; i < position; i++) //Empezamos desde 1 porque ya tenemos el primer número de la secuencia
                {
                    int currentNumber = prevNumber + nextNumber;
                    prevNumber = nextNumber;
                    nextNumber = currentNumber;
                    fibonacciSequence += ", " + nextNumber;
                }
                Console.WriteLine($"Fib({position}) = {nextNumber}");
                Console.WriteLine(fibonacciSequence);

            }

            Console.ReadKey(); //Agregamos esta línea para que la consola no se cierre de inmediato
        }
    }
}
