using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Colors.Commands.CreateColor;
using Application.Features.Colors.Commands.DeleteColors;
using Application.Features.Colors.Commands.UpdateColors;
using Application.Features.Colors.Dtos;
using Application.Features.Colors.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colors.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            
            CreateMap<Color, UpdateColorCommand>().ReverseMap();
            CreateMap<Color, DeleteColorCommand>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Color, CreateColorCommand>().ReverseMap();
            CreateMap<Color, ColorListDto>().ReverseMap();
            CreateMap<IPaginate<Color>, ColorListModel>().ReverseMap();
        }
        
    }
}
