using HahnTestBackend.Application.Employee;
using HahnTestBackend.Core.Interfaces;
using HahnTestBackend.Domain.Commands.Employee;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HahnTestBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class EmployeeController : ControllerBase
    {
        private readonly ICommandHandler<CreateEmployeeCommand> _createEmployeeCommandHandler;
        private readonly ICommandHandler<UpdateEmployeeCommand> _updateEmployeeCommandHandler;
        private readonly ICommandHandler<DeleteEmployeeCommand> _deleteEmployeeCommandHandler;
        private readonly IEmployeeQueries _EmployeeQueries;

        public EmployeeController(ICommandHandler<CreateEmployeeCommand> createEmployeeCommandHandler,
            ICommandHandler<UpdateEmployeeCommand> updateEmployeeCommandHandler,
            ICommandHandler<DeleteEmployeeCommand> deleteEmployeeCommandHandler,
            IEmployeeQueries EmployeeQueries)
        {
            _createEmployeeCommandHandler = createEmployeeCommandHandler;
            _updateEmployeeCommandHandler = updateEmployeeCommandHandler;
            _deleteEmployeeCommandHandler = deleteEmployeeCommandHandler;
            _EmployeeQueries = EmployeeQueries;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_EmployeeQueries.GetAllAsync().Result);
        }
      
        [HttpPost]
        public IActionResult Post(CreateEmployeeCommand command)
        {
            var result = _createEmployeeCommandHandler.Handle(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public IActionResult Put(UpdateEmployeeCommand command)
        {
            var result = _updateEmployeeCommandHandler.Handle(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteEmployeeCommand command)
        {
            var result = _deleteEmployeeCommandHandler.Handle(command);

            if (result.Success)
                return Ok(command);

            return BadRequest(result.Errors);
        }
    }

}
