using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Rules;
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


namespace Application.Features.Colors.Commands.UpdateColors
{
    public class UpdateColorCommand : IRequest<ColorDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommand, ColorDto>
        {
            IColorRepository _colorRepository;
            IMapper _mapper;
            ColorBusinessRules _colorBusinessRules;

            public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper, ColorBusinessRules colorBusinessRules)
            {
                _colorRepository = colorRepository;
                _mapper = mapper;
                _colorBusinessRules = colorBusinessRules;
            }

            public async Task<ColorDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
            {
                var colorToUpdate = await _colorRepository.GetAsync(x => x.Id == request.Id);
                if (colorToUpdate == null)
                    throw new BusinessException("Color cannot found");


                await _colorBusinessRules.ColorNameCanNotBeDuplicatedWhenInsertedAndUpdated(request.Name);
                 _mapper.Map(request, colorToUpdate);

                 await _colorRepository.UpdateAsync(colorToUpdate);

                var updatedColor = _mapper.Map<ColorDto>(colorToUpdate);

                return updatedColor;
            }
        }
    }

}
