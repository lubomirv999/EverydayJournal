namespace EverydayJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afternoons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        DateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.DateId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.TaskId)
                .Index(t => t.DateId);
            
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExactDate = c.DateTime(nullable: false),
                        PhysicalConditionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Date_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.Date_Id)
                .Index(t => t.Date_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateId = c.Int(nullable: false),
                        PhysicalConditionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.DateId, cascadeDelete: true)
                .ForeignKey("dbo.PhysicalConditions", t => t.PhysicalConditionId, cascadeDelete: true)
                .Index(t => t.DateId)
                .Index(t => t.PhysicalConditionId);
            
            CreateTable(
                "dbo.PhysicalConditions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ChestSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WaistSize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Kilograms = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ConditionByDateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Date_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.Date_Id)
                .ForeignKey("dbo.People", t => t.PersonId)
                .Index(t => t.PersonId)
                .Index(t => t.Date_Id);
            
            CreateTable(
                "dbo.Evenings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        DateId = c.Int(nullable: false),
                        Food_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.DateId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.DateId)
                .Index(t => t.Food_Id);
            
            CreateTable(
                "dbo.Mornings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        DateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.DateId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.TaskId)
                .Index(t => t.DateId);
            
            CreateTable(
                "dbo.PeopleFoods",
                c => new
                    {
                        FoodId = c.Int(nullable: false),
                        PeopleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FoodId, t.PeopleId })
                .ForeignKey("dbo.People", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.PeopleId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.PeopleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mornings", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Mornings", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Mornings", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Evenings", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Evenings", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Evenings", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Afternoons", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Afternoons", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Afternoons", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Tasks", "PersonId", "dbo.People");
            DropForeignKey("dbo.Tasks", "Date_Id", "dbo.Dates");
            DropForeignKey("dbo.People", "PhysicalConditionId", "dbo.PhysicalConditions");
            DropForeignKey("dbo.PhysicalConditions", "Id", "dbo.Dates");
            DropForeignKey("dbo.PeopleFoods", "PeopleId", "dbo.Foods");
            DropForeignKey("dbo.PeopleFoods", "FoodId", "dbo.People");
            DropForeignKey("dbo.People", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Foods", "Date_Id", "dbo.Dates");
            DropIndex("dbo.PeopleFoods", new[] { "PeopleId" });
            DropIndex("dbo.PeopleFoods", new[] { "FoodId" });
            DropIndex("dbo.Mornings", new[] { "DateId" });
            DropIndex("dbo.Mornings", new[] { "TaskId" });
            DropIndex("dbo.Mornings", new[] { "FoodId" });
            DropIndex("dbo.Evenings", new[] { "Food_Id" });
            DropIndex("dbo.Evenings", new[] { "DateId" });
            DropIndex("dbo.Evenings", new[] { "TaskId" });
            DropIndex("dbo.Tasks", new[] { "Date_Id" });
            DropIndex("dbo.Tasks", new[] { "PersonId" });
            DropIndex("dbo.PhysicalConditions", new[] { "Id" });
            DropIndex("dbo.People", new[] { "PhysicalConditionId" });
            DropIndex("dbo.People", new[] { "DateId" });
            DropIndex("dbo.Foods", new[] { "Date_Id" });
            DropIndex("dbo.Afternoons", new[] { "DateId" });
            DropIndex("dbo.Afternoons", new[] { "TaskId" });
            DropIndex("dbo.Afternoons", new[] { "FoodId" });
            DropTable("dbo.PeopleFoods");
            DropTable("dbo.Mornings");
            DropTable("dbo.Evenings");
            DropTable("dbo.Tasks");
            DropTable("dbo.PhysicalConditions");
            DropTable("dbo.People");
            DropTable("dbo.Foods");
            DropTable("dbo.Dates");
            DropTable("dbo.Afternoons");
        }
    }
}
