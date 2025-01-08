using Microsoft.Extensions.DependencyInjection;
using Repo.DI;
using Services.Somut;
using Services.Soyut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DI
{
    public static class ServiceDI
    {
        public static void Init(IServiceCollection services)
        {
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IStockDatumService, StockDatumService>();
            services.AddScoped<IUserPasswordService, UserPasswordService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserStockService, UserStockService>();
            

            ReposDI.Init(services);

        }


    }
}
