namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeUpdateMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            CreateTable(
                "dbo.ProjectApplicationUsers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AlterColumn("dbo.GoalActions", "Date", c => c.DateTime());
            AlterColumn("dbo.Goals", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Goals", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.Goals", "Progress", c => c.Int());
            AlterColumn("dbo.Tasks", "Priority", c => c.Int());
            AlterColumn("dbo.Tasks", "CreationDate", c => c.DateTime());
            AlterColumn("dbo.Tasks", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "CreationDate", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Project_Id", c => c.Int());
            DropForeignKey("dbo.ProjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectApplicationUsers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProjectApplicationUsers", new[] { "Project_Id" });
            AlterColumn("dbo.Projects", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "Priority", c => c.Int(nullable: false));
            AlterColumn("dbo.Goals", "Progress", c => c.Int(nullable: false));
            AlterColumn("dbo.Goals", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Goals", "CreationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.GoalActions", "Date", c => c.DateTime(nullable: false));
            DropTable("dbo.ProjectApplicationUsers");
            CreateIndex("dbo.AspNetUsers", "Project_Id");
            AddForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
