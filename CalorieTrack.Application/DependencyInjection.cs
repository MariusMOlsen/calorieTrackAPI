using CalorieTrack.Services.interfaces;
using CalorieTrack.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services)
        {
            services.AddScoped<IUnitDefinitionService, UnitDefinitionService>();
            services.AddScoped<INutritionService, NutritionService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IMealItemService, MealItemService>();
            services.AddScoped<IRecepieItemService, RecepieItemService>();
            services.AddScoped<IRecepieService, RecepieService>();
            services.AddScoped<IDiaryService, DiaryService>();
            return services;
        }

    }
}
