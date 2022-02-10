using Application.Features.Cars.Commands.CreateCars;
using Core.Application.Pipelines.Validation;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.CreateCar
{
    public class CreateCarCommandValidator:AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(c => c.Plate).NotEmpty().NotNull();
        }
   
 
    }
}
