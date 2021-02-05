using System;
using System.Text;
using EmployeeManager.Models;

namespace EmployeeManager.UI
{
    public class EmployeeHandler
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public void AddNewEmployee()
        {
            Console.WriteLine("Enter First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter Email Address");
            var address = Console.ReadLine();

            Console.WriteLine("Enter Gender");
            var gender = GetGender();

            Console.WriteLine("Enter Age");
            var age = GetAge();

            Console.WriteLine("Please Enter Salary");
            var salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please Enter Employee Type");
            var typeOfEmployee = GetTypeOfEmployee();

            var newEmployee = new Employee(firstName,lastName, gender, age,salary, typeOfEmployee, address);
            _repository.Add(newEmployee);
            Console.WriteLine("Employee Added");
            Console.WriteLine($"Employee Details: {newEmployee}");
        }

        public  void PrintEmployees()
        {
            Console.WriteLine("Employee Details");
            foreach (var employee in _repository.GetAllEmployees())
            {
                Console.WriteLine(employee.ToString());
            }

            Console.WriteLine();
        }

        public  void UpdateEmployee()
        {
            Console.WriteLine("Please Enter Employee's Email Address");
            var email = Console.ReadLine();

            var employeeToUpdate = _repository.FindEmployeeByEmail(email);

            Console.WriteLine($"Please Enter First Name to update, current is :{employeeToUpdate.FirstName}");
            var firstName = Console.ReadLine();

            Console.WriteLine($"Please Enter Last Name to update, current is : {employeeToUpdate.LastName}");
            var lastName = Console.ReadLine();

            Console.WriteLine($"Please Enter Gender to update,current is : {employeeToUpdate.Gender} ");
            var gender = GetGender();

            Console.WriteLine($"Please Enter Age to update,current is: {employeeToUpdate.Age} ");
            var age = GetAge();
            
            Console.WriteLine($"Please Enter Salary to update,current is {employeeToUpdate.Salary}");
            var salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"Please Enter Employee Type to update,current is {employeeToUpdate.TypeOfEmployee}");
            var typeOfEmployee = GetTypeOfEmployee();

            Employee updatedEmployee = new Employee(firstName,lastName,gender,age,salary,typeOfEmployee,email);
            _repository.Update(email, updatedEmployee);
            Console.WriteLine("Employee Details Updated");
            Console.WriteLine(updatedEmployee);
        }

        public  void DeleteEmployeeByEmail()
        {
            Console.WriteLine("Please enter employee's Email Address");
            var email = Console.ReadLine();
            _repository.DeleteByEmail(email);
            Console.WriteLine("Employee Deleted");
        }

        public  void DeleteEmployeeByName()
        {
            Console.WriteLine("Please enter employee's Full Name");
            var name = Console.ReadLine();
            _repository.DeleteByName(name);
            Console.WriteLine("Employee Deleted");
        }

        public void GetEmployeeDetailsByEmail()
        {
            Console.WriteLine("Please enter employee's Email Address");
            var email = Console.ReadLine();
            var employee = _repository.FindEmployeeByEmail(email);
            if(employee == null)
                Console.WriteLine("Employee Not Found");
            Console.WriteLine("Employee Found");
            Console.WriteLine($"Employee Details : {employee}");
        }

        public  void GetTotalSalary()
        {
            Console.WriteLine("Please enter employee's Email Address");
            var email = Console.ReadLine();
            var employee = _repository.FindEmployeeByEmail(email);
            if (employee == null)
                Console.WriteLine("Employee Not Found");
            Console.WriteLine("Employee Found");
            Console.WriteLine($"Employee Total Salary : {_repository.GetTotalSalary(employee)}");
        }

        #region Getters
        private static Gender GetGender()
        {
            Console.WriteLine("Enter 0 For Male");
            Console.WriteLine("Enter 1 For Female");
            Console.WriteLine("Enter 2 For Other");
            var isValidGender = int.TryParse(Console.ReadLine(), out int genderNumber)
                                && genderNumber >= 0 && genderNumber <= 2;
            if (!isValidGender) throw new Exception("Invalid Input");
            var gender = (Gender)Enum.ToObject(typeof(Gender), genderNumber);
            return gender;
        }
        private static int GetAge()
        {
            var isValidAge = int.TryParse(Console.ReadLine(), out int age) && age > 18;
            if (!isValidAge)
                throw new Exception("Invalid Input or Age is than 18");
            return age;
        }
        private static TypeOfEmployee GetTypeOfEmployee()
        {
            Console.WriteLine("Enter 0 For Permanent");
            Console.WriteLine("Enter 1 For Contractual");
            var isValidType = int.TryParse(Console.ReadLine(), out int type) && type >= 0 && type <= 1;
            if (!isValidType)
                throw new Exception("Invalid Input");
            var typeOfEmployee = (TypeOfEmployee)Enum.ToObject(typeof(TypeOfEmployee), type);
            return typeOfEmployee;
        } 
        #endregion
    }
}
