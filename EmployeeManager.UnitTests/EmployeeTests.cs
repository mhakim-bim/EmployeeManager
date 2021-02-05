using System;
using System.Collections.Generic;
using EmployeeManager.Models;
using NUnit.Framework;
using Moq;

namespace EmployeeManager.UnitTests
{
    public class EmployeeTests
    {
        private List<Employee> _employees;
        private Employee _newEmployee;

        [SetUp]
        public void Setup()
        {
            _employees = new List<Employee>()
            {
                new Employee("Mohamed","Elhakim",Gender.Male,29,8000,TypeOfEmployee.Permanent,"melhakim2016@gmail.com")
                ,new Employee("Bassant","Mohamed",Gender.Female,32,10000,TypeOfEmployee.Contractual,"nosha@gmail.com")
            };

            _newEmployee = new Employee("Youssef","Elhakim",Gender.Male,19
                ,6000.05m,TypeOfEmployee.Permanent,"dodo@gmail.com");
        }

        [Test]
        public void SetEmailAddress_WhenCalled_NoExceptionThrown()
        {
             var employee = new Employee();

            employee.SetEmailAddress("dodo@gmail.com");
            Assert.That(employee.EmailAddress,Is.EqualTo("dodo@gmail.com"));

        }


        [Test]
        public void SetEmailAddress_WhenCalled_ExceptionThrown()
        {
            var employee = new Employee();

            Assert.That(() => employee.SetEmailAddress("dodogmail.com") , Throws.Exception);

        }

        [Test]
        public void GetEmployee_WhenCalled_ReturnsCorrectStringFormat()
        {
           
            Assert.That(_newEmployee.ToString(), Is.EqualTo("Youssef Elhakim dodo@gmail.com Male 19 6000.05 PermanentEmployee"));
        }

    }
}