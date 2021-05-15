using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Employee.Domain.Enums.Enum;

namespace Employee.Domain.Entities
{
    public class Employee
    {
        public long RegistrationNumber { get; set; }
        public string Name { get; set; }    
        public EmployeeArea Area { get; set; }
        public string Role { get; set; }
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }

        public Employee(long registrationNumber, string name, EmployeeArea area, string role, decimal grossSalary, DateTime admissionDate )
        {
            RegistrationNumber = registrationNumber;
            Name = name;
            Area = area;
            Role = role;
            GrossSalary = grossSalary;
            AdmissionDate = admissionDate;
        }
    }
}
