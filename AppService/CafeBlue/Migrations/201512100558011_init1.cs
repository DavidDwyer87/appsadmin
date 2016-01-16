namespace CafeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "medprice", c => c.String());
            AddColumn("dbo.Products", "largeprice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "largeprice");
            DropColumn("dbo.Products", "medprice");
        }
    }
}
