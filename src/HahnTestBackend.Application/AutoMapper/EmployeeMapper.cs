using AutoMapper;
using HahnTestBackend.Domain.Commands.Employee;
using HahnTestBackend.Domain.Events;
//using HahnTestBackend.Domain.Tests.Entities.Validators.Entities.ValueObjects;

namespace HahnTestBackend.Application.AutoMapper
{
    public static class EmployeeMapper
    {
        public static Domain.Entities.Employee CommandToEntity(CreateEmployeeCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<CreateEmployeeCommand, Domain.Entities.Employee>();     
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.Employee>(command);
        }
        
        public static Domain.Entities.Employee CommandToEntity(UpdateEmployeeCommand command)
        {
            var config = new MapperConfiguration(configure =>
            {
                configure.CreateMap<UpdateEmployeeCommand, Domain.Entities.Employee>();    
            });

            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entities.Employee>(command);
        }

        public static EmployeeEvent EntityToEvent(Domain.Entities.Employee entity)
        {
            var config = new MapperConfiguration(configure =>
            {                                                                       
                configure.CreateMap<Domain.Entities.Employee, EmployeeEvent>();
            });

            var mapper = config.CreateMapper();
            return mapper.Map<EmployeeEvent>(entity);
        }
    }
}