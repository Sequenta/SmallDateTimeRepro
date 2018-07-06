using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repro
{
    public class TestContext : DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TestEntity>().Property(x => x.SmallDate).HasColumnType("smalldatetime");

            builder.Entity<TestEntity>().HasData(
                new TestEntity { Id = new Guid("61242D0B-DDCF-46A2-B853-F50A30ECE25B"), SmallDate = DateTime.UtcNow }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Repro;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }

    public class TestEntity
    {
        public Guid Id { get; set; }
        public DateTime? SmallDate { get; set; }
    }
}