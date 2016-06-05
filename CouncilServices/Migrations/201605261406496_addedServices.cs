namespace CouncilServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedServices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Service", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "QueuedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "QueuedAt");
            DropColumn("dbo.Customers", "Service");
        }
    }
}
