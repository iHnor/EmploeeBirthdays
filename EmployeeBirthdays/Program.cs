using System;
using System.Collections.Generic;
using System.Globalization;
namespace EmployeeBirthdays
{
    public class Employee
    {
        private string nameOfPerson;
        private DateTime birthday;
        public Employee(string nameOfPerson, DateTime birthday)
        {
            this.nameOfPerson = nameOfPerson;
            this.birthday = birthday;
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
            int planingHorizon = 12;

            List<Employee> listOfEmployee = new List<Employee>{
                (new Employee("Ваня Иванов", new DateTime(2001, 10, 21))),
                (new Employee("Петя Петров", new DateTime(2008, 11, 12))),
                (new Employee("Коля Новогодний", new DateTime(2007, 10, 1))),
                (new Employee("Стас Рождественский", new DateTime(1992, 4, 25)))
            };

            EmployeesSorter sorter = new EmployeesSorter(listOfEmployee);
            PrintBirthday(sorter, planingHorizon);
        }
        static void PrintBirthday(EmployeesSorter sorter, int plan)
        {
            DateTime today = DateTime.Now;
            
            for (int j = 0; j <= plan; j++)
            {
                if (sorter.isElemInDictionary(today.Month))
                {
                    foreach (var i in sorter.GetSortEmployees(today.Month))
                    { 
                        string month = today.ToString("MMMM", CultureInfo.GetCultureInfo("ru-RU"));
                        System.Console.WriteLine($"{month} {today.Year}");
                        foreach (Employee value in i.Value)
                        {
                            string day = value.getDateBirth().ToString("dd");
                            string name = value.getName();
                            DateTime age = value.getDateBirth();
                            Console.WriteLine($"({day}) - {name} ({getAge(age, today)})");
                        }
                    }
                }

                today = today.AddMonths(1);
            }
        }
        static string getAge(DateTime date, DateTime totalDate)
        {
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
