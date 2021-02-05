using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();

        Employee Add(Employee newEmployee);

        void DeleteByEmail(string email);

        void DeleteByName(string name);

        Employee Update(string email, Employee newEmployee);

        Employee FindEmployeeByEmail(string email);

        decimal GetTotalSalary(Employee employee);

    }
}
