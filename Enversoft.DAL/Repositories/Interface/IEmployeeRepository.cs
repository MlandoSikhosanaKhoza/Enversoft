using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee AddEmployee(Employee Employee);
        Employee GetEmployee(int EmployeeId);
        bool UpdateEmployee(Employee Employee);
        bool DeleteEmployee(int EmployeeId);
    }
}
