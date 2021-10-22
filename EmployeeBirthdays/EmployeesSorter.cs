using System;
using System.Collections.Generic;

using System.Linq;


namespace EmployeeBirthdays
{
    public class EmployeesSorter
    {
        private DateTime currentDate = DateTime.Today;
        private Dictionary<int, List<Employee>> emploies = new Dictionary<int, List<Employee>>();

        public EmployeesSorter(List<Employee> emploies)
        {

            emploies.OrderBy(x => x.getDateBirth());

            foreach (var i in emploies)
            {
                if (!this.emploies.ContainsKey(i.getDateBirth().Month))
                {
                    this.emploies.Add(i.getDateBirth().Month, new List<Employee>());
                }
                this.emploies[i.getDateBirth().Month].Add(i);
            }
        }

        public Dictionary<int, List<Employee>> GetSortEmploies(int key)
        {
            Dictionary<int, List<Employee>> result = new Dictionary<int, List<Employee>>();
            result.Add(key, emploies[key]);
            return result;
        }
        public bool isElemInDictionary(int key)
        {
            return emploies.ContainsKey(key);
        }
    }
}