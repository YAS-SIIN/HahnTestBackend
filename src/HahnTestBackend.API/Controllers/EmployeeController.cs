
using FluentValidation;

using HahnTestBackend.Core.Interfaces;         
using HahnTestBackend.Domain.Entities;
using HahnTestBackend.Domain.Interfaces.Repositories;
using HahnTestBackend.Domain.Validators;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace HahnTestBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EmployeeController : ControllerBase
    {                                                                             
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeRepository.GetAllAsync().Result);
        }
      
        [HttpPost]
        public IActionResult Post([FromBody] Employee model)
        {
            model.Name = "";
 EmployeeValidator modelValidator = new EmployeeValidator();
          var validation= modelValidator.Validate(model);
            if (!validation.IsValid)
            {
                return BadRequest(validation);
            }
            _employeeRepository.Add(model);

            _employeeRepository.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody]  Employee model)
        {
            EmployeeValidator modelValidator = new EmployeeValidator();
            var validation = modelValidator.Validate(model);
            if (!validation.IsValid)
            {
                return BadRequest(validation);
            }

            model.Updated = DateTime.Now;
             _employeeRepository.Update(model);
            _employeeRepository.SaveChanges();

            return Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
           _employeeRepository.Delete(Id);
            _employeeRepository.SaveChanges();

            return Ok();
        }
    }

}
