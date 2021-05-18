using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> AddMultipleEmployees(List<Employee> employees);
        void RemoveMultipleEmployees(Dictionary<long, string> RegistrationNumberAndName);
       List<Employee> GetAllEmployees();
    }
}
