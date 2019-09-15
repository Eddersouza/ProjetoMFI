namespace MFI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDBAndUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Password = c.String(nullable: false, maxLength: 36, storeType: "nvarchar"),
                        Email = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreatedByUserId = c.String(nullable: false, maxLength: 36, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
