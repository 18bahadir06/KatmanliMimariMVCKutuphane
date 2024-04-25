namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Operations", "Staff_StaffId1", "dbo.Staffs");
            DropIndex("dbo.Operations", new[] { "Staff_StaffId1" });
            DropColumn("dbo.Operations", "Staff_StaffId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Operations", "Staff_StaffId1", c => c.Int());
            CreateIndex("dbo.Operations", "Staff_StaffId1");
            AddForeignKey("dbo.Operations", "Staff_StaffId1", "dbo.Staffs", "StaffId");
        }
    }
}
