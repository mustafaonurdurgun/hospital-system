using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    public class PrescriptionsConfiguration : BaseConfiguration<Prescriptions, int>
    {
        public override void Configure(EntityTypeBuilder<Prescriptions> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Medication).IsRequired();
            builder.Property(p => p.Instructions).IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Prescriptions)
                .HasForeignKey(p => p.userID);
        }
    }
}
