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
    public class CommentsConfiguration : BaseConfiguration<Comments, int>
    {
        public override void Configure(EntityTypeBuilder<Comments> builder)
        {
            base.Configure(builder);
            builder.Property(c => c.Header).IsRequired();
            builder.Property(c => c.Content).IsRequired();
            builder
                .HasMany(e => e.UserComments)
                .WithOne(ue => ue.Comments)
                .HasForeignKey(ue => ue.CommentId);
        }
    }
}
