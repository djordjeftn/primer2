using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeBusiness
    {
        private readonly EmployeesRepository employeeRepository;
        public EmployeeBusiness()
        {
            this.employeeRepository = new EmployeesRepository();
        }

        public List<Employee> GetEmployees()
        {
            return this.employeeRepository.GetEmployees();
        }
        public List<Employee> GetEmployeesRange(decimal x, decimal y)
        {
            return this.employeeRepository.GetEmployees().Where(element => element.Salary > x && element.Salary < y).ToList();
        }
        public bool InsertEmployee(Employee e)
        {
            if (this.employeeRepository.InsertEmployees(e) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
