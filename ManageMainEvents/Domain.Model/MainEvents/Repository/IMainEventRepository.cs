using System;
using Common.Domain.Core.Data;
namespace ManageMainEvents.Domain.Model.MainEvents.Repository
{
    public interface IMainEventRepository : IRepository<MainEvent, Guid>
    {
    }
}
