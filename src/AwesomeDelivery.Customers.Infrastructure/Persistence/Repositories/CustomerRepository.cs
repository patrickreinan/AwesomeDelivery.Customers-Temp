using AwesomeDelivery.Customers.Core.Entities;
using AwesomeDelivery.Customers.Core.Repositories;
using AwesomeDelivery.Customers.Core.ValueObjects;
using MongoDB.Driver;

namespace AwesomeDelivery.Customers.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _collection;

        public CustomerRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Customer>("customers");
        }

        public async Task AddAsync(Customer customer)
        {
            await _collection.InsertOneAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _collection.Find(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAddressesAsync(Guid id, List<DeliveryAddress> addresses)
        {
            await _collection.FindOneAndUpdateAsync(
                f => f.Id == id,
                Builders<Customer>.Update
                    .Set(f => f.Addresses, addresses)
            );
        }

        public async Task UpdatePaymentMethodsAsync(Guid id, List<PaymentMethod> paymentMethods)
        {
            await _collection.FindOneAndUpdateAsync(
                f => f.Id == id,
                Builders<Customer>.Update
                    .Set(f => f.PaymentMethods, paymentMethods)
            );
        }
    }
}