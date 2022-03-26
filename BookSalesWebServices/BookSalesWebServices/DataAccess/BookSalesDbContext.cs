using BookSalesWebServices.DataAccess.EntityModel;
using Microsoft.EntityFrameworkCore;

namespace BookSalesWebServices.DataAccess
{
    public class BookSalesDbContext : DbContext
    {
        public BookSalesDbContext(DbContextOptions<BookSalesDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


        public DbSet<KullaniciEntityModel> KullaniciDbSet { get; set; }
        public DbSet<UrunEntityModel> UrunDbSet { get; set; }
        public DbSet<SiparisEntityModel> SiparisDbSet { get; set; }
        public DbSet<SiparisDetayEntityModel> SiparisDetayDbSet { get; set; }
        public DbSet<StokEntityModel> StokDetayDbSet { get; set; }

    }

}
