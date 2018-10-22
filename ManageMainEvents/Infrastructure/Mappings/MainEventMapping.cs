using System;
using Microsoft.EntityFrameworkCore;
using ManageMainEvents.Domain.Model.MainEvents;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageMainEvents.Infrastructure.Mappings
{
    public class MainEventMapping : IEntityTypeConfiguration<MainEvent>
    {
        public void Configure(EntityTypeBuilder<MainEvent> builder)
        {
            throw new NotImplementedException();
        }
    }
}
