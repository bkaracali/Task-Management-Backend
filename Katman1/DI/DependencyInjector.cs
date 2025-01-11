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
    public static class RepoDI
    {
        public static void Init(IServiceCollection services)
        {
            // DbContext konfigürasyonu

            // Repository konfigürasyonu

           
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStockDatumRepository, StockDatumRepository>();
            services.AddScoped<IUserStockRepository, UserStockRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();
            services.AddScoped<IUserPasswordRepository, UserPasswordRepository>();
           



            // Diğer servis konfigürasyonları burada yapılabilir
        }
    }
}
