using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Infrastructure.DiaryItem;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Infrastructure
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<IDiaryItemRepository, DiaryItemRepository>();
           

            return services;
        }
    }
}
