using MediatR;

namespace CqrsMediatorPattern.Notification
{
    public record CustomerAddNotification(Customer Customer) : INotification;
    
}
