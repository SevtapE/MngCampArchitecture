using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands
{
    public class RentCarCommand:IRequest<Car>
    {
        public int Id { get; set; }
        public class RentCarCommandHandler : IRequestHandler<RentCarCommand, Car>
        {
            ICarRepository _carRepository;
            CarBusinessRules _carBusinessRule;

            public RentCarCommandHandler(ICarRepository carRepository, CarBusinessRules carBusinessRule)
            {
                _carRepository = carRepository;
                _carBusinessRule = carBusinessRule;
            }

            public async Task<Car> Handle(RentCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRule.IsExist(request.Id);
                await _carBusinessRule.CarCanNotRentWhenIsInMaintenance(request.Id);

                var carToRent = await _carRepository.GetAsync(c => c.Id == request.Id);
                carToRent.CarState = Domain.Enums.CarState.Rented;
                await _carRepository.UpdateAsync(carToRent);
                return carToRent;
            }
        }
    }
}
