using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Customers.Core.ValueObjects
{
    public record PaymentMethod(string CardNumber, string FullName, string ExpirationDate, string Cvv);
}