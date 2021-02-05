using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.UI
{
    public class UiOperations
    {
        public static void SubscribingToKeyEvents(KeyOptions keyOptions,EmployeeHandler helper)
        {
            keyOptions.AddEmployeeEventHandler += (sender, eventArgs) => { helper.AddNewEmployee(); };

            keyOptions.GetAllEmployeesEventHandler += (sender, eventArgs) => { helper.PrintEmployees(); };

            keyOptions.UpdateEmployeeEventHandler += (sender, eventArgs) => { helper.UpdateEmployee(); };

            keyOptions.DeleteEmployeeByEmailEventHandler += (sender, eventArgs) => { helper.DeleteEmployeeByEmail(); };

            keyOptions.DeleteEmployeeByNameEventHandler += (sender, eventArgs) => { helper.DeleteEmployeeByName(); };

            keyOptions.GetEmployeeByEmailEventHandler += (sender, eventArgs) => { helper.GetEmployeeDetailsByEmail(); };

            keyOptions.GetTotalSalaryOfEmployeeEventHandler += (sender, eventArgs) => { helper.GetTotalSalary(); };
        }

        public static void OpeningOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Please Select an option");
            Console.WriteLine("Press 1 to Add new Employee");
            Console.WriteLine("Press 2 to Get details of all employees");
            Console.WriteLine("Press 3 to Update an employee");
            Console.WriteLine("Press 4 to Delete an employee By entering email address");
            Console.WriteLine("Press 5 to delete an employee By entering name");
            Console.WriteLine("Press 6 to Get details of specific employee By entering email address");
            Console.WriteLine("Press 7 to Get Total Salaries of an employee");
            Console.WriteLine("Press any other key to exit");
        }
    }
}
