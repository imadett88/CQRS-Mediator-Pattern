using CqrsMediatorPattern.Queries;
using MediatR;

namespace CqrsMediatorPattern.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {

        private readonly FakeDataStore _fakeDataStore;

        public GetCustomerByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetCustomerById(request.Id);
        }
    }
}
