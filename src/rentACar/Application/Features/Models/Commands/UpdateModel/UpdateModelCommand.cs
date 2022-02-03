using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.UpdateModel
{
    public class UpdateModelCommand:IRequest<ModelDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public int TransmissionId { get; set; }
        public int FuelId { get; set; }
        public int BrandId { get; set; }
        public string ImageUrl { get; set; }
        public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, ModelDto>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;
            ModelBusinessRules _modelBusinessRules;

            public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
                _modelBusinessRules = modelBusinessRules;
            }

            public async Task<ModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
            {
                var modelToUpdate = await _modelRepository.GetAsync(x => x.Id == request.Id);
                if (modelToUpdate == null) throw new BusinessException("Model not found");

                _mapper.Map(request, modelToUpdate);

                 await _modelRepository.UpdateAsync(modelToUpdate);
               var updatedModel= _mapper.Map<ModelDto>(modelToUpdate);
                return updatedModel;

            }
        }
    }
}
