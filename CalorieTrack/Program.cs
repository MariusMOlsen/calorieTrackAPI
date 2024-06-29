using CalorieTrack.Api;
using CalorieTrack.Application;
using CalorieTrack.Infrastructure;
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
           // policyBuilder.AllowCredentials();
        });
});


builder.Services.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);
app.Run();
