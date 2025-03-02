using Microsoft.EntityFrameworkCore;
using UITraining.Models.DB;

namespace UITraining.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }



        public  virtual DbSet<Produk> produks { get; set; }
        public  virtual DbSet<supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produk>()
                 .HasOne(p => p.Supplier) //produk memiliki satu supllier
                 .WithMany(s => s.Produk) //suppliee memiliki banyak produk
                 .HasForeignKey(p => p.IdSupplier); //Id supplier sebagai FK
            //.OnDelete(DeleteBehavior.Cascade);
                

            base.OnModelCreating(modelBuilder);
        }

    }
}
