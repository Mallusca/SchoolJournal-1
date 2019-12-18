namespace SchoolJournal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_ColumnMark : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.СolumnMark", "ColumnId", "dbo.Columns");
            DropForeignKey("dbo.СolumnMark", "MarkId", "dbo.Marks");
            DropIndex("dbo.СolumnMark", new[] { "MarkId" });
            DropIndex("dbo.СolumnMark", new[] { "ColumnId" });
            AddColumn("dbo.Marks", "ColumnId", c => c.Long(nullable: false));
            CreateIndex("dbo.Marks", "ColumnId");
            AddForeignKey("dbo.Marks", "ColumnId", "dbo.Columns", "Id");
            DropTable("dbo.СolumnMark");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.СolumnMark",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarkId = c.Long(nullable: false),
                        ColumnId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Marks", "ColumnId", "dbo.Columns");
            DropIndex("dbo.Marks", new[] { "ColumnId" });
            DropColumn("dbo.Marks", "ColumnId");
            CreateIndex("dbo.СolumnMark", "ColumnId");
            CreateIndex("dbo.СolumnMark", "MarkId");
            AddForeignKey("dbo.СolumnMark", "MarkId", "dbo.Marks", "Id");
            AddForeignKey("dbo.СolumnMark", "ColumnId", "dbo.Columns", "Id");
        }
    }
}
