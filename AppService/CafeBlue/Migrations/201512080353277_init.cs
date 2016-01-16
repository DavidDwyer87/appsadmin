namespace CafeBlue.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Location = c.String(),
                        LearnedComments = c.String(),
                        OtherComments = c.String(),
                        ExprienceRating = c.Int(nullable: false),
                        ReadStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductReview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        user = c.String(),
                        productRating = c.Int(nullable: false),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCatigory = c.String(),
                        ProductName = c.String(),
                        Description = c.String(),
                        Rewards = c.Int(nullable: false),
                        Reward_Free = c.Int(nullable: false),
                        ProductImage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.ProductReview");
            DropTable("dbo.Feedback");
        }
    }
}
