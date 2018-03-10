namespace TaskScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Goals", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Goals", "Name", c => c.String());
        }
    }
}
