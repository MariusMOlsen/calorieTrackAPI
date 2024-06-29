using System.Runtime.CompilerServices;
using System.Text;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Infrastructure.Authentication;
using CalorieTrack.Infrastructure.Authentication.TokenGenerator;
using CalorieTrack.Infrastructure.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace CalorieTrack.Infrastructure
{

    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services,  IConfiguration configuration)
       {
            services.AddAuthentication(configuration);
            services.AddDbContext<DataContext>();
            services.AddScoped<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddScoped<IGoogleAuthentication, GoogleAuthentication>();
            services.AddScoped<IUserRepository, UserRepository>();
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
       
       
       public static IServiceCollection AddAuthentication( this IServiceCollection services,IConfiguration configuration)
       {
           services.AddAuthentication(options =>
           {
               options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           });
           services.ValidateJwt(configuration);
           
           return services;
       }
       
       public static IServiceCollection ValidateJwt(this IServiceCollection services, IConfiguration configuration)
       {
           var jwtSettings = new JwtSettings();
           configuration.Bind(JwtSettings.Section, jwtSettings);

           services.AddSingleton(Options.Create(jwtSettings));
           services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
           // services.AddSingleton<IPasswordHasher, PasswordHasher>();

           services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
               {
                   // ValidateIssuer = true,
                   // ValidateAudience = true,
                   // ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = jwtSettings.Issuer,
                   ValidAudience = jwtSettings.Audience,
                   IssuerSigningKey = new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(jwtSettings.Secret)),
               });


           return services;
       }
    }
}
