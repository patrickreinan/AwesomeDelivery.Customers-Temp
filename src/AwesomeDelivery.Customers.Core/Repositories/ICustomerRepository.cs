using AwesomeDelivery.Customers.Core.Entities;
using AwesomeDelivery.Customers.Core.ValueObjects;

namespace AwesomeDelivery.Customers.Core.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task UpdateAddressesAsync(Guid id, List<DeliveryAddress> addresses);
        Task UpdatePaymentMethodsAsync(Guid id, List<PaymentMethod> paymentMethods);
        Task<Customer> GetByIdAsync(Guid id);
    }
}