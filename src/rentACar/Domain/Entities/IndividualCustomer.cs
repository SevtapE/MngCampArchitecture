using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IndividualCustomer:Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NatianalId { get; set; }

        public IndividualCustomer(int id, string email,string firstName, string lastName, string natianalId):this()
        {
            FirstName = firstName;
            LastName = lastName;
            NatianalId = natianalId;
            Id = id;
            Email = email;
        }

        public IndividualCustomer()
        {
        }
    }
}
