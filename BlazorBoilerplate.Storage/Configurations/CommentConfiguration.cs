using BlazorBoilerplate.Shared.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorBoilerplate.Storage.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(g => g.UserName)
                .IsRequired();

            builder.Property(g => g.Text)
                .IsRequired();

            builder.HasOne(a => a.Sender)
                .WithMany(m => m.Comments)
                .HasForeignKey(u => u.UserID);
        }
    }
}
