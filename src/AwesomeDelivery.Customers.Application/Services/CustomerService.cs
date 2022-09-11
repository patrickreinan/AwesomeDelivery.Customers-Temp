using AwesomeDelivery.Customers.Application.InputModels;
using AwesomeDelivery.Customers.Application.ViewModels;
using AwesomeDelivery.Customers.Core.Entities;
using AwesomeDelivery.Customers.Core.Repositories;
using AwesomeDelivery.Customers.Core.ValueObjects;

namespace AwesomeDelivery.Customers.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Add(CustomerInputModel model)
        {
            var customer = new Customer(model.FullName, model.Document, model.Email, model.BirthDate);

            await _repository.AddAsync(customer);

            return customer.Id;
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            var customer = await _repository.GetByIdAsync(id);


            return new CustomerViewModel(customer.FullName, customer.Document, customer.BirthDate)
                .AddressesFromEntities(customer.Addresses)
                .PaymentMethodsFromEntities(customer.PaymentMethods);
        }

        public async Task UpdateAddresses(Guid id, DeliveryAddressInputModel model)
        {
            var addresses = model
                .Items
                .Select(m => new DeliveryAddress(m.Street, m.Number, m.City, m.State, m.ZipCode))
                .ToList();

            await _repository.UpdateAddressesAsync(id, addresses);
        }

        public async Task UpdatePaymentMethods(Guid id, PaymentMethodInputModel model)
        {
            var paymentMethods = model
                .Items
                .Select(m => new PaymentMethod(m.CardNumber, m.FullName, m.ExpirationDate, m.Cvv))
                .ToList();

            await _repository.UpdatePaymentMethodsAsync(id, paymentMethods);
        }
    }
}