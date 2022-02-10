using Application.Features.Brands.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Colors.Rules;
using Application.Features.CorporateCustomers.Rules;
using Application.Features.Fuels.Rules;
using Application.Features.IndividualCustomers.Rules;
using Application.Features.Models.Rules;
using Application.Features.Transmissions.Rules;
using Application.Features.Users.Rules;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddSingleton<LoggerServiceBase, FileLogger>();

            services.AddScoped<UserBusinessRules>();
            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<ModelBusinessRules>();
            services.AddScoped<ColorBusinessRules>();
            services.AddScoped<FuelBusinessRules>();
            services.AddScoped<CarBusinessRules>();
            services.AddScoped<TransmissionBusinessRules>();
            services.AddScoped<IndividualCustomerBusinessRules>();
            services.AddScoped<CorporateCustomerBusinessRules>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            return services;

        
        }
    }
}
