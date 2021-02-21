using System;

namespace Cviceni1
{
    class Program
    {
        static void Main(string[] args)
        {
            //priklad1();
            //priklad2();
            //priklad3("9613173560");
            priklad4();
        }

        static void priklad1()
        {
            var jmeno = "Josef Novák";
            var adresa = "Jindřišská 16";
            var psc = "111 50";
            var mesto = "Praha 1";
            Console.Write($"{jmeno}\n{adresa}\n{psc},{mesto}");
        }

        static void priklad2()
        {
            /*for (int i = 65; i <= 122; i++)
            {
                if (i > 90 && i < 97  )
                {
                    continue;
                }
                Console.WriteLine((char)i);
            }   */

            char c = '@';
            while (c++ < 'z')
            {
                if (c > 'Z' && c < 'a')
                {
                    continue;
                }

                Console.WriteLine(c);
            }
        }

        static void priklad3(string rodnecislo)
        {
            var cislo = Int32.Parse(rodnecislo[3].ToString());
            Console.WriteLine(cislo > 3
                ? "Rodne cislo patri zene"
                : "Rodne cislo patri muzi");
        }

        static void priklad4()
        {
            var rand = new System.Random().Next(0, 100);

            var pocetPokusu = 0;
            while (pocetPokusu < 10)
            {
                Console.WriteLine("Zadejte cislo od 0 do 100");
                var input = Console.ReadLine();
                int cislo = 0;
                var cont = true;
                while (cont)
                {
                    try
                    {
                        cislo = Int32.Parse(input);
                        cont = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Toto neni cislo. Zkuz to znovu");
                    }
                }

                if (cislo == rand)
                {
                    Console.WriteLine($"Uhodl jsi to. Pocet pokusu {pocetPokusu}");
                    return;
                }

                var vetsi = cislo > rand ? "mensi" : "vetsi";
                Console.WriteLine($"Netrefil jsi se, zkus to znovu. Cislo je {vetsi}");

                Console.WriteLine($"");
                pocetPokusu++;
            }
        }
    }
}