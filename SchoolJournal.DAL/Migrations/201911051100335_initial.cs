namespace SchoolJournal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Columns",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ColumnTypeId = c.Long(nullable: false),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ColumnTypes", t => t.ColumnTypeId)
                .Index(t => t.ColumnTypeId);
            
            CreateTable(
                "dbo.СolumnMark",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Column_Id = c.Long(),
                        Mark_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Columns", t => t.Column_Id)
                .ForeignKey("dbo.Marks", t => t.Mark_Id)
                .Index(t => t.Column_Id)
                .Index(t => t.Mark_Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StudentId = c.Long(nullable: false),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ColumnTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TypeValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Columns", "ColumnTypeId", "dbo.ColumnTypes");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.СolumnMark", "Mark_Id", "dbo.Marks");
            DropForeignKey("dbo.СolumnMark", "Column_Id", "dbo.Columns");
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropIndex("dbo.СolumnMark", new[] { "Mark_Id" });
            DropIndex("dbo.СolumnMark", new[] { "Column_Id" });
            DropIndex("dbo.Columns", new[] { "ColumnTypeId" });
            DropTable("dbo.ColumnTypes");
            DropTable("dbo.Students");
            DropTable("dbo.Marks");
            DropTable("dbo.СolumnMark");
            DropTable("dbo.Columns");
        }
    }
}
