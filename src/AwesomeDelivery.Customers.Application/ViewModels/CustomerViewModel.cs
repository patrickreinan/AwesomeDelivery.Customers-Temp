using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeDelivery.Customers.Core.ValueObjects;

namespace AwesomeDelivery.Customers.Application.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(string fullName, string document, DateTime birthDate)
        {
            FullName = fullName;
            Document = document;
            BirthDate = birthDate;
        }

        public string FullName { get; private set; }
        public string Document { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<DeliveryAddressViewModel> Addresses { get; private set; }
        public List<PaymentMethodViewModel> PaymentMethods { get; private set; }

        public CustomerViewModel AddressesFromEntities(List<DeliveryAddress> addresses) {
            
            Addresses = addresses != null ? 
                addresses
                    .Select(a => new DeliveryAddressViewModel(a.Street, a.Number, a.City, a.State, a.ZipCode))
                    .ToList() :
                new List<DeliveryAddressViewModel>();

            return this;
        }

        public CustomerViewModel PaymentMethodsFromEntities(List<PaymentMethod> paymentMethods) {
            PaymentMethods = paymentMethods != null ? 
                paymentMethods
                    .Select(pm => new PaymentMethodViewModel(pm.CardNumber, pm.FullName, pm.ExpirationDate, pm.CardNumber))
                    .ToList() :
                new List<PaymentMethodViewModel>();

            return this;
        }
    }

    public class DeliveryAddressViewModel {
        public DeliveryAddressViewModel(string street, string number, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }     
    }

    public class PaymentMethodViewModel {
        public PaymentMethodViewModel(string cardNumber, string fullName, string expirationDate, string cvv)
        {
            CardNumber = cardNumber;
            FullName = fullName;
            ExpirationDate = expirationDate;
            Cvv = cvv;
        }

        public string CardNumber { get; private set; }
        public string FullName { get; private set; }
        public string ExpirationDate { get; private set; }
        public string Cvv { get; private set; }
    }
}