namespace DAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CookEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecializationId = c.Int(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpecializationEntities", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId);
            
            CreateTable(
                "dbo.SpecializationEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DishTypeEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SpecializationEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpecializationEntities", t => t.SpecializationEntity_Id)
                .Index(t => t.SpecializationEntity_Id);
            
            CreateTable(
                "dbo.DishEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PreparingTime = c.Time(nullable: false, precision: 7),
                        DishTypeId = c.Int(nullable: false),
                        MenuEntity_Id = c.Int(),
                        OrderEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DishTypeEntities", t => t.DishTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MenuEntities", t => t.MenuEntity_Id)
                .ForeignKey("dbo.OrderEntities", t => t.OrderEntity_Id)
                .Index(t => t.DishTypeId)
                .Index(t => t.MenuEntity_Id)
                .Index(t => t.OrderEntity_Id);
            
            CreateTable(
                "dbo.MenuEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DishEntities", "OrderEntity_Id", "dbo.OrderEntities");
            DropForeignKey("dbo.DishEntities", "MenuEntity_Id", "dbo.MenuEntities");
            DropForeignKey("dbo.DishEntities", "DishTypeId", "dbo.DishTypeEntities");
            DropForeignKey("dbo.CookEntities", "SpecializationId", "dbo.SpecializationEntities");
            DropForeignKey("dbo.DishTypeEntities", "SpecializationEntity_Id", "dbo.SpecializationEntities");
            DropIndex("dbo.DishEntities", new[] { "OrderEntity_Id" });
            DropIndex("dbo.DishEntities", new[] { "MenuEntity_Id" });
            DropIndex("dbo.DishEntities", new[] { "DishTypeId" });
            DropIndex("dbo.DishTypeEntities", new[] { "SpecializationEntity_Id" });
            DropIndex("dbo.CookEntities", new[] { "SpecializationId" });
            DropTable("dbo.OrderEntities");
            DropTable("dbo.MenuEntities");
            DropTable("dbo.DishEntities");
            DropTable("dbo.DishTypeEntities");
            DropTable("dbo.SpecializationEntities");
            DropTable("dbo.CookEntities");
        }
    }
}
