using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using Microsoft.Extensions.DependencyInjection;


namespace CalorieTrack.Infrastructure
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<IDiaryItemRepository, DiaryItemRepository>(); 
            services.AddScoped<IDiaryRepository,DiaryRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IMealItemRepository,MealItemRepository>();
            services.AddScoped<IRecepieItemRepository,RecepieItemRepository>();
            services.AddScoped<IRecepieRepository,RecepieRepository>();
            services.AddScoped<IMealRepository,MealRepository>();
            services.AddScoped<INutritionRepository,NutritionRepository>();
            services.AddScoped<IUnitDefinitionRepository,UnitDefinitionRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<DataContext>());



            return services;
        }
    }
}
