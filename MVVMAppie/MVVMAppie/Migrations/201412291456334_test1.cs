namespace MVVMAppie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Section_SectionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Sections", t => t.Section_SectionId)
                .Index(t => t.Section_SectionId);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        BrandProduct_BrandProductId = c.Int(),
                        Product_ProductId = c.Int(),
                        ShoppingList_ShoppingListId = c.Int(),
                    })
                .PrimaryKey(t => t.CouponId)
                .ForeignKey("dbo.BrandProducts", t => t.BrandProduct_BrandProductId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingList_ShoppingListId)
                .Index(t => t.BrandProduct_BrandProductId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.ShoppingList_ShoppingListId);
            
            CreateTable(
                "dbo.BrandProducts",
                c => new
                    {
                        BrandProductId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Brand_BrandId = c.Int(),
                        Product_ProductId = c.Int(),
                        Recipe_RecipeId = c.Int(),
                        ShoppingList_ShoppingListId = c.Int(),
                    })
                .PrimaryKey(t => t.BrandProductId)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId)
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingList_ShoppingListId)
                .Index(t => t.Brand_BrandId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.ShoppingList_ShoppingListId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        SectionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SectionId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RecipeId);
            
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        ShoppingListId = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingListId);
            
            CreateTable(
                "dbo.ProductBrands",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Brand_BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Brand_BrandId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Brands", t => t.Brand_BrandId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Brand_BrandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coupons", "ShoppingList_ShoppingListId", "dbo.ShoppingLists");
            DropForeignKey("dbo.BrandProducts", "ShoppingList_ShoppingListId", "dbo.ShoppingLists");
            DropForeignKey("dbo.BrandProducts", "Recipe_RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Products", "Section_SectionId", "dbo.Sections");
            DropForeignKey("dbo.Coupons", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Coupons", "BrandProduct_BrandProductId", "dbo.BrandProducts");
            DropForeignKey("dbo.BrandProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.BrandProducts", "Brand_BrandId", "dbo.Brands");
            DropForeignKey("dbo.ProductBrands", "Brand_BrandId", "dbo.Brands");
            DropForeignKey("dbo.ProductBrands", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductBrands", new[] { "Brand_BrandId" });
            DropIndex("dbo.ProductBrands", new[] { "Product_ProductId" });
            DropIndex("dbo.BrandProducts", new[] { "ShoppingList_ShoppingListId" });
            DropIndex("dbo.BrandProducts", new[] { "Recipe_RecipeId" });
            DropIndex("dbo.BrandProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.BrandProducts", new[] { "Brand_BrandId" });
            DropIndex("dbo.Coupons", new[] { "ShoppingList_ShoppingListId" });
            DropIndex("dbo.Coupons", new[] { "Product_ProductId" });
            DropIndex("dbo.Coupons", new[] { "BrandProduct_BrandProductId" });
            DropIndex("dbo.Products", new[] { "Section_SectionId" });
            DropTable("dbo.ProductBrands");
            DropTable("dbo.ShoppingLists");
            DropTable("dbo.Recipes");
            DropTable("dbo.Sections");
            DropTable("dbo.BrandProducts");
            DropTable("dbo.Coupons");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
