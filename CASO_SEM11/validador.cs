using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASO_SEM11
{
    internal class validador
    {
        public static int LeerEntero(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 1 || valor > 5)
                    {
                        Console.WriteLine("ERROR: El valor debe ser entero [1, 5]:");
                        continue;
                    }
                    return valor;
                }

                Console.WriteLine("ERROR: El valor debe ser entero:");
            }
        }
        public static double LeerDecimales(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 0 || valor > 20)
                    {
                        Console.WriteLine("ERROR: El valor debe ser decimal [0, 20]:");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("ERROR: El valor debe ser decimal:");
            }
        }
        public static string LeerCadena(string mensaje)
        {
            string texto;
            while (true)
            {
                Console.Write(mensaje);
                texto = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(texto))
                    return texto;
                Console.WriteLine("ERROR: El valor no puede estar vacío:");
            }
        }
    }
}

