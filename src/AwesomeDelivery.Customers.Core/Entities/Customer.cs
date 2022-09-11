using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDelivery.Customers.Core.Events;
using AwesomeDelivery.Customers.Core.ValueObjects;

namespace AwesomeDelivery.Customers.Core.Entities
{
    public class Customer : AggregateRoot
    {
        public Customer(string fullName, string document, string email, DateTime birthDate)
            : base()
        {
            FullName = fullName;
            Document = document;
            Email = email;
            BirthDate = birthDate;

            AddEvent(new CustomerRegistered(Id, Email));
        }

        public Customer(string fullName, string document, string email, DateTime birthDate, List<DeliveryAddress> addresses, List<PaymentMethod> paymentMethods)
            : base()
        {
            FullName = fullName;
            Document = document;
            Email = email;
            BirthDate = birthDate;
            Addresses = addresses;
            PaymentMethods = paymentMethods;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<DeliveryAddress> Addresses { get; private set; }
        public List<PaymentMethod> PaymentMethods { get; private set; }
    }
}