using System;
using System.Threading;
using EmployeeManager.Models;
using EmployeeManager.UI;

namespace EmployeeManager
{
    class Program
    {
        private static readonly EmployeeRepository _repository = new EmployeeRepository();
        
        static void Main(string[] args)
        {
            bool isValid = true;
            while (isValid)
            {
                UiOperations.OpeningOptions();
                if (ReadKeyFromUser(out var keyOptions, out isValid)) break;

                var helper = new EmployeeHandler(_repository);

                UiOperations.SubscribingToKeyEvents(keyOptions, helper);

                try
                {
                    keyOptions.RespondingToKeyEvents();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static bool ReadKeyFromUser(out KeyOptions keyOptions, out bool isValid)
        {
            var key = Console.ReadKey();

            keyOptions = new KeyOptions();
            isValid = keyOptions.IsValidKey(key);

            if (isValid == false)
            {
                EndOfProgram();
                return true;
            }

            Console.WriteLine();
            return false;
        }

        private static void EndOfProgram()
        {
            Console.WriteLine("****Exiting****");
            Thread.Sleep(1000);
        }
    }
}
