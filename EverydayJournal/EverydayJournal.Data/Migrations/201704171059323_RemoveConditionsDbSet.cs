namespace EverydayJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveConditionsDbSet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PhysicalConditionId", "dbo.PhysicalConditions");
            DropIndex("dbo.People", new[] { "PhysicalConditionId" });
            AddColumn("dbo.People", "PhysicalCondition", c => c.String());
            DropColumn("dbo.People", "PhysicalConditionId");
            DropTable("dbo.PhysicalConditions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhysicalConditions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Kilograms = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "PhysicalConditionId", c => c.Int(nullable: false));
            DropColumn("dbo.People", "PhysicalCondition");
            CreateIndex("dbo.People", "PhysicalConditionId");
            AddForeignKey("dbo.People", "PhysicalConditionId", "dbo.PhysicalConditions", "Id", cascadeDelete: true);
        }
    }
}