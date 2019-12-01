namespace MFI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProviderServices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProviderServices",
                c => new
                    {
                        ClientId = c.Guid(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        MinimunAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreatedByUserId = c.String(nullable: false, maxLength: 36, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.ClientId, t.ServiceId })
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProviderServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ProviderServices", "ClientId", "dbo.Clients");
            DropIndex("dbo.ProviderServices", new[] { "ServiceId" });
            DropIndex("dbo.ProviderServices", new[] { "ClientId" });
            DropTable("dbo.ProviderServices");
        }
    }
}
