using System;

namespace Cviceni2
{
    public class Command
    {
        public string CliCommand { get; }
        private string infoMessage;
        private string helpMessage;
        public ExecuteCommandWithMessage Action { get; }

        public delegate void ExecuteCommandWithMessage(string message);

        public Command(string cliCommand, string infoMessage, string helpMessage, ExecuteCommandWithMessage action)
        {
            this.CliCommand = cliCommand;
            this.infoMessage = infoMessage;
            this.helpMessage = helpMessage;
            this.Action = action;
        }

        public override string ToString()
        {
            return CliCommand + " - " + infoMessage + ".";
        }

        public void Execute()
        {
            Action(helpMessage);
        }
    }

    public class ReadStudentFromStandardInput : Command
    {
        public ReadStudentFromStandardInput(ExecuteCommandWithMessage action) : base("addstudent",
            "Přidáné studenta do pole", "Zadejte jméno cislo nazev fakulty oddelene mezerou", action)
        {
        }
    }


    public class PrintAllStudents : Command
    {
        public PrintAllStudents(ExecuteCommandWithMessage action) : base("print", "Výpis studentů na obrazovku", "",
            action)
        {
        }
    }

    public class SortByNum : Command
    {
        public SortByNum(ExecuteCommandWithMessage action) : base("sortbynum", "Utřídění pole dle čísla", "", action)
        {
        }
    }

    public class SortByName : Command
    {
        public SortByName(ExecuteCommandWithMessage action) : base("sortbyname", "Utřídění pole dle jména", "", action)
        {
        }
    }

    public class SortByFaculty : Command
    {
        public SortByFaculty(ExecuteCommandWithMessage action) : base("sortbyname", "Utřídění pole dle fakulty", "",
            action)
        {
        }
    }

    public class Exit : Command
    {
        public Exit(ExecuteCommandWithMessage action) : base("exit", "Ukončí program", "", action)
        {
        }
    }

    public class Help : Command
    {
        public Help(ExecuteCommandWithMessage action) : base("help", "Zobrazí nápovědu", "Naviděnou", action)
        {
        }
    }
}