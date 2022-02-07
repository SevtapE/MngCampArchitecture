using Application.Features.IndividualCustomers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Queries
{
    public class GetIndividualCustomerListQuery:IRequest<IndividualCustomerListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetIndividualCustomerListQueryHandler : IRequestHandler<GetIndividualCustomerListQuery, IndividualCustomerListModel>
        {
            IIndividualCustomerRepository _individualCustomerRepository;
            IMapper _mapper;

            public GetIndividualCustomerListQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
            {
                _individualCustomerRepository = individualCustomerRepository;
                _mapper = mapper;
            }

            public async Task<IndividualCustomerListModel> Handle(GetIndividualCustomerListQuery request, CancellationToken cancellationToken)
            {
                var individualCustomers = await _individualCustomerRepository.GetListAsync(
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize
                   );
               var mappedIndividualCustomers= _mapper.Map<IndividualCustomerListModel>(individualCustomers);
                return mappedIndividualCustomers;

            }
        }
    }
}
