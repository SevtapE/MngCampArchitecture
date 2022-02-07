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
    public class MaintenanceCarCommand:IRequest<Car>
    {
        public int Id { get; set; }
        public class MaintenanceCarCommandHandler : IRequestHandler<MaintenanceCarCommand, Car>
        {
            ICarRepository _carRepository;
            CarBusinessRules _carBusinessRule;

            public MaintenanceCarCommandHandler(ICarRepository carRepository, CarBusinessRules carBusinessRule)
            {
                _carRepository = carRepository;
                _carBusinessRule = carBusinessRule;
            }

            public async Task<Car> Handle(MaintenanceCarCommand request, CancellationToken cancellationToken)
            {
                await _carBusinessRule.IsExist(request.Id);
                await _carBusinessRule.CarCanNoGetMaintenanceWhenIsRented(request.Id);

                var carToMaintenance = await _carRepository.GetAsync(c => c.Id == request.Id);
                carToMaintenance.CarState = Domain.Enums.CarState.Maintenance;
                await _carRepository.UpdateAsync(carToMaintenance);
                return carToMaintenance;
            }
        }
    }
}
