using Application.Features.IndividualCustomers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Models
{
    public class IndividualCustomerListModel
    {
        public IList<IndividualCustomerListDto> Items { get; set; }
    }
}
