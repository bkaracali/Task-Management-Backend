using Entities.Models;
using Microsoft.Extensions.DependencyInjection;
using Repo.DI;
using Repo.Somut;
using Repo.Soyut;
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
           
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IStockDatumService, StockDatumService>();
            services.AddScoped<IUserStockService, UserStockService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IUserPasswordService, UserPasswordService>();



            RepoDI.Init(services);

        }


    }
}
