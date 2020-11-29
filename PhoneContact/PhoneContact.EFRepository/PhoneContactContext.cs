using Microsoft.EntityFrameworkCore;
using PhoneContact.Domain.Entities;
using PhoneContact.Domain.Repositories;
using PhoneContact.EFRepository.SchemaDefinitions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneContact.EFRepository
{
    public class PhoneContactContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "PHC";
        public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Genre> Genres { get; set; }
        public PhoneContactContext(DbContextOptions<PhoneContactContext> options) :
        base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactEntitySchemaConfiguration());
            //modelBuilder.ApplyConfiguration(new GenreEntitySchemaConfiguration());
            //modelBuilder.ApplyConfiguration(new AuthorEntitySchemaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
