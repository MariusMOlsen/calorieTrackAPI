using CalorieTrack.Api.Services;
using CalorieTrack.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace CalorieTrack.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();
  

        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();

        return services;
    }

    
    
}