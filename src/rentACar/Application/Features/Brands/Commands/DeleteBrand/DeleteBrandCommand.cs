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


namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<NoContent>
    {
        public int Id { get; set; }
      
        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, NoContent>
        {
            IBrandRepository _brandRepository;
         

            public DeleteBrandCommandHandler(IBrandRepository brandRepository)
            {
                _brandRepository = brandRepository;
              
            }

            public async Task<NoContent> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                var brandToDelete = await _brandRepository.GetAsync(x => x.Id == request.Id);
                if (brandToDelete == null)
                    throw new BusinessException("Brand cannot found");

                
                await _brandRepository.DeleteAsync(brandToDelete);
              
                return new NoContent();
            }
        }
    }

}
