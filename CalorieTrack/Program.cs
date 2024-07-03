using System.Diagnostics;
using CalorieTrack.Api;
using CalorieTrack.Application;
using CalorieTrack.Infrastructure;
using GymManagement.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.


// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//                       policyBuilder =>
//                       {
//                       policyBuilder.WithOrigins("http://localhost:4200");
//                       policyBuilder.AllowAnyHeader();
//                           policyBuilder.AllowAnyMethod ();
//                           policyBuilder.AllowCredentials();
//                       });
// });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin(); // Allow all origins
            policyBuilder.AllowAnyHeader();
            policyBuilder.AllowAnyMethod();
         //  policyBuilder.AllowCredentials();
        });
});


builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();



app.Use(async (context, next) =>
{
    await next.Invoke();

    // Log the claims after the authentication middleware has run
    var claims = context.User.Claims.Select(c => new { c.Type, c.Value }).ToList();
    Debug.WriteLine("claims comes below " );
    foreach (var claim in claims)
    {
        Debug.WriteLine("claim: " + claim);
    }
  
});
app.UseExceptionHandler();
//app.AddInfrastructureMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);
app.Run();
