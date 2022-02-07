using Application.Services.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands
{
    public class DeleteIndividualCustomerCommand:IRequest<NoContent>
    {
        public int Id { get; set; }
        public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, NoContent>
        {
            IIndividualCustomerRepository _individualCustomerRepository;

            public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository)
            {
                _individualCustomerRepository = individualCustomerRepository;
            }

            public async Task<NoContent> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
               var individualCustomerToDelete= await _individualCustomerRepository.GetAsync(c => c.Id == request.Id);
                if (individualCustomerToDelete == null) throw new BusinessException("Customer can not be found");

               await _individualCustomerRepository.DeleteAsync(individualCustomerToDelete);

                return new NoContent();
            }
        }
    }
}
