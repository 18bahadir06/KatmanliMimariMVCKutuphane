namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Pages = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        GenreId = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Info = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        OperationId = c.Int(nullable: false, identity: true),
                        BorrowDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        RecipientId = c.Int(nullable: false),
                        ReturnerId = c.Int(nullable: false),
                        Staff_StaffId = c.Int(),
                        Staff_StaffId1 = c.Int(),
                        Recipient_StaffId = c.Int(),
                        Returner_StaffId = c.Int(),
                    })
                .PrimaryKey(t => t.OperationId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffId)
                .ForeignKey("dbo.Staffs", t => t.Staff_StaffId1)
                .ForeignKey("dbo.Staffs", t => t.Recipient_StaffId)
                .ForeignKey("dbo.Staffs", t => t.Returner_StaffId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.StudentId)
                .Index(t => t.Staff_StaffId)
                .Index(t => t.Staff_StaffId1)
                .Index(t => t.Recipient_StaffId)
                .Index(t => t.Returner_StaffId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Gmail = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        DateBirth = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Gmail = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Operations", "Returner_StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Operations", "Recipient_StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Operations", "Staff_StaffId1", "dbo.Staffs");
            DropForeignKey("dbo.Operations", "Staff_StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Operations", "BookId", "dbo.Books");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Operations", new[] { "Returner_StaffId" });
            DropIndex("dbo.Operations", new[] { "Recipient_StaffId" });
            DropIndex("dbo.Operations", new[] { "Staff_StaffId1" });
            DropIndex("dbo.Operations", new[] { "Staff_StaffId" });
            DropIndex("dbo.Operations", new[] { "StudentId" });
            DropIndex("dbo.Operations", new[] { "BookId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Students");
            DropTable("dbo.Staffs");
            DropTable("dbo.Operations");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
