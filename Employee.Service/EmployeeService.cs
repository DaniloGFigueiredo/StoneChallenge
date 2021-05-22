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
        public async Task<List<Employee>> AddMultipleEmployees(List<Employee> employees)
        {

            foreach (Employee employee in employees)
            {
                Employee employeeInDB = await _employeeRepository.GetEmployeeByRegistrationNumberAndName(employee.RegistrationNumber, employee.Name);
                if (employeeInDB != null)
                {
                    throw new Exception("Funcionario " + employee.Name + " Matricula: " + employee.RegistrationNumber + " já cadastrado");
                }
            }
            await _employeeRepository.CreateManyEmployees(employees);

            return employees;
        }
        public async Task<List<Employee>> RemoveMultipleEmployees(Dictionary<long, string> RegistrationNumbersAndNames)
        {
            try
            {
                List<Employee> deletedEmployees = new List<Employee>();

                foreach (var item in RegistrationNumbersAndNames)
                {
                    Employee employeeInDB = await _employeeRepository.GetEmployeeByRegistrationNumberAndName(item.Key, item.Value);
                    if (employeeInDB == null)
                    {
                        throw new Exception("Funcionario " + item.Value + " com matricula " + item.Key + " não cadastrado");
                    }
                    Employee deletedEmployee = await _employeeRepository.DeleteEmployeeByRegistrationNumberAndName(item.Key, item.Value);
                    deletedEmployees.Add(deletedEmployee);
                }
                return deletedEmployees;
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = await _employeeRepository.GetAllEmployees();
                return employees;
            }
            catch
            {
                throw;
            }
        }
    }
}
