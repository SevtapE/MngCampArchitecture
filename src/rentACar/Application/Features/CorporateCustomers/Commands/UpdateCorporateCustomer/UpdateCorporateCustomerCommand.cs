using Application.Features.CorporateCustomers.Dtos;
using Application.Features.CorporateCustomers.Rules;
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

namespace Application.Features.CorporateCustomers.Commands.UpdateCorporateCustomer
{
    public class UpdateCorporateCustomerCommand : IRequest<CorporateCustomerDto>
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }

        public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, CorporateCustomerDto>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;
            IMapper _mapper;
            CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

            public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
            {
                _corporateCustomerRepository = corporateCustomerRepository;
                _mapper = mapper;
                _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
            }

            public async Task<CorporateCustomerDto> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
                var corporateCustomerToUpdate = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Id);
                if (corporateCustomerToUpdate == null) throw new BusinessException(" Customer can not be found");
              await _corporateCustomerBusinessRules.TaxNumberCanBotBeDublicated(request.TaxNumber);
             _mapper.Map(request, corporateCustomerToUpdate);
                await _corporateCustomerRepository.UpdateAsync(corporateCustomerToUpdate);
                var mappedCorporateCustomer =  _mapper.Map<CorporateCustomerDto>(corporateCustomerToUpdate);
                return mappedCorporateCustomer;

              
            }
        }
    }
}
