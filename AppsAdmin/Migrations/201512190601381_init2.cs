namespace AppService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
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
        }
        
        public override void Down()
        {
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
            
            CreateTable(
                "dbo.projectStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        project = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.UserProfile");
        }
    }
}
