using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Customers.Core.Events
{
    public class CustomerRegistered : IDomainEvent
    {
        public CustomerRegistered(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
    }
}