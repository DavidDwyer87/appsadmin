namespace CafeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "smallprice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "smallprice");
        }
    }
}
