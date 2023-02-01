using AwesomeDelivery.Customers.Application.InputModels;
using AwesomeDelivery.Customers.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeDelivery.Customers.API.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            var customer = await _customerService.GetById(id);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomerInputModel model) {
            var id = await _customerService.Add(model);
            
            return CreatedAtAction(
                nameof(GetById),
                new { id },
                model
            );
        }

        [HttpPut("{id}/addresses")]
        public async Task<IActionResult> PutAddresses(Guid id, DeliveryAddressInputModel model) {
            await _customerService.UpdateAddresses(id, model);

            return NoContent();
        }

        [HttpPut("{id}/payment-methods")]
        public async Task<IActionResult> PutPaymentMethods(Guid id, PaymentMethodInputModel model) {
            await _customerService.UpdatePaymentMethods(id, model);
            
            return NoContent();
        }
    }
}