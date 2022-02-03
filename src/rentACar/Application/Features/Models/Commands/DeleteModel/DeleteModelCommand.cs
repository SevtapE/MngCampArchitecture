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

namespace Application.Features.Models.Commands.DeleteModel
{
    public class DeleteModelCommand:IRequest<NoContent>
    {
        public int Id { get; set; }
        public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, NoContent>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<NoContent> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
            {
                var modelToDelete = await _modelRepository.GetAsync(x => x.Id == request.Id);
                if (modelToDelete == null) throw new BusinessException("Model not found");

                await _modelRepository.DeleteAsync(modelToDelete);
                return new NoContent();

                
            }
        }
    }
}
