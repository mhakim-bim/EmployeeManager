using System;
using System.Text.RegularExpressions;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; private set; }
            
        public decimal Salary { get; set; }

        public TypeOfEmployee TypeOfEmployee { get; set; }
        
        public string EmailAddress { get; private set; }

        public Employee()
        {
            
        }

        public Employee(string firstName, string lastName, Gender gender, int age
            ,decimal salary, TypeOfEmployee typeOfEmployee, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            SetAge(age);
            Salary = salary;
            TypeOfEmployee = typeOfEmployee;
            SetEmailAddress(emailAddress);
        }



        #region Setters

        public void SetAge(int age)
        {
            if(age < 18)
                throw new ArgumentException("Age Should be more than 18 Years Old");
            if(age < 0)
                throw new ArgumentException("Age must be positive");
            this.Age = age;
        }

        public void SetEmailAddress(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                EmailAddress = email;
            else
                throw new Exception("Email is not in correct format");
        } 
        #endregion



        public override string ToString()
        {
            return $"{FirstName} {LastName} {EmailAddress} {Gender} {Age} {Salary:F2} {TypeOfEmployee}Employee";
        }
    }
}
