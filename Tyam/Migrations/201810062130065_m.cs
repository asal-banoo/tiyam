namespace Tyam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ServerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        FileName = c.String(nullable: false, maxLength: 255),
                        Alt = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Servers", t => t.ServerID, cascadeDelete: true)
                .Index(t => t.ServerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Text = c.String(nullable: false),
                        Evaluation = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Wight = c.Int(nullable: false),
                        Size = c.String(),
                        ApplicationUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_ID)
                .Index(t => t.Title, name: "IX_TitleFa")
                .Index(t => t.Date)
                .Index(t => t.Status)
                .Index(t => t.ApplicationUser_ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.String(),
                        PriceBoon = c.String(),
                        Status = c.Int(nullable: false),
                        BankGetNumber = c.String(maxLength: 50),
                        BankTransNumber = c.String(maxLength: 50),
                        PostBarCode = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ProductID)
                .Index(t => t.Status)
                .Index(t => t.BankGetNumber)
                .Index(t => t.BankTransNumber)
                .Index(t => t.PostBarCode);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        Family = c.String(maxLength: 100),
                        Country = c.String(maxLength: 100),
                        State = c.String(maxLength: 100),
                        City = c.String(maxLength: 100),
                        Address = c.String(maxLength: 300),
                        PostalCode = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Price = c.String(nullable: false, maxLength: 14),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.Date);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Path = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "ServerID", "dbo.Servers");
            DropForeignKey("dbo.Prices", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "UserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Products", "ApplicationUser_ID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Orders", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Images", "ProductID", "dbo.Products");
            DropIndex("dbo.Prices", new[] { "Date" });
            DropIndex("dbo.Prices", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "PostBarCode" });
            DropIndex("dbo.Orders", new[] { "BankTransNumber" });
            DropIndex("dbo.Orders", new[] { "BankGetNumber" });
            DropIndex("dbo.Orders", new[] { "Status" });
            DropIndex("dbo.Orders", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "UserID" });
            DropIndex("dbo.Products", new[] { "ApplicationUser_ID" });
            DropIndex("dbo.Products", new[] { "Status" });
            DropIndex("dbo.Products", new[] { "Date" });
            DropIndex("dbo.Products", "IX_TitleFa");
            DropIndex("dbo.Images", new[] { "ProductID" });
            DropIndex("dbo.Images", new[] { "ServerID" });
            DropTable("dbo.Servers");
            DropTable("dbo.Prices");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.Products");
            DropTable("dbo.Images");
        }
    }
}
