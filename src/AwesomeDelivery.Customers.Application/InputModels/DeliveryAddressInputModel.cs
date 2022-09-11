using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Customers.Application.InputModels
{
    public class DeliveryAddressInputModel
    {
        public List<DeliveryAddressItemInputModel> Items { get; set; }
    }

    public class DeliveryAddressItemInputModel {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}