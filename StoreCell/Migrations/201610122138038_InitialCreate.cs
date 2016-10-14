namespace StoreCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProviProduct",
                c => new
                    {
                        IDPP = c.Int(nullable: false, identity: true),
                        IDProvider = c.Int(nullable: false),
                        IDProduct = c.Int(nullable: false),
                        Date = c.String(),
                        Amount = c.Int(nullable: false),
                        RegisterProvs_ProvID = c.Int(),
                        RegisterProducts_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.IDPP)
                .ForeignKey("dbo.RegisterProv", t => t.RegisterProvs_ProvID)
                .ForeignKey("dbo.RegisterProduct", t => t.RegisterProducts_ProductID)
                .Index(t => t.RegisterProvs_ProvID)
                .Index(t => t.RegisterProducts_ProductID);
            
            CreateTable(
                "dbo.RegisterProduct",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Version = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.RegisterProv",
                c => new
                    {
                        ProvID = c.Int(nullable: false, identity: true),
                        ProvName = c.String(),
                        ProvEmail = c.String(),
                        ProvPhone = c.String(),
                        RegisterProduct_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ProvID)
                .ForeignKey("dbo.RegisterProduct", t => t.RegisterProduct_ProductID)
                .Index(t => t.RegisterProduct_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProviProduct", "RegisterProducts_ProductID", "dbo.RegisterProduct");
            DropForeignKey("dbo.RegisterProv", "RegisterProduct_ProductID", "dbo.RegisterProduct");
            DropForeignKey("dbo.ProviProduct", "RegisterProvs_ProvID", "dbo.RegisterProv");
            DropIndex("dbo.RegisterProv", new[] { "RegisterProduct_ProductID" });
            DropIndex("dbo.ProviProduct", new[] { "RegisterProducts_ProductID" });
            DropIndex("dbo.ProviProduct", new[] { "RegisterProvs_ProvID" });
            DropTable("dbo.RegisterProv");
            DropTable("dbo.RegisterProduct");
            DropTable("dbo.ProviProduct");
        }
    }
}
