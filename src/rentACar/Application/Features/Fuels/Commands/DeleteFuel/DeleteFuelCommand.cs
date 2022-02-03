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


namespace Application.Features.Fuels.Commands.DeleteFuel
{
    public class DeleteFuelCommand : IRequest<NoContent>
    {
        public int Id { get; set; }
      
        public class DeleteFuelCommandHandler : IRequestHandler<DeleteFuelCommand, NoContent>
        {
            IFuelRepository _fuelRepository;
         

            public DeleteFuelCommandHandler(IFuelRepository fuelRepository)
            {
                _fuelRepository = fuelRepository;
              
            }

            public async Task<NoContent> Handle(DeleteFuelCommand request, CancellationToken cancellationToken)
            {
                var fuelToDelete = await _fuelRepository.GetAsync(x => x.Id == request.Id);
                if (fuelToDelete == null)
                    throw new BusinessException("Fuel cannot found");


                await _fuelRepository.DeleteAsync(fuelToDelete);
              
                return new NoContent();
            }
        }
    }

}
