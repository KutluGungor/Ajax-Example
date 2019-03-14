namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCountry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cities", "CountryId", c => c.Guid(nullable: false));
            AddColumn("dbo.Feedbacks", "CountryId", c => c.Guid());
            CreateIndex("dbo.Cities", "CountryId");
            CreateIndex("dbo.Feedbacks", "CountryId");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "CountryId", "dbo.Countries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropIndex("dbo.Feedbacks", new[] { "CountryId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropColumn("dbo.Feedbacks", "CountryId");
            DropColumn("dbo.Cities", "CountryId");
            DropTable("dbo.Countries");
        }
    }
}
