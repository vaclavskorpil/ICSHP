using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cviceni2
{
    public class CliController
    {
        private static int DEFAULT_VALUE = 20;
        private static int[] array = new int[DEFAULT_VALUE];
        private static int arrayLength = 0;
        private static List<Command> commands;

        static CliController()
        {
            commands = new List<Command>
            {
                new ReadNumberFromStandardInput(readNumberFromInputToArray),
                new PrintAllNumbers(printAllNumbers),
                new Sort(sort),
                new FindSmallestNumber(findSmallestNumber),
                new FindFirstOccurence(findFirstOccurence),
                new FindLastOccurence(findLastOccurence),
                new Help(printAllCommands),
                new Exit(() => { })
            };
        }


        public static void Start()
        {

            printAllCommands();

            while (true)
            {
                Console.WriteLine();
                var input = Fei.BaseLib.Reading.ReadString("Zadejte Příkaz");

                if (input.Trim() == "exit") return;

                try
                {
                    var command = commands.Find(cliCommand => cliCommand.CliCommand.Equals(input.Trim()));
                    command?.Action();
                    if (command == null)
                    {
                        Console.WriteLine("Tento příkaz neexistuje.");   
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Tento příkaz neexistuje.");
                }
            }
        }

        private static Action printAllCommands = () =>
        {
            var sb = new StringBuilder("Dostupné příkazy: \n");
            commands.ForEach(command => { sb.AppendLine(command.ToString()); });
            Console.WriteLine(sb.ToString());
        };

        private static void AddNumberToArray(int number)
        {
            
            if (arrayLength % DEFAULT_VALUE == 0 && arrayLength != 0)
            {
                var tempArray = new int[array.Length + DEFAULT_VALUE];
                array.CopyTo(tempArray, 0);
                array = tempArray;
            }

            array[arrayLength++] = number;
        }


        private static Action readNumberFromInputToArray = () =>
        {
            try
            {
                var num = Fei.BaseLib.Reading.ReadInt("Zadejte číslo");
                AddNumberToArray(num);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Chybně zadané číslo.");
            }
        };

        private static Action printAllNumbers = () =>
        {
            var sb = new StringBuilder();
            for (int i = 0; i < array.Count(); i++)
            {
                sb.AppendLine(array[i].ToString());
            }

            Console.WriteLine(sb.ToString());
        };

        private static Action sort = () => { Array.Sort(array); };


        private static Action findSmallestNumber = () => { Console.WriteLine(array.Min().ToString()); };

        private static Action findFirstOccurence = () =>
        {
            try
            {
                var input = Fei.BaseLib.Reading.ReadInt("Zadejte číslo které chcete najít.");

                Console.WriteLine(array.First(i => i == input));
            }
            catch (FormatException format)
            {
                Console.WriteLine("Chybně zadaný formát celého čísla.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Takové to číslo v poli není.");
            }
        };

        private static Action findLastOccurence = () =>
        {
            try
            {
                var input = Fei.BaseLib.Reading.ReadInt("Zadejte číslo které chcete najít.");

                Console.WriteLine(array.Last(i => i == input));
            }
            catch (FormatException format)
            {
                Console.WriteLine("Chybně zadaný formát celého čísla.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Takové to číslo v poli není.");
            }
        };
    }
}