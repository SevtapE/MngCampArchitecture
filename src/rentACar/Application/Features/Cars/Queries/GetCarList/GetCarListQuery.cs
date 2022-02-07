using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetBrandList;
using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetBrandList
{
    public class GetCarListQuery:IRequest<CarListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetCarListQueryHandler : IRequestHandler<GetCarListQuery, CarListModel>
        {
            ICarRepository _carRepository;
            IMapper _mapper;
            public GetCarListQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                _carRepository=carRepository;
                _mapper = mapper;
            }

            public async Task<CarListModel> Handle(GetCarListQuery request, CancellationToken cancellationToken)
            {
                var cars = await _carRepository.GetListAsync(
                    predicate:c=>c.CarState!=Domain.Enums.CarState.Maintenance,
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize
                    );
                var mappedCars=_mapper.Map<CarListModel>(cars);   
                return mappedCars;
            }
        }
    }
}
