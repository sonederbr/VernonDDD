using Common.Domain.Core.Commands;
using Common.Domain.Core.Data;
using ManageMainEvents.Infrastructure.Context;

namespace ManageMainEvents.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly PlataformMainEventContext _context;

        public UnitOfWork(PlataformMainEventContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
