namespace StoreCell.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storecell : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterProduct", "Nmae", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisterProduct", "Nmae");
        }
    }
}
