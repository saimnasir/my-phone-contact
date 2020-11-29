using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneContact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneContact.EFRepository.SchemaDefinitions
{
    public class ContactEntitySchemaConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact", PhoneContactContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(p => p.UIID).IsRequired();
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.UpdateDate);
            builder.Property(p => p.IsDeleted);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.MiddleName).HasMaxLength(200);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.CompanyName).IsRequired().HasMaxLength(200);
        }
    }
}
