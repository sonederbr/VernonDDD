using System;
using ManageMainEvents.Domain.Model.Owners;
using ManageMainEvents.Domain.Model.Owners.Repository;
using ManageMainEvents.Infrastructure.Context;

namespace ManageMainEvents.Infrastructure.Repository
{
    public class OwnerRepository : Repository<Owner, Guid>, IOwnerRepository
    {
        public OwnerRepository(PlataformMainEventContext context) : base(context)
        {
        }
    }
}
