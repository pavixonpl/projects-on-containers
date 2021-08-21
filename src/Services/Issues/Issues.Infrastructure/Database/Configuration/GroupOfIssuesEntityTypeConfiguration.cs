﻿using Issues.Domain.GroupsOfIssues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Issues.Infrastructure.Database.Configuration
{
    public class GroupOfIssuesEntityTypeConfiguration : IEntityTypeConfiguration<GroupOfIssues>
    {
        public void Configure(EntityTypeBuilder<GroupOfIssues> builder)
        {
            builder.Property(d => d.Id).IsRequired().HasMaxLength(63);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(1023);
            builder.Property(d => d.TypeOfGroupId).IsRequired().HasMaxLength(63);
            builder.Property(d => d.StatusFlowId).IsRequired().HasMaxLength(63);
            builder.Property(d => d.OrganizationId).IsRequired().HasMaxLength(63);
            builder.Property(d => d.IsArchived).IsRequired();
            builder.HasMany(d => d.Issues).WithOne(s => s.GroupOfIssue);
            builder.HasOne(d => d.Flow).WithMany().HasForeignKey(s => s.StatusFlowId);
        }
    }
}