using System;
using System.Collections.Generic;

namespace Ruleta
{
    class Program
    {
        static void Main(string[] args)
        {
            Ruleta ruleta = new Ruleta();
            int saldo = 300;
            int giros = 0;

            Console.WriteLine("¡Bienvenido a la ruleta!");
            Console.WriteLine("Su saldo inicial es de $300");

            while (saldo > 0)
            {
                Console.WriteLine("¿Qué tipo de apuesta desea realizar?");
                Console.WriteLine("1. Apuesta a un número específico");
                Console.WriteLine("2. Apuesta a un color");
                Console.WriteLine("3. Salir del juego");
                Console.Write("Opción: ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.Write("Ingrese el número al que desea apostar (0-36): ");
                    int numero = int.Parse(Console.ReadLine());

                    if (numero < 0 || numero > 36)
                    {
                        Console.WriteLine("El número ingresado es inválido");
                        continue;
                    }

                    Console.Write("Ingrese la cantidad que desea apostar (múltiplos de 10): ");
                    int apuesta = int.Parse(Console.ReadLine());

                    if (apuesta % 10 != 0 || apuesta > saldo)
                    {
                        Console.WriteLine("La cantidad ingresada es inválida");
                        continue;
                    }

                    saldo -= apuesta;

                    int resultado = ruleta.Girar();

                    if (resultado == numero)
                    {
                        int ganancia = apuesta * 10;
                        Console.WriteLine("¡Felicidades! Ha ganado ${0}", ganancia);
                        saldo += ganancia;
                    }
                    else
                    {
                        Console.WriteLine("Lo siento, ha perdido");
                    }

                    giros++;
                }
                else if (opcion == 2)
                {
                    Console.Write("Ingrese el color al que desea apostar (rojo o negro): ");
                    string color = Console.ReadLine().ToLower();

                    if (color != "rojo" && color != "negro")
                    {
                        Console.WriteLine("El color ingresado es inválido");
                        continue;
                    }

                    Console.Write("Ingrese la cantidad que desea apostar (múltiplos de 10): ");
                    int apuesta = int.Parse(Console.ReadLine());

                    if (apuesta % 10 != 0 || apuesta > saldo)
                    {
                        Console.WriteLine("La cantidad ingresada es inválida");
                        continue;
                    }

                    saldo -= apuesta;

                    bool resultado = ruleta.EsColor(color);

                    if (resultado)
                    {
                        int ganancia = apuesta;
                        Console.WriteLine("¡Felicidades! Ha ganado ${0}", ganancia);
                        saldo += ganancia;
                    }
                    else
                    {
                        Console.WriteLine("Lo siento, ha perdido");
                    }

                    giros++;
                }
                else if (opcion == 3)
                {
                    Console.WriteLine("¡Gracias por jugar!");
                    break;
                }
                else
                {
                    Console.WriteLine("Opción inválida");
                }
            }

            Console.WriteLine("Su saldo final es de ${0}", saldo);
            Console.WriteLine("Cantidad de giros realizados: {0}", giros);
            Console.WriteLine("Número que más veces se ha tirado: {0}", ruleta.NumeroMasFrecuente());
            Console.WriteLine("Número que menos veces se ha tirado: {0}", ruleta.NumeroMenosFrecuente());
        }
    }
}
