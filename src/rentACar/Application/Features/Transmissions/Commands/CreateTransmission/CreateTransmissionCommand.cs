using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Fuels.Rules;
using Application.Features.Transmissions.Rules;

namespace Application.Features.Transmissions.Commands.CreateTransmission
{
    public class CreateTransmissionCommand : IRequest<Transmission>
    {
        public string Name { get; set; }
        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, Transmission>
        {
            ITransmissionRepository _transmissionRepository;
            IMapper _mapper;
            TransmissionBusinessRules _transmissionBusinessRules;

            public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusinessRules transmissionBusinessRules)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
                _transmissionBusinessRules = transmissionBusinessRules;
            }

            public async Task<Transmission> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);
                var mappedTransmission = _mapper.Map<Transmission>(request);
                var createdTransmission = await _transmissionRepository.AddAsync(mappedTransmission);
                return createdTransmission;
            }
        }
            }

}
