using Core.Application.Pipelines.Validation;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(c=>c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            //  RuleFor(b => b.Name).Must(FirstLetterMustBeUpperCase).WithMessage("First letter must be UpperCase").WithErrorCode("UpperCase Error");
            //RuleFor(b => b.Name).FirstLetterMustBeUpperCase();
            RuleFor(b =>b.Name).FirstLetterMustBeLowerCase();
        }
        private bool FirstLetterMustBeUpperCase(string args)
        {
            return args[0] > 65 && args[0] < 91;
        }
    }
}
