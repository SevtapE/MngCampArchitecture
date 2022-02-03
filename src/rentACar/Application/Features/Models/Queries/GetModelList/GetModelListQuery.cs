using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetModelList
{
    public class GetModelListQuery:IRequest<ModelListModel>
    {
       public PageRequest pageRequest;

        public class GetListQueryHandler : IRequestHandler<GetModelListQuery, ModelListModel>
        {
            IModelRepository _modelRepository;
            IMapper _mapper;

            public GetListQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetModelListQuery request, CancellationToken cancellationToken)
            {
                var models = await _modelRepository.GetListAsync( index:request.pageRequest.Page, size: request.pageRequest.PageSize);

               var mappedModels= _mapper.Map<ModelListModel>(models);

                return mappedModels;



            }
        }
    }
}
