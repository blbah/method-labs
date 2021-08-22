namespace DAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DishTypeEntities", "SpecializationEntity_Id", "dbo.SpecializationEntities");
            DropForeignKey("dbo.DishEntities", "MenuEntity_Id", "dbo.MenuEntities");
            DropForeignKey("dbo.DishEntities", "OrderEntity_Id", "dbo.OrderEntities");
            DropIndex("dbo.DishTypeEntities", new[] { "SpecializationEntity_Id" });
            DropIndex("dbo.DishEntities", new[] { "MenuEntity_Id" });
            DropIndex("dbo.DishEntities", new[] { "OrderEntity_Id" });
            CreateTable(
                "dbo.DishTypeEntitySpecializationEntities",
                c => new
                    {
                        DishTypeEntity_Id = c.Int(nullable: false),
                        SpecializationEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DishTypeEntity_Id, t.SpecializationEntity_Id })
                .ForeignKey("dbo.DishTypeEntities", t => t.DishTypeEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.SpecializationEntities", t => t.SpecializationEntity_Id, cascadeDelete: true)
                .Index(t => t.DishTypeEntity_Id)
                .Index(t => t.SpecializationEntity_Id);
            
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
            
            CreateTable(
                "dbo.OrderEntityDishEntities",
                c => new
                    {
                        OrderEntity_Id = c.Int(nullable: false),
                        DishEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderEntity_Id, t.DishEntity_Id })
                .ForeignKey("dbo.OrderEntities", t => t.OrderEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.DishEntities", t => t.DishEntity_Id, cascadeDelete: true)
                .Index(t => t.OrderEntity_Id)
                .Index(t => t.DishEntity_Id);
            
            DropColumn("dbo.DishTypeEntities", "SpecializationEntity_Id");
            DropColumn("dbo.DishEntities", "MenuEntity_Id");
            DropColumn("dbo.DishEntities", "OrderEntity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DishEntities", "OrderEntity_Id", c => c.Int());
            AddColumn("dbo.DishEntities", "MenuEntity_Id", c => c.Int());
            AddColumn("dbo.DishTypeEntities", "SpecializationEntity_Id", c => c.Int());
            DropForeignKey("dbo.OrderEntityDishEntities", "DishEntity_Id", "dbo.DishEntities");
            DropForeignKey("dbo.OrderEntityDishEntities", "OrderEntity_Id", "dbo.OrderEntities");
            DropForeignKey("dbo.MenuEntityDishEntities", "DishEntity_Id", "dbo.DishEntities");
            DropForeignKey("dbo.MenuEntityDishEntities", "MenuEntity_Id", "dbo.MenuEntities");
            DropForeignKey("dbo.DishTypeEntitySpecializationEntities", "SpecializationEntity_Id", "dbo.SpecializationEntities");
            DropForeignKey("dbo.DishTypeEntitySpecializationEntities", "DishTypeEntity_Id", "dbo.DishTypeEntities");
            DropIndex("dbo.OrderEntityDishEntities", new[] { "DishEntity_Id" });
            DropIndex("dbo.OrderEntityDishEntities", new[] { "OrderEntity_Id" });
            DropIndex("dbo.MenuEntityDishEntities", new[] { "DishEntity_Id" });
            DropIndex("dbo.MenuEntityDishEntities", new[] { "MenuEntity_Id" });
            DropIndex("dbo.DishTypeEntitySpecializationEntities", new[] { "SpecializationEntity_Id" });
            DropIndex("dbo.DishTypeEntitySpecializationEntities", new[] { "DishTypeEntity_Id" });
            DropTable("dbo.OrderEntityDishEntities");
            DropTable("dbo.MenuEntityDishEntities");
            DropTable("dbo.DishTypeEntitySpecializationEntities");
            CreateIndex("dbo.DishEntities", "OrderEntity_Id");
            CreateIndex("dbo.DishEntities", "MenuEntity_Id");
            CreateIndex("dbo.DishTypeEntities", "SpecializationEntity_Id");
            AddForeignKey("dbo.DishEntities", "OrderEntity_Id", "dbo.OrderEntities", "Id");
            AddForeignKey("dbo.DishEntities", "MenuEntity_Id", "dbo.MenuEntities", "Id");
            AddForeignKey("dbo.DishTypeEntities", "SpecializationEntity_Id", "dbo.SpecializationEntities", "Id");
        }
    }
}
