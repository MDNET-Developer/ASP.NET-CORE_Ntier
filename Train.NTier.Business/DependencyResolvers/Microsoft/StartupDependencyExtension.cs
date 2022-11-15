using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.Business.Interfaces;
using Train.NTier.Business.Services;
using Train.NTier.DataAccsess.Context;
using Train.NTier.DataAccsess.UnitOfWork;

namespace Train.NTier.Business.DependencyResolvers.Microsoft
{
    public static class StartupDependencyExtension
    {
        public static void AddDependency(this IServiceCollection services)
        {
            services.AddDbContext<ToDoContext>(options =>
            {
                options.UseSqlServer("server=DESKTOP-LV07HAI;database=TrainNTierDb;integrated security=true");
            });
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();
        }
        
    }
}
