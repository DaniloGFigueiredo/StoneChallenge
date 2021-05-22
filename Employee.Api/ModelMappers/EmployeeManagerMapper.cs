using EmployeeManagement.Api.Models.RequestJSONs;
using EmployeeManagement.Api.ResquestJSONs;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static EmployeeManagement.Domain.Enums.Enum;

namespace EmployeeManagement.Api.ModelMappers
{
    public class EmployeeManagerMapper : IEmployeeManagerMapper
    {

        public List<Employee> MapAddEmployeesJSONListToEmployeeList (List <AddEmployeesJSON> employeeListJSON)
        {
            List<Employee> employees = new List<Employee>();

            foreach (AddEmployeesJSON employeeJSON in employeeListJSON)
            {
                    Employee employee = new Employee();
                    employee.RegistrationNumber = employeeJSON.RegistrationNumber;
                    employee.Name = employeeJSON.Name;
                    employee.Role = employeeJSON.Role;                 
                    employee.AdmissionDate = employeeJSON.AdmissionDate.Date;
                    employeeJSON.GrossSalary =Regex.Replace(employeeJSON.GrossSalary, @"[R$ .]", "");
                    employee.GrossSalary = Convert.ToDecimal(Regex.Replace(employeeJSON.GrossSalary, @"[,]", "."));
                    employeeJSON.Area = Regex.Replace(employeeJSON.Area, @"\s", "").ToUpper();
                    
                    switch (employeeJSON.Area)
                    {
                        case "DIRETORIA":
                            employee.Area = EmployeeArea.BoardOfDirectors;
                            break;
                        case "CONTABILIDADE":
                            employee.Area = EmployeeArea.Accountability;
                            break;
                        case "FINANCEIRO":
                            employee.Area = EmployeeArea.Finance;
                            break;
                        case "TECNOLOGIA":
                            employee.Area = EmployeeArea.Technology;
                            break;
                        case "SERVIÇOSGERAIS":
                            employee.Area = EmployeeArea.GeneralServices;
                            break;
                        case "RELACIONAMENTOCOMOCLIENTE":
                            employee.Area = EmployeeArea.CustomerRelations;
                            break;
                        default:
                            throw new InvalidEnumArgumentException();
                    }
                    employees.Add(employee);              
            }
            return employees;
        }
        
        public  Dictionary <long,string> MapRemoveEmployeesJSONToDictionary (List<RemoveEmployeesJSON>removeEmployeesJSONList)
        {
                Dictionary<long, string> registrationNumbersAndNames = new Dictionary<long, string>();

                foreach(RemoveEmployeesJSON removeEmployeeJSON in removeEmployeesJSONList)
                {
                    registrationNumbersAndNames.Add(removeEmployeeJSON.RegistrationNumber, removeEmployeeJSON.Name);
                }
                return registrationNumbersAndNames;
        }
    }
}
