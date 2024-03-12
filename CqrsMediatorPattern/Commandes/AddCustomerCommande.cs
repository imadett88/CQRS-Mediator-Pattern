using MediatR;

namespace CqrsMediatorPattern.Commandes
{
    public record AddCustomerCommande(Customer Customer) : IRequest<Customer>;
  
}
