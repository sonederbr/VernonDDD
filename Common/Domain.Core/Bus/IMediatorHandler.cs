using System.Threading.Tasks;
using Common.Domain.Core.Commands;
using Common.Domain.Core.Events;

namespace Common.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
