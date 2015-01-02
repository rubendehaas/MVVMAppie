namespace MVVMAppie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedShoppingList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BrandProducts", "ShoppingList_ShoppingListId", "dbo.ShoppingLists");
            DropForeignKey("dbo.Coupons", "ShoppingList_ShoppingListId", "dbo.ShoppingLists");
            DropIndex("dbo.Coupons", new[] { "ShoppingList_ShoppingListId" });
            DropIndex("dbo.BrandProducts", new[] { "ShoppingList_ShoppingListId" });
            DropColumn("dbo.Coupons", "ShoppingList_ShoppingListId");
            DropColumn("dbo.BrandProducts", "ShoppingList_ShoppingListId");
            DropTable("dbo.ShoppingLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        ShoppingListId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingListId);
            
            AddColumn("dbo.BrandProducts", "ShoppingList_ShoppingListId", c => c.Int());
            AddColumn("dbo.Coupons", "ShoppingList_ShoppingListId", c => c.Int());
            CreateIndex("dbo.BrandProducts", "ShoppingList_ShoppingListId");
            CreateIndex("dbo.Coupons", "ShoppingList_ShoppingListId");
            AddForeignKey("dbo.Coupons", "ShoppingList_ShoppingListId", "dbo.ShoppingLists", "ShoppingListId");
            AddForeignKey("dbo.BrandProducts", "ShoppingList_ShoppingListId", "dbo.ShoppingLists", "ShoppingListId");
        }
    }
}
