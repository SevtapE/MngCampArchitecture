using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Rules;
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


namespace Application.Features.Fuels.Commands.UpdateFuel
{
    public class UpdateFuelCommand : IRequest<FuelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, FuelDto>
        {
            IFuelRepository _fuelRepository;
            IMapper _mapper;
            FuelBusinessRules _fuelBusinessRules;

            public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper, FuelBusinessRules fuelBusinessRules)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
                _fuelBusinessRules = fuelBusinessRules;
            }

            public async Task<FuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                var fuelToUpdate = await _fuelRepository.GetAsync(x => x.Id == request.Id);
                if (fuelToUpdate == null)
                    throw new BusinessException("Fuel cannot found");


                await _fuelBusinessRules.FuelNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);

                 _mapper.Map(request, fuelToUpdate);

                 await _fuelRepository.UpdateAsync(fuelToUpdate);

                var dto = _mapper.Map<FuelDto>(fuelToUpdate);

                return dto;
            }
        }
    }

}
 