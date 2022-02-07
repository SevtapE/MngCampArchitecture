using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Cars.Commands.UpdateCars
{
    public class UpdateCarCommand : IRequest<CarDto>
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int ModelId { get; set; }
        public string Plate { get; set; }
        public short ModelYear { get; set; }
        public CarState CarState { get; set; }
        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarDto>
        {
            ICarRepository _carRepository;
            IMapper _mapper;
            CarBusinessRules _carBusinessRules;

            public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
            {
                _carRepository = carRepository;
                _mapper = mapper;
                _carBusinessRules = carBusinessRules;
            }

            public async Task<CarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var carToUpdate = await _carRepository.GetAsync(x => x.Id == request.Id);
                if (carToUpdate == null)
                    throw new BusinessException("Brand cannot found");


                await _carBusinessRules.PlateCanNotBeDuplicated(request.Plate);
                 _mapper.Map(request, carToUpdate);

                 await _carRepository.UpdateAsync(carToUpdate);

                var updatedCar = _mapper.Map<CarDto>(carToUpdate);

                return updatedCar;
            }
        }
    }

}
