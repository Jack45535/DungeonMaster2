namespace DungeonMasterData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bags", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Bags", new[] { "CharacterId" });
            DropTable("dbo.Bags");
        }
    }
}
