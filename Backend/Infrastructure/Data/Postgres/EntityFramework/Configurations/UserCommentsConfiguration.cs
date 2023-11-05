using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.EntityFramework.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Postgres.EntityFramework.Configurations
{
    public class UserCommentsConfiguration : IEntityTypeConfiguration<UserComment>
    {
        public void Configure(EntityTypeBuilder<UserComment> builder)
        {
            builder.HasKey(a => a.UserCommentID);
            builder.Property(a => a.UserCommentID).ValueGeneratedOnAdd();
            builder.Property(a => a.UserId);
            builder.Property(a => a.CommentId);
        }
    }
}
