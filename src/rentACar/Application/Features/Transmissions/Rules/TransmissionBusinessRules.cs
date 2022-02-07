using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Rules
{
    public class TransmissionBusinessRules
    {
        ITransmissionRepository _transmissionRepository;

        public TransmissionBusinessRules(ITransmissionRepository transmissionRepository)
        {
            _transmissionRepository = transmissionRepository;
        }
        public async Task TransmissionNameCanNotBeDuplicatedWhenInserted(string name)
        {
            var result = await _transmissionRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Transmission name exists");
            }
        }
    }
}
