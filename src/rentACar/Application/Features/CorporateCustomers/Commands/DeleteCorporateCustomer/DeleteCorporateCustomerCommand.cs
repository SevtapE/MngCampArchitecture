using Application.Services.Repositories;
using Core.Application;
using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Commands.DeleteCorporateCustomer
{
    public class DeleteCorporateCustomerCommand : IRequest<NoContent>
    {
        public int Id { get; set; }
        public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, NoContent>
        {
            ICorporateCustomerRepository _corporateCustomerRepository;

            public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository individualCustomerRepository)
            {
                _corporateCustomerRepository = individualCustomerRepository;
            }

            public async Task<NoContent> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
            {
               var corporateCustomerToDelete = await _corporateCustomerRepository.GetAsync(c => c.Id == request.Id);
                if (corporateCustomerToDelete == null) throw new BusinessException("Customer can not be found");

               await _corporateCustomerRepository.DeleteAsync(corporateCustomerToDelete);

                return new NoContent();
            }
        }
    }
}
