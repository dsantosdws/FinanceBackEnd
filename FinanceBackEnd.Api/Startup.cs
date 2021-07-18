using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using FinanceBackEnd.Infrastructure.Repositories;
using FinanceBackEnd.Models.Entitys;
using FinanceBackEnd.Api.Extensions;

namespace FinanceBackEnd.Api
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "TryInvest";

        private string GetConnectionString() 
            => Configuration.GetConnectionString("DefaultConnection");

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContextPool<DataContext>(options =>
                options.UseMySql(
                    this.GetConnectionString()
                    , ServerVersion.AutoDetect(this.GetConnectionString())
                    , optionsBuilder => optionsBuilder.MigrationsAssembly("FinanceBackEnd.Api")));

            services.AddCors(options => {
                options.AddDefaultPolicy(builder => {
                    builder.WithOrigins("http://localhost:3000");
                });
            });

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanceBackEnd.Api", Version = "v1" });
            });

            services.DependencyRepositorys();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceBackEnd.Api v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
