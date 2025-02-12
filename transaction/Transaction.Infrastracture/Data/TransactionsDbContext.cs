using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionMS.Domain.Entities;

namespace TransactionMS.Infrastracture.Data
{
        public class TransactionsDbContext : DbContext
        {
            public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options) : base(options)
            {
            }

            public DbSet<TransactionEN> Transaction { get; set; }
            public DbSet<RequestEN> Request { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
            modelBuilder.AddOutboxStateEntity();
            modelBuilder.Entity<TransactionEN>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<RequestEN>()
                .HasMany(tr => tr.Transaction)
                .WithOne(t => t.Request)
                .HasForeignKey(ri=>ri.RequestId);

        }
    }


}