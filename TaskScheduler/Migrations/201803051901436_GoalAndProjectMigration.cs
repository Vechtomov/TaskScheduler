namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GoalAndProjectMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Priority", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "ExpirationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Status", c => c.String());
            DropColumn("dbo.Tasks", "IsCompleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "IsCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tasks", "Status");
            DropColumn("dbo.Tasks", "ExpirationDate");
            DropColumn("dbo.Tasks", "CreationDate");
            DropColumn("dbo.Tasks", "Priority");
        }
    }
}
