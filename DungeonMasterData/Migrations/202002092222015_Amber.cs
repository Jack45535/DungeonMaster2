namespace DungeonMasterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Amber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Owner = c.String(maxLength: 50),
                        Age = c.Int(nullable: false),
                        CharDesc = c.String(),
                        Plat = c.Int(nullable: false),
                        Gold = c.Int(nullable: false),
                        Silver = c.Int(nullable: false),
                        Copper = c.Int(nullable: false),
                        Str = c.Int(nullable: false),
                        Int = c.Int(nullable: false),
                        Dex = c.Int(nullable: false),
                        Luck = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                        Charisma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Games", "GameMaster", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "GameId", "dbo.Games");
            DropIndex("dbo.Characters", new[] { "GameId" });
            AlterColumn("dbo.Games", "GameMaster", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false));
            DropTable("dbo.Characters");
        }
    }
}
