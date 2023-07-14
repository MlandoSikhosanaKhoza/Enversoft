
using Enversoft.Shared;
using Enversoft.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Enversoft.BusinessLogic
{
    public class EmployeeLogic:IEmployeeLogic
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            _employeeRepository=employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public Employee AddEmployee(Employee Employee)
        {
            return _employeeRepository.AddEmployee(Employee);
        }

        public Employee GetEmployee(int EmployeeId)
        {
            return _employeeRepository.GetEmployee(EmployeeId);
        }

        public bool UpdateEmployee(Employee Employee)
        {
            return _employeeRepository.UpdateEmployee(Employee);
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            return _employeeRepository.DeleteEmployee(EmployeeId);
        }
    }
}
