using CalorieTrack.Data;
using CalorieTrack.Services;
using CalorieTrack.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitDefinitionService, UnitDefinitionService>();
builder.Services.AddScoped<INutritionService, NutritionService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IMealItemService, MealItemService>();
builder.Services.AddScoped<IRecepieItemService, RecepieItemService>();
builder.Services.AddScoped<IRecepieService, RecepieService>();
builder.Services.AddScoped<IDiaryService, DiaryService>();
builder.Services.AddDbContext<DataContext>();

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

app.Run();
