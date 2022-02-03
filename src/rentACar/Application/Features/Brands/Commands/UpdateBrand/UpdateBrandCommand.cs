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


namespace Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<BrandDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandDto>
        {
            IBrandRepository _brandRepository;
            IMapper _mapper;
            BrandBusinessRules _brandBusinessRules;

            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<BrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                var brandToUpdate = await _brandRepository.GetAsync(x => x.Id == request.Id);
                if (brandToUpdate == null)
                    throw new BusinessException("Brand cannot found");


                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);
                 _mapper.Map(request,brandToUpdate);

                 await _brandRepository.UpdateAsync(brandToUpdate);

                var dto = _mapper.Map<BrandDto>(brandToUpdate);

                return dto;
            }
        }
    }

}
