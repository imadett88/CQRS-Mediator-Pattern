using CqrsMediatorPattern.Commandes;
using CqrsMediatorPattern.Notification;
using CqrsMediatorPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatorPattern.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;


        public CustomerController(ISender sender, IPublisher publisher)
        {
            _publisher = publisher;
            _sender = sender;
        }
        // another format to write the constructor :
        // public CustomerController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var products = await _sender.Send(new GetCustomersQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}",Name = "GetCustomerById")]
        public async Task<ActionResult> GetCustomerById(int id)
        {
            var customer = await _sender.Send(new GetCustomerByIdQuery(id));

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody] Customer customer)
        {
            var customerToReturn = await _sender.Send(new AddCustomerCommande(customer));

            await _publisher.Publish(new CustomerAddNotification(customerToReturn));

            return CreatedAtRoute("GetCustomerById", new { id = customerToReturn.ID }, customerToReturn);
        }


    }
}
