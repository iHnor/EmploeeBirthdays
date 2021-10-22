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

        public Dictionary<int, List<Employee>> GetEmploiesWithplaningHorizont(int planingHorizont){
            Dictionary<int, List<Employee>> result = new Dictionary<int, List<Employee>>();
            DateTime tempDate = currentDate;
            int endMonth = currentDate.Month + planingHorizont >= 12? (currentDate.Month + planingHorizont) % 12: currentDate.Month + planingHorizont;

            while(tempDate.Month != endMonth + 1){
                if(emploies.ContainsKey(tempDate.Month)){
                    result.Add(tempDate.Month, emploies[tempDate.Month]);
                }
                tempDate = tempDate.AddMonths(1);
            }

            return result;
        }
    }
}