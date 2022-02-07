using Application.Features.Brands.Models;
using Application.Features.Fuels.Models;
using Application.Features.Transmissions.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Queries.GetTransmissionList
{
    public class GetTransmissionListQuery : IRequest<TransmissionListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetTransmissionListQueryHandler : IRequestHandler<GetTransmissionListQuery, TransmissionListModel>
        {
            ITransmissionRepository _transmissionRepository;
            IMapper _mapper;
            public GetTransmissionListQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<TransmissionListModel> Handle(GetTransmissionListQuery request, CancellationToken cancellationToken)
            {
                var transmissions = await _transmissionRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedTransmissions = _mapper.Map<TransmissionListModel>(transmissions);
                return mappedTransmissions;
            }
        }
    }
}
