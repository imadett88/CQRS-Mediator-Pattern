using CqrsMediatorPattern.Queries;
using MediatR;

namespace CqrsMediatorPattern.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetCustomerHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
           return await _fakeDataStore.GetAllCustomers();
        }
    }
}
