using CqrsMediatorPattern.Commandes;
using MediatR;

namespace CqrsMediatorPattern.Handlers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommande, Customer>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddCustomerHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Customer> Handle(AddCustomerCommande request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddCustomer(request.Customer);

            return request.Customer;
        }
    }
}
