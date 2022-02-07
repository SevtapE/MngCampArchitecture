using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands
{
    public class CreateCorporateCustomerCommand : IRequest<CorporateCustomer>
    {

        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public class CreateCorporateCustomerCommandHandlar : IRequestHandler<CreateCorporateCustomerCommand, CorporateCustomer>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;
            CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

            public CreateCorporateCustomerCommandHandlar(ICorporateCustomerRepository individualCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules individualCustomerBusinessRules)
            {
                _corporateCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public async Task<CorporateCustomer> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                await _corporateCustomerBusinessRules.TaxNumberCanBotBeDublicated(request.TaxNumber);

               var mappedCorporateCustomer = _mapper.Map<CorporateCustomer>(request);
               var createdCorporateCustomer = await _corporateCustomerRepository.AddAsync(mappedCorporateCustomer);
                return createdCorporateCustomer;

            }
        }
    }
}
