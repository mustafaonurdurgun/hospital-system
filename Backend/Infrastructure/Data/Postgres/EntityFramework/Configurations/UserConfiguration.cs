using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations;

public class UserConfiguration : BaseConfiguration<User,int>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(u => u.FirstName).IsRequired();
        builder.Property(u => u.LastName).IsRequired();
        builder.Property(u => u.Age).IsRequired();
        builder.Property(u => u.PasswordSalt).IsRequired();
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.UserType).IsRequired();
        builder.HasMany(u => u.Prescriptions)
           .WithOne(p => p.User)
           .HasForeignKey(p => p.userID);

        builder.HasMany(u => u.Appointments)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.userID);
       

        builder.HasMany(u => u.UserComments)
            .WithOne(uc => uc.User)
            .HasForeignKey(uc => uc.UserId);
    }

  
}

   