namespace DungeonMasterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cream : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bags", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bags", "GameId");
            AddForeignKey("dbo.Bags", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bags", "GameId", "dbo.Games");
            DropIndex("dbo.Bags", new[] { "GameId" });
            DropColumn("dbo.Bags", "GameId");
        }
    }
}
