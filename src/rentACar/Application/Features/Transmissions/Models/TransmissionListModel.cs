using Application.Features.Fuels.Dtos;
using Application.Features.Transmissions.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Models
{
    public class TransmissionListModel : BasePageableModel
    {
        public IList<TransmissionListDto> Items { get; set; }
    }
}
