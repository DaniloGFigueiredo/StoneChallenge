using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<Employee> AddMultipleEmployees(List<Employee> employees)
        {
            try
            {
                foreach (Employee employee in employees)
                {
                    Employee employeeInDB = _employeeRepository.GetEmployeeByRegistrationNumberAndName(employee.RegistrationNumber, employee.Name);
                    if (employeeInDB != null)
                    {
                        throw new Exception("Funcionario " + employee.Name + " Matricula: " + employee.RegistrationNumber + " já cadastrado");
                    }
                }
                _employeeRepository.CreateManyEmployees(employees);
            }
            catch
            {
                throw;
            }
            return employees;
        }
        public void RemoveMultipleEmployees(Dictionary <long,string> RegistrationNumbersAndNames)
        {
            try
            {
                foreach (var item in RegistrationNumbersAndNames)
                {
                    Employee employeeInDB = _employeeRepository.GetEmployeeByRegistrationNumberAndName(item.Key, item.Value);
                    if (employeeInDB == null)
                    {
                        throw new Exception("Funcionario " + item.Value + " com matricula " + item.Key + " não cadastrado");
                    }
                    _employeeRepository.DeleteEmployeeByRegistrationNumberAndName(item.Key, item.Value);
                }
            }
            catch
            {
                throw;
            }
        }
        public List<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = _employeeRepository.GetAllEmployees();
                return employees;
            }
            catch
            {
                throw;
            }
        }
    }
}
