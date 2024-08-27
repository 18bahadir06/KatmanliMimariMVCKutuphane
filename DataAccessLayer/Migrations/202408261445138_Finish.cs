namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Finish : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Staffs", "Admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Staffs", "Admin");
        }
    }
}
