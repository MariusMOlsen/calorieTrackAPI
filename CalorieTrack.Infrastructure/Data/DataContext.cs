
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Data
{

    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-C7T317I\\SQLEXPRESS02;Database=SQLEXPRESS02;Trusted_Connection=True;TrustServerCertificate=true;");
            
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     modelBuilder.Entity<User>()
        //         .Property(e => e.ProfileType)
        //         .HasConversion(
        //             v => v.Value, 
        //             v => ProfileType.FromValue(v));
        // }
      

        public async Task CommitChangesAsync()
        {
            await SaveChangesAsync();
        }


        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<UnitDefinition> UnitDefinition { get; set; }

        public DbSet<Diary> Diaries { get; set; }
        public DbSet<DiaryItem> DiaryItems { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealItem> MealsItem { get; set; }
        public DbSet<Recepie> Recepies { get; set; }
        public DbSet<RecepieItem> RecepieItems { get; set; }
        
      public DbSet<User> Users {get; set;}
        

    }
}
