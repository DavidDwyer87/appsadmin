namespace AppService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.projectStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        project = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.project_tbl",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        proj = c.String(),
                        url = c.String(),
                        PageActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.UserProfile");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Name = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.project_tbl");
            DropTable("dbo.projectStatus");
        }
    }
}
