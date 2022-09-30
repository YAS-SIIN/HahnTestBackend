using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HahnTestBackend.Application.Employee;   
using HahnTestBackend.Core.Interfaces;
using HahnTestBackend.Domain.Commands.Employee;
using HahnTestBackend.Domain.Commands.Employee.Validators;     
using HahnTestBackend.Domain.Events;
using HahnTestBackend.Domain.Interfaces.Repositories;
using HahnTestBackend.Infra.Data.Context;              
using HahnTestBackend.Infra.Data.Repositories;             
//using HahnTestBackend.Infra.Messaging;

namespace HahnTestBackend.IoC
{
    public static class HahnTestBackendModule
    {
        public static void Register(this IServiceCollection services)
        {
            //data
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();           

            //validators
            services.AddScoped<IValidator<CreateEmployeeCommand>, CreateEmployeeCommandValidator>();
            services.AddScoped<IValidator<UpdateEmployeeCommand>, UpdateEmployeeCommandValidator>();

            //commandHandlers        
            services.AddScoped<ICommandHandler<CreateEmployeeCommand>, CreateEmployeeCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateEmployeeCommand>, UpdateEmployeeCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteEmployeeCommand>, DeleteEmployeeCommandHandler>();

            //queries                                                 
            services.AddScoped<IEmployeeQueries, EmployeeQueries>();

            ////messaging                                                                        
            //services.AddTransient<IEventConsumer<EmployeeEvent, Guid>, EmployeeEventConsumer>();
            //services.AddTransient<IEventConsumer<DeleteEmployeeEvent, Guid>, DeleteEmployeeEventConsumer>();
            services.AddScoped<IConsumerSubscriptions, ConsumerSubscriptions>();
                                                                                     
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<myDBContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}