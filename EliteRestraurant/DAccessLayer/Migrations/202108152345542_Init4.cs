namespace DAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DishEntities", "MenuEntity_Id", "dbo.MenuEntities");
            DropIndex("dbo.DishEntities", new[] { "MenuEntity_Id" });
            CreateTable(
                "dbo.MenuEntityDishEntities",
                c => new
                    {
                        MenuEntity_Id = c.Int(nullable: false),
                        DishEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuEntity_Id, t.DishEntity_Id })
                .ForeignKey("dbo.MenuEntities", t => t.MenuEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.DishEntities", t => t.DishEntity_Id, cascadeDelete: true)
                .Index(t => t.MenuEntity_Id)
                .Index(t => t.DishEntity_Id);
            
            DropColumn("dbo.DishEntities", "MenuEntity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DishEntities", "MenuEntity_Id", c => c.Int());
            DropForeignKey("dbo.MenuEntityDishEntities", "DishEntity_Id", "dbo.DishEntities");
            DropForeignKey("dbo.MenuEntityDishEntities", "MenuEntity_Id", "dbo.MenuEntities");
            DropIndex("dbo.MenuEntityDishEntities", new[] { "DishEntity_Id" });
            DropIndex("dbo.MenuEntityDishEntities", new[] { "MenuEntity_Id" });
            DropTable("dbo.MenuEntityDishEntities");
            CreateIndex("dbo.DishEntities", "MenuEntity_Id");
            AddForeignKey("dbo.DishEntities", "MenuEntity_Id", "dbo.MenuEntities", "Id");
        }
    }
}
