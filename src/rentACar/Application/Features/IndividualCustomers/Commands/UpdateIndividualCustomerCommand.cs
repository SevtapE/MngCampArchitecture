using Application.Features.IndividualCustomers.Dtos;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands
{
    public class UpdateIndividualCustomerCommand:IRequest<IndividualCustomerDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }

        public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, IndividualCustomerDto>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;
            IndividualCustomerBusinessRules _individualCustomerBusinessRules;

            public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules individualCustomerBusinessRules)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
                _individualCustomerBusinessRules = individualCustomerBusinessRules;
            }

            public async Task<IndividualCustomerDto> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                var individualCustomerToUpdate = await _individualCustomerRepository.GetAsync(c => c.Id == request.Id);
                if (individualCustomerToUpdate == null) throw new BusinessException(" Customer can not be found");
              await _individualCustomerBusinessRules.NationalIdCanBotBeDublicated(request.NationalId);
             _mapper.Map(request, individualCustomerToUpdate);
                await _individualCustomerRepository.UpdateAsync(individualCustomerToUpdate);
                var mappedIndividualCustomer =  _mapper.Map<IndividualCustomerDto>(individualCustomerToUpdate);
                return mappedIndividualCustomer;

              
            }
        }
    }
}
