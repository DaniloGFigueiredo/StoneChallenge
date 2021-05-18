using EmployeeManagement.Api.ModelMappers;
using EmployeeManagement.Api.Models.RequestJSONs;
using EmployeeManagement.Api.ResquestJSONs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeManagerMapper _mapper;
        public EmployeeManagementController(IEmployeeService employeeService, IEmployeeManagerMapper employeeManagerMapper)
        {
            _employeeService = employeeService;
            _mapper = employeeManagerMapper;
        }
  
       [HttpPost("AddEmployees")]
        public ActionResult Post(List<AddEmployeesJSON> employeesJSON)
        {
            try
            {
                TryValidateModel(employeesJSON);
                if (ModelState.IsValid)
                {
                    List<Employee> employees = _mapper.MapAddEmployeesJSONListToEmployeeList(employeesJSON);
                    employees = _employeeService.AddMultipleEmployees(employees);
                    return Ok(employees);
                }
                else
                {
                    return BadRequest(employeesJSON);
                }           
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost("RemoveEmployees")]
        public ActionResult Post(List<RemoveEmployeesJSON> removeEmployeesJSONs)
        {
            try
            {
                TryValidateModel(removeEmployeesJSONs);
                if (ModelState.IsValid)
                {
                    Dictionary<long,string> registrationNumbersAndNames = _mapper.MapRemoveEmployeesJSONToDictionary(removeEmployeesJSONs);
                     _employeeService.RemoveMultipleEmployees(registrationNumbersAndNames);
                    return Ok(registrationNumbersAndNames);
                }
                else
                {
                    return BadRequest(removeEmployeesJSONs);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public ActionResult GetAllEmployees()
        {
            try
            {
                List<Employee> AllEmployees = _employeeService.GetAllEmployees();
                return Ok(AllEmployees);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
