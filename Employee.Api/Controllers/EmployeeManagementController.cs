using AutoMapper;
using EmployeeManagement.Api.ResquestJSONs;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        //private readonly IMapper _mapper;
        //public EmployeeManagementController(AutoMapper.IMapper mapper)
        //{
        //    _mapper = mapper;
        //}
        
        
        //public ActionResult AddEmployees (EmployeeJSON employeeJSON)
        //{
        //    Employee employee = _mapper.Map<EmployeeDTO>(employeeJSON);
        //}
    }
}
