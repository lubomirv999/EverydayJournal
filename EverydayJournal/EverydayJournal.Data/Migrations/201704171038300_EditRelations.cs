namespace EverydayJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PeopleFoods", "FoodId", "dbo.People");
            DropForeignKey("dbo.PeopleFoods", "PeopleId", "dbo.Foods");
            DropForeignKey("dbo.Dates", "PhysicalConditionId", "dbo.PhysicalConditions");
            DropIndex("dbo.Dates", new[] { "PhysicalConditionId" });
            DropIndex("dbo.PeopleFoods", new[] { "FoodId" });
            DropIndex("dbo.PeopleFoods", new[] { "PeopleId" });
            AddColumn("dbo.Foods", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Foods", "PersonId");
            AddForeignKey("dbo.Foods", "PersonId", "dbo.People", "Id");
            DropColumn("dbo.Dates", "PhysicalConditionId");
            DropTable("dbo.PeopleFoods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PeopleFoods",
                c => new
                    {
                        FoodId = c.Int(nullable: false),
                        PeopleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FoodId, t.PeopleId });
            
            AddColumn("dbo.Dates", "PhysicalConditionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Foods", "PersonId", "dbo.People");
            DropIndex("dbo.Foods", new[] { "PersonId" });
            DropColumn("dbo.Foods", "PersonId");
            CreateIndex("dbo.PeopleFoods", "PeopleId");
            CreateIndex("dbo.PeopleFoods", "FoodId");
            CreateIndex("dbo.Dates", "PhysicalConditionId");
            AddForeignKey("dbo.Dates", "PhysicalConditionId", "dbo.PhysicalConditions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleFoods", "PeopleId", "dbo.Foods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PeopleFoods", "FoodId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
