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
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectCourses",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Course_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.SubjectTeachers",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Teacher_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "Headman_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "ForeingLanguage_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectTeachers", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.SubjectTeachers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.SubjectCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.SubjectCourses", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Teachers", "Course_Id", "dbo.Courses");
            DropIndex("dbo.SubjectTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.SubjectTeachers", new[] { "Subject_Id" });
            DropIndex("dbo.SubjectCourses", new[] { "Course_Id" });
            DropIndex("dbo.SubjectCourses", new[] { "Subject_Id" });
            DropIndex("dbo.Teachers", new[] { "Course_Id" });
            DropIndex("dbo.Students", new[] { "Course_Id" });
            DropIndex("dbo.Students", new[] { "ForeingLanguage_Id" });
            DropIndex("dbo.Courses", new[] { "Headman_Id" });
            DropTable("dbo.SubjectTeachers");
            DropTable("dbo.SubjectCourses");
            DropTable("dbo.Grades");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
