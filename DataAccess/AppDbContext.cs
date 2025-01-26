using Domain;
using MySql.Data.EntityFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppDbContext : DbContext
    {
        public DbSet<FoodEntity> FoodData { get; set; }
        public DbSet<RecipeEntity> RecipeData { get; set; }
        public DbSet<RecipeIngredientEntity> RecipeIngerdientData { get; set; }
        public DbSet<RecoveryQuestionEntity> RecoveryQuestions { get; set; }
        public DbSet<TrainingEntity> TrainingData { get; set; }
        public DbSet<UserMainEntity> UserMainData { get; set; }
        public DbSet<UserFitnessEntity> UserFitnessData { get; set; }
        public DbSet<UserTokenEntity> UserTokenData { get; set; }
        public DbSet<UserMealEntity> UserMealData { get; set; }
        public DbSet<UserUpcomingTrainingEntity> UserUpcomingTrainingData { get; set; }
        public DbSet<UserSleepEntity> UserSleepData { get; set; }
        public DbSet<UserTrainingEntity> UserTrainingData { get; set; }
        public DbSet<UserDailyEntity> UserDailyData { get; set; }

        public AppDbContext() : base("DefaultDBConnection")
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public AppDbContext(string connectionString) : base(new MySql.Data.MySqlClient.MySqlConnection(connectionString), contextOwnsConnection: true)
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodEntity>().ToTable("FoodData");
            modelBuilder.Entity<RecipeEntity>().ToTable("RecipeData");
            modelBuilder.Entity<RecipeIngredientEntity>().ToTable("RecipeIngerdientData");
            modelBuilder.Entity<RecoveryQuestionEntity>().ToTable("RecoveryQuestions");
            modelBuilder.Entity<TrainingEntity>().ToTable("TrainingData");
            modelBuilder.Entity<UserMainEntity>().ToTable("UserMainData");
            modelBuilder.Entity<UserFitnessEntity>().ToTable("UserFitnessData");
            modelBuilder.Entity<UserSleepEntity>().ToTable("UserSleepData");
            modelBuilder.Entity<UserTrainingEntity>().ToTable("UserTrainingData");
            modelBuilder.Entity<UserUpcomingTrainingEntity>().ToTable("UserUpcomingTrainingData");
            modelBuilder.Entity<UserDailyEntity>().ToTable("UserDailyData");
            modelBuilder.Entity<UserTokenEntity>().ToTable("UserTokenData");
            modelBuilder.Entity<UserMealEntity>().ToTable("UserMealData");
        }
    }
}
