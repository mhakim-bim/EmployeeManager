using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManager.Models;
using NUnit.Framework;
using Moq;

namespace EmployeeManager.UnitTests
{
    public class EmployeeRepositoryTests
    {
        private Employee _newEmployee;
        private Employee _firstEmployee;
        private Employee _secondEmployee;
        private EmployeeRepository _repository;

        [SetUp]
        public void Setup()
        {
            _firstEmployee = new Employee("Mohamed", "Elhakim", Gender.Male, 29, 8000, TypeOfEmployee.Permanent,
                "melhakim2016@gmail.com");

            _secondEmployee = new Employee("Bassant", "Mohamed", Gender.Female, 32, 10000,
                TypeOfEmployee.Contractual, "nosha@gmail.com");

            _newEmployee = new Employee("Youssef","Elhakim",Gender.Male,19,6000
                ,TypeOfEmployee.Permanent, "dodo@gmail.com");
        }

        [Test]
        public void GetAllEmployees_WhenCalled_ReturnsAllEmployees()
        {
            _repository = new EmployeeRepository();
            _repository.Add(_firstEmployee);
            _repository.Add(_secondEmployee);

            Assert.That(_repository.GetAllEmployees().Count,Is.EqualTo(2));
        }

        [Test]
        public void CreateEmployee_WhenCalled_AddNewEmployee()
        {
            _repository = new EmployeeRepository();

            var employee = _repository.Add(_newEmployee);

            Assert.That(employee.ToString(), Is.EqualTo("Youssef Elhakim dodo@gmail.com Male 19 6000.00 PermanentEmployee"));
            Assert.That(_repository.GetAllEmployees().Last(), Is.EqualTo(employee));
        }

        [Test]
        public void CreateEmployee_WhenDuplicatedEmail_ThrowsException()
        {
            _repository = new EmployeeRepository();

            _repository.Add(_newEmployee);

           Assert.That(() => _repository.Add(_newEmployee),Throws.ArgumentException);
        }
        
        [Test]
        public void UpdateEmployee_WhenCalled_ReturnsUpdatedEmployee()
        {
            _repository = new EmployeeRepository();

            _repository.Add(_newEmployee);

            var newEmployee = new Employee("Youssef", "Elhakim", Gender.Male, 20, 6000
                , TypeOfEmployee.Contractual, "dodo@gmail.com");
           var result=  _repository.Update("dodo@gmail.com", newEmployee);

            Assert.That(result.ToString() , Is.EqualTo("Youssef Elhakim dodo@gmail.com Male 20 6000.00 ContractualEmployee"));
        }

        [Test]
        public void DeleteEmployeeByEmail_WhenCalledWithExistingEmail_RemovesEmployee()    
        {
           
            _repository = new EmployeeRepository();
            _repository.Add(_firstEmployee);
            _repository.Add(_secondEmployee);

            _repository.DeleteByEmail("nosha@gmail.com");
           
            Assert.That(_repository.GetAllEmployees().Count, Is.EqualTo(1));
        }

        [Test]
        public void DeleteEmployeeByName_WhenCalledWithExistingEmail_RemovesEmployee()
        {
          
            _repository = new EmployeeRepository();
            _repository.Add(_firstEmployee);
            _repository.Add(_secondEmployee);

            _repository.DeleteByName("Mohamed Elhakim");

            Assert.That(_repository.GetAllEmployees().Count, Is.EqualTo(1));
        }

        [Test]
        public void FindEmployeeByEmail_WhenCalledWithExistingEmail_ReturnsEmployee()
        {
            _repository = new EmployeeRepository(); 
            _repository.Add(_firstEmployee);
            _repository.Add(_newEmployee);

            var result = _repository.FindEmployeeByEmail("dodo@gmail.com");

            Assert.That(result.ToString(), Is.EqualTo("Youssef Elhakim dodo@gmail.com Male 19 6000.00 PermanentEmployee"));
        }

        [Test]
        public void GetTotalSalary_WhenCalledWithExistingEmail_ReturnsTotalSalary()
        {
            _repository = new EmployeeRepository();
           
            _repository.Add(_secondEmployee);

            var employee = _repository.FindEmployeeByEmail("nosha@gmail.com");
            var result = _repository.GetTotalSalary(employee);

            Assert.That(result, Is.EqualTo(120000m));
        }

    }
}