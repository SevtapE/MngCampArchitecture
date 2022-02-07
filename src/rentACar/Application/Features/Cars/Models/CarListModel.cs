using Application.Features.Brands.Dtos;
using Application.Features.Cars.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Models
{
    public class CarListModel:BasePageableModel
    {
        public IList<CarListDto> Items { get; set; }
    }
}
