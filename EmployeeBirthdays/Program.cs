using System;
using System.Collections.Generic;

namespace EmployeeBirthdays
{
    class Employee
    {
        private string nameOfPerson;
        private DateTime birthday;

        public Employee(string nameOfPerson, DateTime birthday)
        {
            this.nameOfPerson = nameOfPerson;
            this.birthday = birthday;
        }
        public override string ToString()
        {
            String result = $"{nameOfPerson}: {birthday}";
            return result;
        }
        public string getName()
        {
            return nameOfPerson;
        }
        public DateTime getDateBirth()
        {
            return birthday;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int planingHorisont = 0;

            Employee[] listOfEmployee = {
                (new Employee("Ваня Иванов", new DateTime(2001, 10, 21))),
                (new Employee("Петя Петров", new DateTime(2008, 6, 12))),
                (new Employee("Коля Новогодний", new DateTime(2007, 10, 25))),
                (new Employee("Стас Рождественский", new DateTime(1992, 1, 25)))
            };
            // Dictionary<string, DateTime> listOfEmployee = new Dictionary<string, DateTime>{
            //     {"Ваня Иванов", new DateTime(2001, 10, 21)},
            //     {"Петя Петров", new DateTime(2008, 6, 12)},
            //     {"Коля Новогодний", new DateTime(2007, 10, 25)},
            //     {"Стас Рождественский", new DateTime(1992, 1, 25)}
            // };

            PrintBirthday(listOfEmployee, planingHorisont);
        }
        static void PrintBirthday(Employee[] listOfEmployee, int plan)
        {
            DateTime totalDate = DateTime.Today;
            int totalYear = totalDate.Year;
            int totalMonth = totalDate.Month;
            // System.Console.WriteLine(totalDate);

            Dictionary<int, List<string>> sortList = new Dictionary<int, List<string>>();
            foreach (Employee person in listOfEmployee)
            {
                int month = person.getDateBirth().Month;
                if (!sortList.ContainsKey(month)){
                    List<Employee> list = person;

                    sortList.Add(month, );
                }
            }

            for (int i = 0; i <= plan; i++)
            {
                System.Console.WriteLine($"{ConvertMonth(totalMonth - 1)} {totalYear}");
                Employee totalPerson = listOfEmployee[0];
                int persinDay = totalPerson.getDateBirth().Day;
                string persinName = totalPerson.getName();
                string personAge = getAge(totalPerson.getDateBirth());

                System.Console.WriteLine($"({persinDay}) - {persinName} ({personAge})");
                // foreach(Employee person in listOfEmployee){



                // }
            }
        }
        static string getAge(DateTime date)
        {
            DateTime totalDate = DateTime.Today;
            int age = totalDate.Subtract(date).Days / 365;

            return pluralization(age + 1);
        }
        static string pluralization(int numberOfAge)
        {
            string[] words = { "лет", "год", "года" };

            int sNumb = numberOfAge % 10;
            int dNumb = numberOfAge % 100;

            if ((10 <= dNumb && dNumb <= 20) || (sNumb == 0) || (5 <= sNumb && sNumb <= 20))
                return $"{numberOfAge} {words[0]}";
            else if (sNumb == 1)
                return $"{numberOfAge} {words[1]}";
            else
                return $"{numberOfAge} {words[2]}";
        }

        static string ConvertMonth(int month)
        {
            string[] months = {"Январь", "Февраль", "Март", "Апрель", "Май",
            "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};

            return months[month];
        }
    }
}
