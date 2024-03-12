using MediatR;

namespace CqrsMediatorPattern.Queries
{
    public record GetCustomersQuery : IRequest<IEnumerable<Customer>>;
    
}
