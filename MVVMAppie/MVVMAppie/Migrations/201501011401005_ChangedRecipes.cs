namespace MVVMAppie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRecipes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BrandProducts", "Recipe_RecipeId", "dbo.Recipes");
            DropIndex("dbo.BrandProducts", new[] { "Recipe_RecipeId" });
            CreateTable(
                "dbo.RecipeBrandProducts",
                c => new
                    {
                        Recipe_RecipeId = c.Int(nullable: false),
                        BrandProduct_BrandProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_RecipeId, t.BrandProduct_BrandProductId })
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId, cascadeDelete: true)
                .ForeignKey("dbo.BrandProducts", t => t.BrandProduct_BrandProductId, cascadeDelete: true)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.BrandProduct_BrandProductId);
            
            DropColumn("dbo.BrandProducts", "Recipe_RecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BrandProducts", "Recipe_RecipeId", c => c.Int());
            DropForeignKey("dbo.RecipeBrandProducts", "BrandProduct_BrandProductId", "dbo.BrandProducts");
            DropForeignKey("dbo.RecipeBrandProducts", "Recipe_RecipeId", "dbo.Recipes");
            DropIndex("dbo.RecipeBrandProducts", new[] { "BrandProduct_BrandProductId" });
            DropIndex("dbo.RecipeBrandProducts", new[] { "Recipe_RecipeId" });
            DropTable("dbo.RecipeBrandProducts");
            CreateIndex("dbo.BrandProducts", "Recipe_RecipeId");
            AddForeignKey("dbo.BrandProducts", "Recipe_RecipeId", "dbo.Recipes", "RecipeId");
        }
    }
}
