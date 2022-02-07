using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusinessRules
    {
        IIndividualCustomerRepository _ındividualCustomerRepository;

        public IndividualCustomerBusinessRules(IIndividualCustomerRepository ındividualCustomerRepository)
        {
            _ındividualCustomerRepository = ındividualCustomerRepository;
        }

        public async Task NationalIdCanBotBeDublicated(string natianalId)
        {
            var result = await _ındividualCustomerRepository.GetListAsync(c => c.NatianalId == natianalId);
            if (result.Items.Any())
            {
                throw new BusinessException("NationalId cannot be dublicated");
            }
        }
    }
}
