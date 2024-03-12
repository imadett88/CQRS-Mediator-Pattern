using CqrsMediatorPattern.Notification;
using MediatR;

namespace CqrsMediatorPattern.Handlers
{
    public class EmailHandler : INotificationHandler<CustomerAddNotification>
    {

        private readonly FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task Handle(CustomerAddNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Customer, "Email sent");
            await Task.CompletedTask;
        }
    }
}
