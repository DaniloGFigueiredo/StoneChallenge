using EmployeeManagement.Api.Models.RequestJSONs;
using EmployeeManagement.Api.ResquestJSONs;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.ModelMappers
{
    public interface IEmployeeManagerMapper
    {
        List<Employee> MapAddEmployeesJSONListToEmployeeList(List<AddEmployeesJSON> employeeListJSON);

        Dictionary<long, string> MapRemoveEmployeesJSONToDictionary(List<RemoveEmployeesJSON> removeEmployeesJSONList);
    }
}
