using System;

namespace Delegate
{
    public class Studenti
    {
        public Studenti(int baseLenght)
        {
            this.baseLenght = baseLenght;
            students = new Student[baseLenght];
        }

        private int baseLenght;

        private Student[] students;
        private int studentCount = 0;

        public Student[] Students
        {
            get => students;
            set => this.students = value;
        }


        public int StudentCount
        {
            get => studentCount;
            set => studentCount = value;
        }

        public Student GetStudent(int index)
        {
            return Students[index];
        }

        public void AddStudent(Student student)
        {
            if (studentCount >= students.Length)
            {
                var tempArr = Students;
                Students = new Student[tempArr.Length + baseLenght];
                Array.Copy(tempArr, Students, Students.Length);
            }

            students[studentCount++] = student;
        }

        public void SortByNumber()
        {
            Comparison<Student> comparison = (student, student1) => student.Cislo.CompareTo(student1.Cislo);

            Array.Sort(students, comparison);
        }
        public void SortByFaculty()
        {
            Comparison<Student> comparison = (student, student1) => student.Fakulta.CompareTo(student1.Fakulta);

            Array.Sort(students, comparison);
        }
        public void SortByString()
        {
            Comparison<Student> comparison = (student, student1) => String.Compare(student.Jmeno, student1.Jmeno, StringComparison.Ordinal);

            Array.Sort(students, comparison);
        }
    }
}