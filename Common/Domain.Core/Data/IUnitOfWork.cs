using System;
using Common.Domain.Core.Commands;

namespace Common.Domain.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
