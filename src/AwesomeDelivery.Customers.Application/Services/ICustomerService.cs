using AwesomeDelivery.Customers.Application.InputModels;
using AwesomeDelivery.Customers.Application.ViewModels;

namespace AwesomeDelivery.Customers.Application.Services
{
    public interface ICustomerService
    {
        Task<Guid> Add(CustomerInputModel model);
        Task UpdateAddresses(Guid id, DeliveryAddressInputModel model);
        Task UpdatePaymentMethods(Guid id, PaymentMethodInputModel model);
        Task<CustomerViewModel> GetById(Guid id);
    }
}