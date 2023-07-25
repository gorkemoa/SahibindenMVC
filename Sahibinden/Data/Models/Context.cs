using System;
using Microsoft.EntityFrameworkCore;

namespace Sahibinden.Data.Models
{
  
    public class Context: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=postgres; User ID=postgres; Password=1234; Pooling=true;");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<Departmanlar>()
            //.HasKey(hk => new { hk.Id });

            //builder.Entity<Departmanlar>().Property(p => p.Id).ValueGeneratedOnAdd();

            //builder.Entity<Personel>()
            //.HasKey(hk => new { hk.Id });
            //builder.Entity<Personel>().Property(p => p.Id).ValueGeneratedOnAdd();


            //builder.Entity<Personel>()
            //.HasOne<Departmanlar>(s => s.Depart)
            //.WithMany(g => g.Personels)
            //.HasForeignKey(s => s.DepartId);


            base.OnModelCreating(builder);
        }
    }
}

