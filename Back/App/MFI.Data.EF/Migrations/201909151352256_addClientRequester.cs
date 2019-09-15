namespace MFI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientRequester : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 80, storeType: "nvarchar"),
                        TypeCode = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        UserId = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        CreatedByUserId = c.String(nullable: false, maxLength: 36, storeType: "nvarchar"),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropTable("dbo.Clients");
        }
    }
}
