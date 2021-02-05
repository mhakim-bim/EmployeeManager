using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
          
        public Employee Add(Employee newEmployee)
        {
            if (newEmployee == null) return null;
            if(_employees.Find(e => e.EmailAddress == newEmployee.EmailAddress) != null)
                throw new ArgumentException("Email Address Already Used");
            //if (_employees.Where(e => e.EmailAddress == newEmployee.EmailAddress) != null)
            //    throw new ArgumentException("Email Address Already Used");
            _employees.Add(newEmployee);
            return newEmployee;
        }

        public void DeleteByEmail(string email)
        {
            var employee = FindEmployeeByEmail(email);
            _employees.Remove(employee);
        }

        public void DeleteByName(string name)
        {
            var namesArray = name.Split(' ');
            var firstName = namesArray[0];
            var lastName = namesArray[1];

            var employee = 
                _employees.FirstOrDefault(emp => emp.FirstName == firstName && emp.LastName == lastName);
            if (employee == null)
              throw new ArgumentException("Name doesn't Exist in our database");
            _employees.Remove(employee);
        }

        public Employee Update(string email,Employee newEmployee)
        {
            var employee = _employees.FirstOrDefault(emp => emp.EmailAddress == email);
            if (employee == null) return null;

            employee.FirstName = newEmployee.FirstName;
            employee.LastName = newEmployee.LastName;
            employee.Gender = newEmployee.Gender;
            employee.Salary = newEmployee.Salary;
            employee.TypeOfEmployee = newEmployee.TypeOfEmployee;
            employee.SetAge(newEmployee.Age); 
            
            return employee;
        }

        public Employee FindEmployeeByEmail(string email)
        {
              var employee = _employees.Find(e => e.EmailAddress == email);
              if(employee == null) throw new Exception("Employee With Entered Email doesn't Exist");
              return employee;
        }

        public decimal GetTotalSalary(Employee employee)
        {
            if (employee.TypeOfEmployee == TypeOfEmployee.Permanent)
                 return (employee.Salary * 12) + (decimal)0.08 * employee.Salary;
            if (employee.TypeOfEmployee == TypeOfEmployee.Contractual)
                return employee.Salary * 12;
            return 0;
        }
    }
}