using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        ICarRepository _carRepository;

        public CarBusinessRules(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task PlateCanNotBeDuplicated(string plate)
        {
            var result = await _carRepository.GetListAsync(b => b.Plate==plate);
            if (result.Items.Any())
            {
                throw new BusinessException("Plate name exists");
            }
        }

        public async Task CarCanNotRentWhenIsInMaintenance(int id)
        {
            var carToRent = await _carRepository.GetAsync(c => c.Id == id);
            if (carToRent.CarState == Domain.Enums.CarState.Maintenance)
                throw new BusinessException("Car can not rent when it is in maintenance");
        }
        public async Task CarCanNoGetMaintenanceWhenIsRented(int id)
        {
            var carToMaintenance = await _carRepository.GetAsync(c => c.Id == id);
            if (carToMaintenance.CarState == Domain.Enums.CarState.Rented)
                throw new BusinessException("Car can not get maintenance when it is rented");
        }
        public async Task IsExist(int id)
        {
            var car = await _carRepository.GetAsync(c => c.Id == id);
            if (car==null)
                throw new BusinessException("Car is not exist");
        }
    }
}
