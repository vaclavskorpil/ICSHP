using System;

namespace Delegate
{
    public class Student
    {
        private string jmeno;
        private int cislo;
        private Fakulta fakulta;

        public string Jmeno
        {
            get => jmeno;
            set => jmeno = value;
        }

        public int Cislo
        {
            get => cislo;
            set => cislo = value;
        }

        public Fakulta Fakulta
        {
            get => fakulta;
            set => fakulta = value;
        }

        public Student(string jmeno, int cislo, Fakulta fakulta)
        {
            this.jmeno = jmeno;
            this.cislo = cislo;
            this.fakulta = fakulta;
        }

        /// <summary>
        /// Creates student from string. String must have format <code>name number facultyName</code>
        /// <exception> throws Format exception when given string has wrong format</exception> 
        /// </summary>
        /// <param name="studentStirng"></param>
        /// <returns>Student new instance</returns>
        public static Student CreateOrCrash(string studentStirng)
        {
            try
            {
                var split = studentStirng.Split(" ");
                var name = split[0];
                var num = Int32.Parse(split[1]);
                var faculty = Enum.Parse<Fakulta>(split[2],true);

                return new Student(name, num, faculty);
            }
            catch (Exception e)
            {
                throw new FormatException("Wrong string input format");
            }
            
        }

        public override string ToString()
        {
            return $"Jmeno: {jmeno}, Číslo: {cislo}, Fakulta: {Fakulta.ToString()}";
        }
    }
}