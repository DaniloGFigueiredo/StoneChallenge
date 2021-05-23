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
        Task<List<Employee>> GetAllEmployees();
        Task<List<Employee>> CreateManyEmployees(List<Employee> employees);
        Task<Employee> GetEmployeeByRegistrationNumberAndName(long registrationNumber, string name);
        Task<Employee> DeleteEmployeeByRegistrationNumberAndName(long registrationNumber, string name);
    }
}
