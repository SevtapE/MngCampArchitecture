using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Fuels.Commands.CreateFuel;
using Application.Features.Fuels.Commands.DeleteFuel;
using Application.Features.Fuels.Commands.UpdateFuel;
using Application.Features.Fuels.Dtos;
using Application.Features.Fuels.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
            CreateMap<Fuel, FuelListDto>().ReverseMap();
            CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
            CreateMap<Fuel, DeleteFuelCommand>().ReverseMap();
            CreateMap<Fuel, FuelDto>().ReverseMap();
            CreateMap<IPaginate<Fuel>, FuelListModel>().ReverseMap();
        }

    }
}
