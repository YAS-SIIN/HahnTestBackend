
using HahnTestBackend.Core.Interfaces;         
using HahnTestBackend.Domain.Entities;
using HahnTestBackend.Domain.Interfaces.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _employeeRepository.Add(model);

            _employeeRepository.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody]  Employee model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
