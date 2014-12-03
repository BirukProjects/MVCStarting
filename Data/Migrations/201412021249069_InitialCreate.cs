namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.developers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNo = c.String(maxLength: 13),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Softwares",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        dev_id = c.Int(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.developers", t => t.dev_id, cascadeDelete: true)
                .Index(t => t.dev_id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Softwares", "dev_id", "dbo.developers");
            DropIndex("dbo.Softwares", new[] { "dev_id" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Softwares");
            DropTable("dbo.developers");
        }
    }
}
