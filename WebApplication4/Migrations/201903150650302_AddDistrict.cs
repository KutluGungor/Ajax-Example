namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDistrict : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Feedbacks", "CityId", "dbo.Cities");
            DropIndex("dbo.Cities", new[] { "CountryId" });
            DropIndex("dbo.Feedbacks", new[] { "CityId" });
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CityId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            AddColumn("dbo.Feedbacks", "DistrictId", c => c.Guid());
            AlterColumn("dbo.Cities", "CountryId", c => c.Guid());
            AlterColumn("dbo.Feedbacks", "CityId", c => c.Guid());
            CreateIndex("dbo.Cities", "CountryId");
            CreateIndex("dbo.Feedbacks", "CityId");
            CreateIndex("dbo.Feedbacks", "DistrictId");
            AddForeignKey("dbo.Feedbacks", "DistrictId", "dbo.Districts", "Id");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id");
            AddForeignKey("dbo.Feedbacks", "CityId", "dbo.Cities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Feedbacks", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.Feedbacks", new[] { "DistrictId" });
            DropIndex("dbo.Feedbacks", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "CountryId" });
            AlterColumn("dbo.Feedbacks", "CityId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cities", "CountryId", c => c.Guid(nullable: false));
            DropColumn("dbo.Feedbacks", "DistrictId");
            DropTable("dbo.Districts");
            CreateIndex("dbo.Feedbacks", "CityId");
            CreateIndex("dbo.Cities", "CountryId");
            AddForeignKey("dbo.Feedbacks", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
