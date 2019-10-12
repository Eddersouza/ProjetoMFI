namespace MFI.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addClientProvider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "CompanyName", c => c.String(maxLength: 80, storeType: "nvarchar"));
            AddColumn("dbo.Clients", "Description", c => c.String(maxLength: 500, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Description");
            DropColumn("dbo.Clients", "CompanyName");
        }
    }
}
