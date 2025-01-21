namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodData", "Name", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.RecipeData", "Name", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.RecoveryQuestions", "Question", c => c.String(maxLength: 256, storeType: "nvarchar"));
            AlterColumn("dbo.TrainingData", "Name", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.UserMainData", "Email", c => c.String(maxLength: 256, storeType: "nvarchar"));
            AlterColumn("dbo.UserMainData", "FirstName", c => c.String(maxLength: 128, storeType: "nvarchar"));
            AlterColumn("dbo.UserMainData", "PasswordHash", c => c.String(maxLength: 256, storeType: "nvarchar"));
            AlterColumn("dbo.UserMainData", "Salt", c => c.String(maxLength: 256, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMainData", "Salt", c => c.String(unicode: false));
            AlterColumn("dbo.UserMainData", "PasswordHash", c => c.String(unicode: false));
            AlterColumn("dbo.UserMainData", "FirstName", c => c.String(unicode: false));
            AlterColumn("dbo.UserMainData", "Email", c => c.String(unicode: false));
            AlterColumn("dbo.TrainingData", "Name", c => c.String(unicode: false));
            AlterColumn("dbo.RecoveryQuestions", "Question", c => c.String(unicode: false));
            AlterColumn("dbo.RecipeData", "Name", c => c.String(unicode: false));
            AlterColumn("dbo.FoodData", "Name", c => c.String(unicode: false));
        }
    }
}
