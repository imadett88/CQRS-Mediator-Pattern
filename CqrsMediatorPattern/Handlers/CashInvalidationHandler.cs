using CqrsMediatorPattern.Notification;
using MediatR;

namespace CqrsMediatorPattern.Handlers
{
    public class CashInvalidationHandler : INotificationHandler<CustomerAddNotification>
    {

        private readonly FakeDataStore _fakeDataStore;

        public CashInvalidationHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task Handle(CustomerAddNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Customer, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
