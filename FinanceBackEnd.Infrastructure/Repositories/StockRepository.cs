using FinanceBackEnd.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace FinanceBackEnd.Infrastructure.Repositories 
{
    public class StockRepository : BaseRepository<Stock>
    {
        public StockRepository(DataContext context) : base(context)
        {
        }

        public static void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder
                .Entity<Stock>()
                .ToTable("Stocks");

            modelBuilder
                .Entity<Stock>()
                .HasKey(s => s.Id)
                .HasName("PK_STOCKS");

            modelBuilder
                .Entity<Stock>()
                .Property(s => s.Id)
                .HasColumnType("int")
                .UseMySqlIdentityColumn()
                .IsRequired();
            
            modelBuilder
                .Entity<Stock>()
                .Property(s => s.Code)
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder
                .Entity<Stock>()
                .Property(s => s.Description)
                .HasColumnType("varchar(50)");
        }
    }
}