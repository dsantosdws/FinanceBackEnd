using FinanceBackEnd.Infrastructure.Repositories;
using FinanceBackEnd.Models.Entitys;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceBackEnd.Api.Extensions
{
    public static class DependencyInjection
    {
        public static void DependencyRepositorys(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddScoped<IRepository<Stock>, StockRepository>();
            serviceCollection.AddScoped<IRepository<Dividend>, DividendRepository>();
        }
    }
}