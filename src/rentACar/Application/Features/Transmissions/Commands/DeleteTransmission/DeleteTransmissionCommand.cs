
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


namespace Application.Features.Transmissions.Commands.DeleteTransmission
{
    public class DeleteTransmissionCommand : IRequest<NoContent>
    {
        public int Id { get; set; }
      
        public class DeleteTransmissionCommandHandler : IRequestHandler<DeleteTransmissionCommand, NoContent>
        {
            ITransmissionRepository _transmissionRepository;
         

            public DeleteTransmissionCommandHandler(ITransmissionRepository transmissionRepository)
            {
                _transmissionRepository = transmissionRepository;
              
            }

            public async Task<NoContent> Handle(DeleteTransmissionCommand request, CancellationToken cancellationToken)
            {
                var transmissionToDelete = await _transmissionRepository.GetAsync(x => x.Id == request.Id);
                if (transmissionToDelete == null)
                    throw new BusinessException("Transmission cannot found");


                await _transmissionRepository.DeleteAsync(transmissionToDelete);
              
                return new NoContent();
            }
        }
    }

}
