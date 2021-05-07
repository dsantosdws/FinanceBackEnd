using FinanceBackEnd.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace FinanceBackEnd.Infrastructure.Repositories
{
    public class DividendRepository : BaseRepository<Dividend>
    {
        public DividendRepository(DataContext context) : base(context)
        {
        }

        public static void OnModelCreating(ModelBuilder modelBuilder) 
        {

        }
    }
}