namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoalAndProjectMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GoalActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        GoalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goals", t => t.GoalId, cascadeDelete: true)
                .Index(t => t.GoalId);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Level = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Progress = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Project_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Project_Id");
            AddForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Goals", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GoalActions", "GoalId", "dbo.Goals");
            DropIndex("dbo.AspNetUsers", new[] { "Project_Id" });
            DropIndex("dbo.Goals", new[] { "UserId" });
            DropIndex("dbo.GoalActions", new[] { "GoalId" });
            DropColumn("dbo.AspNetUsers", "Project_Id");
            DropTable("dbo.Projects");
            DropTable("dbo.Goals");
            DropTable("dbo.GoalActions");
        }
    }
}
