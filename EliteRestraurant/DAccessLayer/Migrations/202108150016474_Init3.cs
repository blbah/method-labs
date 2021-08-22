namespace DAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuEntityDishEntities", "MenuEntity_Id", "dbo.MenuEntities");
            DropForeignKey("dbo.MenuEntityDishEntities", "DishEntity_Id", "dbo.DishEntities");
            DropIndex("dbo.MenuEntityDishEntities", new[] { "MenuEntity_Id" });
            DropIndex("dbo.MenuEntityDishEntities", new[] { "DishEntity_Id" });
            AddColumn("dbo.DishEntities", "MenuEntity_Id", c => c.Int());
            CreateIndex("dbo.DishEntities", "MenuEntity_Id");
            AddForeignKey("dbo.DishEntities", "MenuEntity_Id", "dbo.MenuEntities", "Id");
            DropTable("dbo.MenuEntityDishEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuEntityDishEntities",
                c => new
                    {
                        MenuEntity_Id = c.Int(nullable: false),
                        DishEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuEntity_Id, t.DishEntity_Id });
            
            DropForeignKey("dbo.DishEntities", "MenuEntity_Id", "dbo.MenuEntities");
            DropIndex("dbo.DishEntities", new[] { "MenuEntity_Id" });
            DropColumn("dbo.DishEntities", "MenuEntity_Id");
            CreateIndex("dbo.MenuEntityDishEntities", "DishEntity_Id");
            CreateIndex("dbo.MenuEntityDishEntities", "MenuEntity_Id");
            AddForeignKey("dbo.MenuEntityDishEntities", "DishEntity_Id", "dbo.DishEntities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuEntityDishEntities", "MenuEntity_Id", "dbo.MenuEntities", "Id", cascadeDelete: true);
        }
    }
}
