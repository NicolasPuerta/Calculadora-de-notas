 using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Asignaturas> asignaturas = new List<Asignaturas>();

            while (true)
            {
                Console.Clear();
                Console.Write("##### Calculadora de Notas ######\n1.Agregar asignatura \n2.Elegir asignatura\n3.Salir\nDigita tu opcion: ");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1) agregarAsignatura(asignaturas);
                else if (opcion == 2) elgirAsignatura(asignaturas);
                else if (opcion == 3) break;
                else Console.WriteLine("opcion no valida");
            }
        }
        public static void agregarAsignatura(List<Asignaturas> asignaturas) {
            Console.Clear();
            Console.WriteLine("## Agregrar asignatura ##");
            Console.Write("Digita el nombre de la asignatura: ");
            string nombre = Console.ReadLine();
            Console.Write("Digita los creditos de la asignatura: ");
            int creditos = int.Parse(Console.ReadLine());
            asignaturas.Add(new Asignaturas(nombre, creditos));
            Console.WriteLine("Asignatura agregada");
            Console.ReadKey();
        }

        public static void agregarNota(Asignaturas asignatura) {
            Console.Clear();
            Console.WriteLine("## Agregrar nota ##");
            Console.Write("Digita el nombre de la nota: ");
            string nombre = Console.ReadLine();
            Console.Write("Digita el valor de la nota: ");
            double valor = double.Parse(Console.ReadLine());
            Console.Write("Digita el porcentaje de la nota: ");
            double porcentaje = double.Parse(Console.ReadLine());
            asignatura.notas.Add(new Notas(nombre, valor, porcentaje));
            Console.WriteLine("Nota agregada");
            Console.ReadKey();
        }

        public static void verNotaDeseada(Asignaturas asignatura) {
             Console.Clear();
            if (asignatura.ValidarPorcentaje())
            {

                Console.WriteLine("## Nota Deseada ##");
                Console.Write("Digita la nota deseada: ");
                double notaRequerida = double.Parse(Console.ReadLine());
                Console.WriteLine($"necesitas sacar en el porcentaje que te queda ({(1 - asignatura.ContarPorcentaje()) * 100}) un {asignatura.notaDeseada(notaRequerida)}");
            }
            else {
                Console.WriteLine($"Ya tienie una nota final de {asignatura.notaDeseada(0)}");
            }
            Console.ReadKey();
        }
        public static void verNotaAcomulada(Asignaturas asignatura) {
            Console.Clear();
            if (asignatura.ValidarPorcentaje())
                Console.WriteLine($"## Nota acomulada ##\nLlevas acomulado un {asignatura.notasAcomuladas()}");
            else Console.WriteLine($"## Nota acomulada ##\nTu asignatura tiene una nota final de {asignatura.notasAcomuladas()}");
            Console.ReadKey();
        }

        public static void elgirAsignatura(List<Asignaturas> asignaturas) {
            Console.Clear();
            Console.Write("Digita el nombre de la asignatura: ");
            string nombreAsignatura = Console.ReadLine();
            foreach (Asignaturas asignatura in asignaturas)
            {
                if (asignatura.nombre == nombreAsignatura)
                {
                    Console.Write("1.Ver nota acomulada \n2.Ver nota deseada \n3.Agregar notas\n4.Ver notas\nDigite una opcion: ");
                    int opcion2 = int.Parse(Console.ReadLine());
                    if (opcion2 == 3) agregarNota(asignatura);
                    else if (opcion2 == 2) verNotaDeseada(asignatura);
                    else if (opcion2 == 1) verNotaAcomulada(asignatura);
                    else if (opcion2 == 4)
                    {
                        Console.Clear()
                        Console.WriteLine(asignatura.ToString());
                        Console.ReadKey();
                    }
                    else Console.WriteLine("opcion no valida");
                }
            }
        }

    }
}
