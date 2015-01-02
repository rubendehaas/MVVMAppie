namespace MVVMAppie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CouponChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coupons", "BrandProduct_BrandProductId", "dbo.BrandProducts");
            DropForeignKey("dbo.Coupons", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.Coupons", new[] { "BrandProduct_BrandProductId" });
            DropIndex("dbo.Coupons", new[] { "Product_ProductId" });
            CreateTable(
                "dbo.CouponBrandProducts",
                c => new
                    {
                        Coupon_CouponId = c.Int(nullable: false),
                        BrandProduct_BrandProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Coupon_CouponId, t.BrandProduct_BrandProductId })
                .ForeignKey("dbo.Coupons", t => t.Coupon_CouponId, cascadeDelete: true)
                .ForeignKey("dbo.BrandProducts", t => t.BrandProduct_BrandProductId, cascadeDelete: true)
                .Index(t => t.Coupon_CouponId)
                .Index(t => t.BrandProduct_BrandProductId);
            
            DropColumn("dbo.Coupons", "BrandProduct_BrandProductId");
            DropColumn("dbo.Coupons", "Product_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coupons", "Product_ProductId", c => c.Int());
            AddColumn("dbo.Coupons", "BrandProduct_BrandProductId", c => c.Int());
            DropForeignKey("dbo.CouponBrandProducts", "BrandProduct_BrandProductId", "dbo.BrandProducts");
            DropForeignKey("dbo.CouponBrandProducts", "Coupon_CouponId", "dbo.Coupons");
            DropIndex("dbo.CouponBrandProducts", new[] { "BrandProduct_BrandProductId" });
            DropIndex("dbo.CouponBrandProducts", new[] { "Coupon_CouponId" });
            DropTable("dbo.CouponBrandProducts");
            CreateIndex("dbo.Coupons", "Product_ProductId");
            CreateIndex("dbo.Coupons", "BrandProduct_BrandProductId");
            AddForeignKey("dbo.Coupons", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Coupons", "BrandProduct_BrandProductId", "dbo.BrandProducts", "BrandProductId");
        }
    }
}
