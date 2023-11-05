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
    public class AppointmentConfiguration : BaseConfiguration<Appointment, int>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);
            builder.Property(a => a.AppointmentDate).IsRequired();
            builder.Property(a => a.Reason).IsRequired();
            builder.Property(a => a.IsConfirmed).IsRequired();

            builder.HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.userID);
        }
    }
}
