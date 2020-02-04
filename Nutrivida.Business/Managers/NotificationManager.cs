using Nutrivida.Domain.Contracts.Managers;
using Nutrivida.Domain.EntitiesConfig;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nutrivida.Business.Managers
{
    public class NotificationManager : INotificationManager
    {
        private List<Notification> notifications;

        public NotificationManager()
        {
            notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return notifications;
        }

        public Task Handle(Notification notification)
        {
            notifications.Add(notification);
            return Task.CompletedTask;
        }

        public bool IsValid()
        {
            return !notifications.Any();
        }
    }
}
