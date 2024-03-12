using MediatR;

namespace CqrsMediatorPattern.Queries
{
    public record GetCustomerByIdQuery(int Id) : IRequest<Customer>;
   
}
