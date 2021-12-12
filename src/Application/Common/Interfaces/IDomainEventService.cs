using WMS.Domain.Common;
using System.Threading.Tasks;

namespace WMS.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
