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


namespace Application.Features.Colors.Commands.DeleteColors
{
    public class DeleteColorCommand : IRequest<NoContent>
    {
        public int Id { get; set; }
      
        public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommand, NoContent>
        {
            IColorRepository _colorRepository;
         

            public DeleteColorCommandHandler(IColorRepository colorRepository)
            {
                _colorRepository = colorRepository;
              
            }

            public async Task<NoContent> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
            {
                var colorToDelete = await _colorRepository.GetAsync(x => x.Id == request.Id);
                if (colorToDelete == null)
                    throw new BusinessException("Color cannot found");

                
                await _colorRepository.DeleteAsync(colorToDelete);
              
                return new NoContent();
            }
        }
    }

}
