using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-C7T317I\\SQLEXPRESS02;Database=SQLEXPRESS02;Trusted_Connection=True;TrustServerCertificate=true;");
        }

        public DbSet<Nutrition> Nutritions { get; set;}
        public DbSet<Food> Foods { get; set;}
        public DbSet<UnitDefinition> UnitDefinition { get; set;}

        public DbSet<Diary> diaries { get; set;}
        public DbSet<DiaryItem> DiaryItems { get; set;}
        public DbSet<Meal> meals { get; set;}
        public DbSet<MealItem> mealsItem { get; set;}
        public DbSet<Recepie> Recepies { get; set;}
        public DbSet<RecepieItem> RecepieItems { get; set;} 


    }
}
