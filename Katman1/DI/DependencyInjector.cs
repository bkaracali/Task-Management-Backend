using Microsoft.Extensions.DependencyInjection;
using Repo.Somut;
using Repo.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.DI
{
    public static class ReposDI
    {
        public static void Init(IServiceCollection services)
        {
            // DbContext konfigürasyonu

            // Repository konfigürasyonu

           services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();
            services.AddScoped<IStockDatumRepository, StockDatumRepository>();
            services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserStockRepository, UserStockRepository>();


            // Diğer servis konfigürasyonları burada yapılabilir
        }
    }
}
