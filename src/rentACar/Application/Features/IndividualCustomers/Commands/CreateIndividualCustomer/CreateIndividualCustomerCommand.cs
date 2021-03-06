using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands.CreateIndividualCustomer
{
    public class CreateIndividualCustomerCommand:IRequest<IndividualCustomer>
    {
       
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }

        public class CreateIndividualCustomerCommandHandlar : IRequestHandler<CreateIndividualCustomerCommand, IndividualCustomer>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;
            IndividualCustomerBusinessRules _individualCustomerBusinessRules;

            public CreateIndividualCustomerCommandHandlar(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public async Task<IndividualCustomer> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                await _individualCustomerBusinessRules.NationalIdCanBotBeDublicated(request.NationalId);

               var mappedIndividualCustomer= _mapper.Map<IndividualCustomer>(request);
               var createdIndividualCustomer= await _individualCustomerRepository.AddAsync(mappedIndividualCustomer);
                return createdIndividualCustomer;

            }
        }
    }
}
