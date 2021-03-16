using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Delegate;

namespace Cviceni2
{
    public class CliController
    {
        private static List<Command> commands;

        private static Studenti studenti;

        private const int BaseStudentiLenght = 20;

        static CliController()
        {
            studenti = new Studenti(BaseStudentiLenght);

            commands = new List<Command>
            {
                new ReadStudentFromStandardInput(CreateStudentFromStandardInput),
                new PrintAllStudents(PrintAllStudents),
                new SortByNum(_ => studenti.SortByNumber()),
                new SortByFaculty(_ => studenti.SortByFaculty()),
                new SortByName(_ => studenti.SortByString()),
                new Help(PrintAllCommands),
                new Exit((msg) => { Console.WriteLine(msg); })
            };
        }


        public static void Start()
        {
            PrintAllCommands("");

            while (true)
            {
                Console.WriteLine();
                var input = Fei.BaseLib.Reading.ReadString("Zadejte Příkaz");

                if (input == "exit") return;

                var command = commands.Find(cliCommand => cliCommand.CliCommand.Equals(input.Trim()));
                command?.Execute();
                if (command == null)
                {
                    Console.WriteLine("Tento příkaz neexistuje.");
                }
            }
        }

        private static Command.ExecuteCommandWithMessage CreateStudentFromStandardInput = (message) =>
        {
            var input = Fei.BaseLib.Reading.ReadString(message);
            try
            {
                var student = Student.CreateOrCrash(input);
                studenti.AddStudent(student);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Chybný formát studenta.");
            }
        };

        private static readonly Command.ExecuteCommandWithMessage PrintAllCommands = (msg) =>
        {
            var sb = new StringBuilder("Dostupné příkazy: \n");
            commands.ForEach(command => { sb.AppendLine(command.ToString()); });
            Console.WriteLine(sb.ToString());
        };


        private static readonly Command.ExecuteCommandWithMessage PrintAllStudents = (message) =>
        {
            var sb = new StringBuilder();
            for (int i = 0; i < studenti.StudentCount; i++)
            {
                sb.AppendLine(studenti.GetStudent(i).ToString());
            }

            Console.WriteLine(sb.ToString());
        };

        
    }
}