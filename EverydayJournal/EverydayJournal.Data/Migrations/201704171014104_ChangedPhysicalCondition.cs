namespace EverydayJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPhysicalCondition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "DateId", "dbo.Dates");
            DropForeignKey("dbo.PhysicalConditions", "Id", "dbo.Dates");
            DropForeignKey("dbo.People", "PhysicalConditionId", "dbo.PhysicalConditions");
            DropIndex("dbo.People", new[] { "DateId" });
            DropIndex("dbo.PhysicalConditions", new[] { "Id" });
            DropPrimaryKey("dbo.PhysicalConditions");
            AddColumn("dbo.PhysicalConditions", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PhysicalConditions", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PhysicalConditions", "Kilograms", c => c.String());
            AddPrimaryKey("dbo.PhysicalConditions", "Id");
            CreateIndex("dbo.Dates", "PhysicalConditionId");
            AddForeignKey("dbo.Dates", "PhysicalConditionId", "dbo.PhysicalConditions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.People", "PhysicalConditionId", "dbo.PhysicalConditions", "Id", cascadeDelete: true);
            DropColumn("dbo.People", "DateId");
            DropColumn("dbo.PhysicalConditions", "ChestSize");
            DropColumn("dbo.PhysicalConditions", "WaistSize");
            DropColumn("dbo.PhysicalConditions", "ConditionByDateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhysicalConditions", "ConditionByDateId", c => c.Int(nullable: false));
            AddColumn("dbo.PhysicalConditions", "WaistSize", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PhysicalConditions", "ChestSize", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.People", "DateId", c => c.Int(nullable: false));
            DropForeignKey("dbo.People", "PhysicalConditionId", "dbo.PhysicalConditions");
            DropForeignKey("dbo.Dates", "PhysicalConditionId", "dbo.PhysicalConditions");
            DropIndex("dbo.Dates", new[] { "PhysicalConditionId" });
            DropPrimaryKey("dbo.PhysicalConditions");
            AlterColumn("dbo.PhysicalConditions", "Kilograms", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PhysicalConditions", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.PhysicalConditions", "Name");
            AddPrimaryKey("dbo.PhysicalConditions", "Id");
            CreateIndex("dbo.PhysicalConditions", "Id");
            CreateIndex("dbo.People", "DateId");
            AddForeignKey("dbo.People", "PhysicalConditionId", "dbo.PhysicalConditions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PhysicalConditions", "Id", "dbo.Dates", "Id");
            AddForeignKey("dbo.People", "DateId", "dbo.Dates", "Id", cascadeDelete: true);
        }
    }
}
