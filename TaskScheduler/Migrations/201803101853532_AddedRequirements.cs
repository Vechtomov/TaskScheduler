namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GoalActions", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "Name", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
            AlterColumn("dbo.GoalActions", "Description", c => c.String());
        }
    }
}
