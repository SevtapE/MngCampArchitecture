using Application.Features.CorporateCustomers.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Models
{
    public class CorporateCustomerListModel : BasePageableModel
    {
        public IList<CorporateCustomerListDto> Items { get; set; }
    }
}
