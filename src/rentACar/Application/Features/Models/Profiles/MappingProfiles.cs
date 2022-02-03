using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Models.Commands;
using Application.Features.Models.Commands.CreateModel;
using Application.Features.Models.Commands.DeleteModel;
using Application.Features.Models.Commands.UpdateModel;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, DeleteModelCommand>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, ModelListDto>().ReverseMap();
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();

        }

    }
}
