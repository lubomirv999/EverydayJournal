namespace EverydayJournal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateIdToTaskAndFood : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Foods", name: "Date_Id", newName: "DateId");
            RenameColumn(table: "dbo.Tasks", name: "Date_Id", newName: "DateId");
            RenameIndex(table: "dbo.Foods", name: "IX_Date_Id", newName: "IX_DateId");
            RenameIndex(table: "dbo.Tasks", name: "IX_Date_Id", newName: "IX_DateId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tasks", name: "IX_DateId", newName: "IX_Date_Id");
            RenameIndex(table: "dbo.Foods", name: "IX_DateId", newName: "IX_Date_Id");
            RenameColumn(table: "dbo.Tasks", name: "DateId", newName: "Date_Id");
            RenameColumn(table: "dbo.Foods", name: "DateId", newName: "Date_Id");
        }
    }
}
