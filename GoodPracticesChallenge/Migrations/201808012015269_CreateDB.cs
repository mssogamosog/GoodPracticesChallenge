namespace GoodPracticesChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Headman_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Headman_Id)
                .Index(t => t.Headman_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ForeingLanguage_Id = c.Int(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.ForeingLanguage_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.ForeingLanguage_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ConcreteLanguage = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Course_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Subjects", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Students", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Headman_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "ForeingLanguage_Id", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "Course_Id" });
            DropIndex("dbo.Subjects", new[] { "Teacher_Id" });
            DropIndex("dbo.Subjects", new[] { "Course_Id" });
            DropIndex("dbo.Students", new[] { "Course_Id" });
            DropIndex("dbo.Students", new[] { "ForeingLanguage_Id" });
            DropIndex("dbo.Courses", new[] { "Headman_Id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Grades");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
