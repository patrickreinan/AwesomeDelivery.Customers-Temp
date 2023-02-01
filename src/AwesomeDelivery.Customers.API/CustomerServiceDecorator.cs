using System;
using AwesomeDelivery.Customers.Application.InputModels;
using AwesomeDelivery.Customers.Application.Services;
using AwesomeDelivery.Customers.Application.ViewModels;

namespace AwesomeDelivery.Customers.API
{
	public class CustomerServiceDecorator  : ICustomerService
	{
        private readonly CustomerService service;
        private readonly ILogger<CustomerServiceDecorator> logger;

        public CustomerServiceDecorator(CustomerService service, ILogger<CustomerServiceDecorator> logger)
		{
            this.service = service;
            this.logger = logger;
        }

        public async Task<Guid> Add(CustomerInputModel model)
        {
            logger.LogInformation("Adding customer");         
            var id= await service.Add(model);
            logger.LogInformation($"Customer added {id}");
            return id;

        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            logger.LogInformation($"Getting customer {id}");
            var customer = await service.GetById(id);

            if (customer != null)
            
                logger.LogInformation($"Customer {id} found");

            
            else
            
                logger.LogInformation($"Customer {id} not found");
                
            
            
                return customer!;
        }

        public Task UpdateAddresses(Guid id, DeliveryAddressInputModel model)
        {
            return service.UpdateAddresses(id, model);
        }

        public Task UpdatePaymentMethods(Guid id, PaymentMethodInputModel model)
        {
            return service.UpdatePaymentMethods(id, model);
        }
    }
}

