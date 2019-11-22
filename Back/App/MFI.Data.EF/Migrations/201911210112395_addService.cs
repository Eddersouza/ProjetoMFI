namespace MFI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 40, storeType: "nvarchar"),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreatedByUserId = c.String(nullable: false, maxLength: 36, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Services");
        }
    }
}
