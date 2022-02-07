using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
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


namespace Application.Features.Cars.Commands.DeleteCars
{
    public class DeleteCarCommand : IRequest<NoContent>
    {
        public int Id { get; set; }
      
        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, NoContent>
        {
            ICarRepository _carRepository;
         

            public DeleteCarCommandHandler(ICarRepository carRepository)
            {
                _carRepository = carRepository;
              
            }

            public async Task<NoContent> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                var carToDelete = await _carRepository.GetAsync(x => x.Id == request.Id);
                if (carToDelete == null)
                    throw new BusinessException("Car cannot found");

                
                await _carRepository.DeleteAsync(carToDelete);
              
                return new NoContent();
            }
        }
    }

}
