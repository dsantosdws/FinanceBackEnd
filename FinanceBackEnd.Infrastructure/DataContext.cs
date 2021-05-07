using Microsoft.EntityFrameworkCore;

namespace FinanceBackEnd.Infrastructure.Repositories 
{   
    public class DataContext : TryInvestContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            StockRepository.OnModelCreating(modelBuilder);
            DividendRepository.OnModelCreating(modelBuilder);
        }
    }
}