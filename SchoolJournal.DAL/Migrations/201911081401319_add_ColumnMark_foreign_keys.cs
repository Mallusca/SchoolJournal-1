namespace SchoolJournal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ColumnMark_foreign_keys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.СolumnMark", new[] { "Column_Id" });
            DropIndex("dbo.СolumnMark", new[] { "Mark_Id" });
            RenameColumn(table: "dbo.СolumnMark", name: "Column_Id", newName: "ColumnId");
            RenameColumn(table: "dbo.СolumnMark", name: "Mark_Id", newName: "MarkId");
            AlterColumn("dbo.СolumnMark", "ColumnId", c => c.Long(nullable: false));
            AlterColumn("dbo.СolumnMark", "MarkId", c => c.Long(nullable: false));
            CreateIndex("dbo.СolumnMark", "MarkId");
            CreateIndex("dbo.СolumnMark", "ColumnId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.СolumnMark", new[] { "ColumnId" });
            DropIndex("dbo.СolumnMark", new[] { "MarkId" });
            AlterColumn("dbo.СolumnMark", "MarkId", c => c.Long());
            AlterColumn("dbo.СolumnMark", "ColumnId", c => c.Long());
            RenameColumn(table: "dbo.СolumnMark", name: "MarkId", newName: "Mark_Id");
            RenameColumn(table: "dbo.СolumnMark", name: "ColumnId", newName: "Column_Id");
            CreateIndex("dbo.СolumnMark", "Mark_Id");
            CreateIndex("dbo.СolumnMark", "Column_Id");
        }
    }
}
