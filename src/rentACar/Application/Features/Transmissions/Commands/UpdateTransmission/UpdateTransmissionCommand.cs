using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Transmissions.Dtos;
using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Transmissions.Commands.UpdateTransmission
{
    public class UpdateTransmissionCommand : IRequest<TransmissionDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, TransmissionDto>
        {
            ITransmissionRepository _transmissionRepository;
            IMapper _mapper;
            TransmissionBusinessRules _transmissionBusinessRules;

            public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmissionBusinessRules transmissionBusinessRules)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
                _transmissionBusinessRules = transmissionBusinessRules;
            }

            public async Task<TransmissionDto> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
            {
                var transmissionToUpdate = await _transmissionRepository.GetAsync(x => x.Id == request.Id);
                if (transmissionToUpdate == null)
                    throw new BusinessException("Transmission cannot found");


                await _transmissionBusinessRules.TransmissionNameCanNotBeDuplicatedWhenInserted(request.Name);

                 _mapper.Map(request, transmissionToUpdate);

                 await _transmissionRepository.UpdateAsync(transmissionToUpdate);

                var updatedTransmission = _mapper.Map<TransmissionDto>(transmissionToUpdate);

                return updatedTransmission;
            }
        }
    }

}
 