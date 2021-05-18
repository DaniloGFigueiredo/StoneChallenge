using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        List<Employee> CreateManyEmployees(List<Employee> employees);
        Employee GetEmployeeByRegistrationNumberAndName(long registrationNumber, string name);
        void DeleteEmployeeByRegistrationNumberAndName(long registrationNumber, string name);
    }
}
