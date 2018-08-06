namespace GoodPracticesChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Grades", new[] { "subject_Id" });
            CreateIndex("dbo.Grades", "Subject_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Grades", new[] { "Subject_Id" });
            CreateIndex("dbo.Grades", "subject_Id");
        }
    }
}
