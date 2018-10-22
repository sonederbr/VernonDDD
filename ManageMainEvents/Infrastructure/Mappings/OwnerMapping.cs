using System;
using ManageMainEvents.Domain.Model.Owners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManageMainEvents.Infrastructure.Mappings
{
    public class OwnerMapping : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            throw new NotImplementedException();
        }
    }
}
