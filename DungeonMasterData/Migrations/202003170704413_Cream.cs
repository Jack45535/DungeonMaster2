namespace DungeonMasterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cream : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
            CreateTable(
                "dbo.Spells",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Intensity = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Spells", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Pets", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Spells", new[] { "CharacterId" });
            DropIndex("dbo.Pets", new[] { "CharacterId" });
            DropTable("dbo.Spells");
            DropTable("dbo.Pets");
        }
    }
}
