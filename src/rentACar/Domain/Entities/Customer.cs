using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Abstract
{
    public class Customer:Entity
    {
        public string Email { get; set; }

        public Customer(int id,string email):this()
        {
            Email = email;
            Id = id;
        }

        public Customer()
        {
        }
    }
}
