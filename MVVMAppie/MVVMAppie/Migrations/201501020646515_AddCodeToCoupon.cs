namespace MVVMAppie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCodeToCoupon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "Code", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coupons", "Code");
        }
    }
}
