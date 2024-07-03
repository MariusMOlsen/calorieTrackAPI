
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.Domain.Model.Food;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitDefinition>(entity =>
            {
                entity
                    .HasOne(ud => ud.Nutrition)
                    .WithOne(n => n.UnitDefinition)
                    .HasForeignKey<Nutrition>(n => n.UnitDefinitionGuid);
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity
                    .HasOne(n => n.UnitDefinition)
                    .WithOne(ud => ud.Nutrition)
                    .HasForeignKey<UnitDefinition>(ud => ud.NutritionGuid);
            });

            // Configure other entities...
        }

        public async Task CommitChangesAsync()
        {
            await SaveChangesAsync();
        }


        public DbSet<Nutrition> Nutritions { get; set; }
        public DbSet<UserFood> UserFoods { get; set; }
        public DbSet<CommonFood> CommonFoods { get; set; }
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
