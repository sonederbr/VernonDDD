using System;
using ManageMainEvents.Domain.Model.MainEvents;
using ManageMainEvents.Infrastructure.Context;
using ManageMainEvents.Domain.Model.MainEvents.Repository;

namespace ManageMainEvents.Infrastructure.Repository
{
    public class MainEventRepository : Repository<MainEvent, Guid>, IMainEventRepository
    {
        public MainEventRepository(PlataformMainEventContext context) : base(context)
        {
        }
    }
}
