namespace EverydayJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Afternoons", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Afternoons", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Afternoons", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Evenings", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Evenings", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.Evenings", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Mornings", "DateId", "dbo.Dates");
            DropForeignKey("dbo.Mornings", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Mornings", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Afternoons", new[] { "FoodId" });
            DropIndex("dbo.Afternoons", new[] { "TaskId" });
            DropIndex("dbo.Afternoons", new[] { "DateId" });
            DropIndex("dbo.Evenings", new[] { "TaskId" });
            DropIndex("dbo.Evenings", new[] { "DateId" });
            DropIndex("dbo.Evenings", new[] { "Food_Id" });
            DropIndex("dbo.Mornings", new[] { "FoodId" });
            DropIndex("dbo.Mornings", new[] { "TaskId" });
            DropIndex("dbo.Mornings", new[] { "DateId" });
            AddColumn("dbo.People", "Email", c => c.String(nullable: false));
            AddColumn("dbo.People", "Password", c => c.String(nullable: false));
            DropTable("dbo.Afternoons");
            DropTable("dbo.Evenings");
            DropTable("dbo.Mornings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Mornings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        DateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evenings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        DateId = c.Int(nullable: false),
                        Food_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Afternoons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        DateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.People", "Password");
            DropColumn("dbo.People", "Email");
            CreateIndex("dbo.Mornings", "DateId");
            CreateIndex("dbo.Mornings", "TaskId");
            CreateIndex("dbo.Mornings", "FoodId");
            CreateIndex("dbo.Evenings", "Food_Id");
            CreateIndex("dbo.Evenings", "DateId");
            CreateIndex("dbo.Evenings", "TaskId");
            CreateIndex("dbo.Afternoons", "DateId");
            CreateIndex("dbo.Afternoons", "TaskId");
            CreateIndex("dbo.Afternoons", "FoodId");
            AddForeignKey("dbo.Mornings", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mornings", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Mornings", "DateId", "dbo.Dates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Evenings", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Evenings", "Food_Id", "dbo.Foods", "Id");
            AddForeignKey("dbo.Evenings", "DateId", "dbo.Dates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Afternoons", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Afternoons", "FoodId", "dbo.Foods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Afternoons", "DateId", "dbo.Dates", "Id", cascadeDelete: true);
        }
    }
}
