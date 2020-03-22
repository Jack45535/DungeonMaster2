namespace DungeonMasterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dandelion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "CharacterBackground", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "CharacterBackground");
        }
    }
}
