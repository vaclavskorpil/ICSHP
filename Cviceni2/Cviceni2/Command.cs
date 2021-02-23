using System;

namespace Cviceni2
{
    public class Command
    {
        public string CliCommand { get; }
        private string message;
        public Action Action { get; }


        public Command(string cliCommand, string message, Action action)
        {
            this.CliCommand = cliCommand;
            this.message = message;
            this.Action = action;
        }

        public override string ToString()
        {
            return CliCommand + " - " + message + ".";
        }
    }

    public class ReadNumberFromStandardInput : Command
    {
        public ReadNumberFromStandardInput(Action action) : base("addnum", "Zadaní prvků pole z klávesnice", action)
        {
        }
    }


    public class PrintAllNumbers : Command
    {
        public PrintAllNumbers(Action action) : base("print", "Výpis pole na obrazovku", action)
        {
        }
    }

    public class Sort : Command
    {
        public Sort(Action action) : base("sort", "Utřídění pole vzestupně", action)
        {
        }
    }

    public class FindSmallestNumber : Command
    {
        public FindSmallestNumber(Action action) : base("smallest", "Hledání minimálního prvku", action)
        {
        }
    }

    public class FindFirstOccurence : Command
    {
        public FindFirstOccurence(Action action) : base("findfirst", "Hledání prvního výskytu zadaného čísla", action)
        {
        }
    }

    public class FindLastOccurence : Command
    {
        public FindLastOccurence(Action action) : base("findlast", "Hledání posledního výskytu zadaného čísla", action)
        {
        }
    }
    public class Exit : Command
    {
        public Exit(Action action) : base("exit", "Hledání posledního výskytu zadaného čísla", action)
        {
        }
    }
    
    public class Help : Command
    {
        public Help(Action action) : base("help", "Zobrazí nápovědu", action)
        {
        }
    }
}