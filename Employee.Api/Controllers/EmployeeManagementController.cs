using EmployeeManagement.Api.ModelMappers;
using EmployeeManagement.Api.Models.RequestJSONs;
using EmployeeManagement.Api.ResquestJSONs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeManagerMapper _mapper;
        private readonly ILogger _logger;
        public EmployeeManagementController(IEmployeeService employeeService, IEmployeeManagerMapper employeeManagerMapper, ILogger<EmployeeManagementController> logger)
        {
            _employeeService = employeeService;
            _mapper = employeeManagerMapper;
            _logger = logger;
        }
  
       [HttpPost("AddEmployees")]
        public async Task <IActionResult> AddEmployees (List<AddEmployeesJSON> employeesJSON)
        {
            try
            {
                TryValidateModel(employeesJSON);
                if (ModelState.IsValid)
                {
                    List<Employee> employees = _mapper.MapAddEmployeesJSONListToEmployeeList(employeesJSON);
                    employees = await _employeeService.AddMultipleEmployees(employees);
                    return Ok(employees);
                }
                else
                {
                    
                    return BadRequest(employeesJSON);
                }           
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost("RemoveEmployees")]
        public async Task <IActionResult> RemoveEmployees(List<RemoveEmployeesJSON> removeEmployeesJSONs)
        {
            try
            {
                TryValidateModel(removeEmployeesJSONs);
                if (ModelState.IsValid)
                {
                    Dictionary<long,string> registrationNumbersAndNames = _mapper.MapRemoveEmployeesJSONToDictionary(removeEmployeesJSONs);
                    List<Employee> removedEmployees = await _employeeService.RemoveMultipleEmployees(registrationNumbersAndNames);
                    return Ok(removedEmployees);
                }
                else
                {
                    return BadRequest(removeEmployeesJSONs);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetaAllEmployees()
        {
            try
            {
                List<Employee> AllEmployees = await _employeeService.GetAllEmployees();
                return  Ok(AllEmployees);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

    }
}
