namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Energy = c.Int(nullable: false),
                        CHydrates = c.Int(nullable: false),
                        Sugars = c.Int(nullable: false),
                        Proteins = c.Int(nullable: false),
                        Lipids = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Energy = c.Int(nullable: false),
                        CHydrates = c.Int(nullable: false),
                        Sugars = c.Int(nullable: false),
                        Proteins = c.Int(nullable: false),
                        Lipids = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeIngerdientData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RecipeId = c.Guid(nullable: false),
                        FoodId = c.Guid(nullable: false),
                        Amount = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecoveryQuestions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Question = c.String(unicode: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        AvgConsumptionPerHour = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDailyData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Weight = c.Int(nullable: false),
                        EnergyIntake = c.Int(nullable: false),
                        EnergyConsumption = c.Int(nullable: false),
                        TotalSleep = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFitnessData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sex = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        CalorieLimit = c.Int(),
                        TrainingCalorieGoal = c.Int(),
                        SleepGoal = c.Int(),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMainData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(unicode: false),
                        FirstName = c.String(unicode: false),
                        PasswordHash = c.String(unicode: false),
                        Salt = c.String(unicode: false),
                        PremiumUnlock = c.Boolean(nullable: false),
                        RecoveryId = c.Guid(nullable: false),
                        RecoveryAns = c.String(unicode: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMealData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        MealType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        FoodId = c.Guid(),
                        RecipeId = c.Guid(),
                        Amount = c.Int(nullable: false),
                        EnergyIntake = c.Int(nullable: false),
                        TotalCHydrates = c.Int(nullable: false),
                        TotalSugars = c.Int(nullable: false),
                        TotalProteins = c.Int(nullable: false),
                        TotalLipids = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSleepData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        TotalSleep = c.Int(nullable: false),
                        RemSleep = c.Int(nullable: false),
                        DeepSleep = c.Int(nullable: false),
                        LightSleep = c.Int(nullable: false),
                        AwakeTime = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTokenData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        TokenEnc = c.String(unicode: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTrainingData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        TrainingId = c.Guid(nullable: false),
                        TotalConsumption = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserUpcomingTrainingData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        TrainingId = c.Guid(nullable: false),
                        Duration = c.Int(nullable: false),
                        ModifiedAt = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserUpcomingTrainingData");
            DropTable("dbo.UserTrainingData");
            DropTable("dbo.UserTokenData");
            DropTable("dbo.UserSleepData");
            DropTable("dbo.UserMealData");
            DropTable("dbo.UserMainData");
            DropTable("dbo.UserFitnessData");
            DropTable("dbo.UserDailyData");
            DropTable("dbo.TrainingData");
            DropTable("dbo.RecoveryQuestions");
            DropTable("dbo.RecipeIngerdientData");
            DropTable("dbo.RecipeData");
            DropTable("dbo.FoodData");
        }
    }
}
