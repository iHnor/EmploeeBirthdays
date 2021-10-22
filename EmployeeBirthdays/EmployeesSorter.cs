using System;
using System.Collections.Generic;

using System.Linq;


namespace EmployeeBirthdays
{
    public class EmployeesSorter
    {
        private DateTime currentDate = DateTime.Today;
        private Dictionary<int, List<Employee>> employeesByMonth = new Dictionary<int, List<Employee>>();

        public EmployeesSorter(List<Employee> employees)
        {
            // сортування по дню народження
            employees.OrderBy(x => x.getDateBirth());

            foreach (var emp in employees)
            {
                if (!this.employeesByMonth.ContainsKey(emp.getDateBirth().Month))
                {
                    this.employeesByMonth.Add(emp.getDateBirth().Month, new List<Employee>());
                }
                this.employeesByMonth[emp.getDateBirth().Month].Add(emp);
            }
        }

        public Dictionary<int, List<Employee>> GetSortEmployees(int key)
        {
            Dictionary<int, List<Employee>> result = new Dictionary<int, List<Employee>>();
            result.Add(key, employeesByMonth[key]);
            return result;
        }
        public bool isElemInDictionary(int key)
        {
            return employeesByMonth.ContainsKey(key);
        }
    }
}