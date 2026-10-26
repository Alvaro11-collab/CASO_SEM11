using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASO_SEM11
{
    internal class Program
    {
        static int max_estudiantes = 40;
        static int max_cursos = 4;
        static string[] nombre_cursos= {"Matemática",
            "Programacion",
            "fisica",
            "Base de datos"
        };
        static string[] estudiante = new string[max_estudiantes];
        static double [,] matriznotas = new double[max_estudiantes, max_cursos];
        static int total_estudiantes = 0;
        static string rutaArchivo = "notas_curso.txt";
        public static void RegistrarEstudiante()
        {
            Console.WriteLine("REGISTRO DE ESTUDIANTE");
            if (total_estudiantes >= max_estudiantes)
            {
                Console.WriteLine("ERROR: Se ha alcanzado el número máximo de estudiantes.");
                return;
            }
            string nombre = validador.LeerCadena("Ingrese el nombre del estudiante: ");
            estudiante[total_estudiantes] = nombre;
            Console.WriteLine("Ingresar las notas del 0 al 20:");
            for(int i = 0; i < max_cursos; i++)
            {
                matriznotas[total_estudiantes, i] = validador.LeerDecimales($"Ingrese la nota de {nombre_cursos[i]}: ");
            }
            total_estudiantes++;
            Console.WriteLine("Estudiante registrado exitosamente.");
        }
        public static void guardararchivo()
        {
            Console.WriteLine("Guardar registro en archivo");
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados para guardar.");
                return;
            }
            using (StreamWriter escritor= new StreamWriter(rutaArchivo))
            {
                for(int i = 0; i < total_estudiantes; i++)
                {
                    string linea = estudiante[i];
                    for (int j = 0; j < max_cursos; j++)
                    {
                        linea += $",{matriznotas[i, j]}";
                    }
                    escritor.WriteLine(linea);
                }
            }
            Console.WriteLine($"Registro guardado {total_estudiantes} exitosamente en {rutaArchivo}.");
        }
        public static void CargarRegistro()
        {
            Console.WriteLine("CARGAR REGISTROS DESDE ARCHIVO");
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine($"ERROR: El archivo {rutaArchivo} no existe.");
                return;
            }
            total_estudiantes = 0;
            using(StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while((linea = lector.ReadLine()) != null && total_estudiantes < max_estudiantes)
                {
                    string[] partes = linea.Split(',');
                    // Cambia el != por ==
                    if (partes.Length == max_cursos + 1)
                    {
                        estudiante[total_estudiantes] = partes[0];
                        for (int i = 0; i < max_cursos; i++)
                        {
                            matriznotas[total_estudiantes, i] = Convert.ToDouble(partes[i + 1]);
                        }
                        total_estudiantes++;
                    }

                }
            }
            Console.WriteLine($"Se han cargado los regsitros de \n{total_estudiantes} estudiantes desde el archivo.");
        }
        public static void MostrarRegistro()
        {
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("\t\tREGISTRO GENERAL DE NOTAS POR CURSO");
            Console.WriteLine(new string('=', 100));
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            // Mostrar encabezado de la tabla
            Console.WriteLine($"{"Estudiante",-25}|");
            for (int i = 0; i < max_cursos; i++)
            {
                Console.Write($"{nombre_cursos[i],-12}|");
            }
            Console.WriteLine("PROMEDIO");
            Console.WriteLine(new string('-', 100));
            for (int i = 0; i < total_estudiantes; i++)
            {
                Console.Write($"{estudiante[i],-25}|");
                double suma= 0;
                for(int j= 0; j < max_cursos; j++)
                {
                    Console.Write($"{matriznotas[i, j],-12:F2}|");
                    suma += matriznotas[i, j];
                }
                double promedio = suma / max_cursos;
                string estado = promedio >= 12 ? "Aprobado" : "Desaprobado";
                Console.WriteLine($"{promedio,-10:F2} ({estado})");
            }
        }
        

        static void Main(string[] args)
        {
            int opcion = 0;
            while(opcion != 5)
            {
                
                Console.Clear();
                Console.WriteLine("\nMENU DE OPCIONES");
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Guardar registro en archivo");
                Console.WriteLine("3. Cargar registro desde archivo");
                Console.WriteLine("4. Mostrar registro");
                Console.WriteLine("5. Salir");
                opcion = validador.LeerEntero("Ingrese una opción entre[1-5]: ");
                switch(opcion)
                {
                    case 1:
                        RegistrarEstudiante();
                        break;
                    case 2:
                        guardararchivo();
                        break;
                    case 3:
                        CargarRegistro();
                        break;
                    case 4:
                        MostrarRegistro();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        Console.WriteLine("Exitos");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
