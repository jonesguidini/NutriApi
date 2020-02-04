using Nutrivida.Domain.EntitiesConfig;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nutrivida.Domain.Contracts.Managers
{
    public interface INotificationManager
    {
        bool IsValid();
        List<Notification> GetNotifications();
        Task Handle(Notification notification);
    }
}
