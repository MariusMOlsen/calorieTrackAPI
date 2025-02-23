using CalorieTrack.Services.interfaces;
using CalorieTrack.Services;
using Microsoft.Extensions.DependencyInjection;

using CalorieTrack.Application.Common.Behaviours;
using CalorieTrack.Application.Services;
using FluentValidation;

namespace CalorieTrack.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication( this IServiceCollection services)
        {
            // All of theese will eventually be replaced by the MediatR
            services.AddScoped<IUnitDefinitionService, UnitDefinitionService>();
            services.AddScoped<INutritionService, NutritionService>();
          
          
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IMealItemService, MealItemService>();
            services.AddScoped<IRecepieItemService, RecepieItemService>();
            services.AddScoped<IRecepieService, RecepieService>();
            services.AddScoped<IDiaryService, DiaryService>();


            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(DependencyInjection));

                options.AddOpenBehavior(typeof(ValidationBehavior<,>));
                options.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            });

            services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
            return services;
        }

    }
}
