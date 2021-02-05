using System;

namespace EmployeeManager.UI
{
    public  class KeyOptions
    {
        private  ConsoleKeyInfo _consoleKey;
        
        public EventHandler AddEmployeeEventHandler;
        public EventHandler GetAllEmployeesEventHandler;
        public EventHandler UpdateEmployeeEventHandler;
        public EventHandler DeleteEmployeeByEmailEventHandler;
        public EventHandler DeleteEmployeeByNameEventHandler;
        public EventHandler GetEmployeeByEmailEventHandler;
        public EventHandler GetTotalSalaryOfEmployeeEventHandler;

        public bool IsValidKey(ConsoleKeyInfo consoleKey)
        {
            _consoleKey = consoleKey;
            return (  consoleKey.KeyChar >= 49 &&  consoleKey.KeyChar <= 55);
        }

        //Todo:Rename it to something different
        public void RespondingToKeyEvents()
        {
            if(_consoleKey.KeyChar == 49)
                OnAddEmployee();
            if (_consoleKey.KeyChar == 50)
                OnGetAllEmployees();
            if (_consoleKey.KeyChar == 51)
               OnUpdateEmployee();
            if (_consoleKey.KeyChar == 52)
                OnDeleteEmployeeByEmail();
            if (_consoleKey.KeyChar == 53)
                OnDeleteEmployeeByName();
            if (_consoleKey.KeyChar == 54)
                OnGetEmployeeByEmail();
            if (_consoleKey.KeyChar == 55)
               OnGetTotalSalaryOfEmployee();
        }

        protected virtual void OnAddEmployee()
        {
            AddEmployeeEventHandler?.Invoke(this,EventArgs.Empty);
        }

        protected virtual void OnGetAllEmployees()
        {
            GetAllEmployeesEventHandler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnUpdateEmployee()
        {
            UpdateEmployeeEventHandler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDeleteEmployeeByEmail()
        {
            DeleteEmployeeByEmailEventHandler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDeleteEmployeeByName()
        {
            DeleteEmployeeByNameEventHandler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnGetEmployeeByEmail()
        {
            GetEmployeeByEmailEventHandler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnGetTotalSalaryOfEmployee()
        {
            GetTotalSalaryOfEmployeeEventHandler?.Invoke(this, EventArgs.Empty);
        }
    }
}   
