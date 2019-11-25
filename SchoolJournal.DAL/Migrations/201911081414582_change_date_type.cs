namespace SchoolJournal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_date_type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Columns", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Columns", "Data");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Columns", "Data", c => c.String());
            DropColumn("dbo.Columns", "Date");
        }
    }
}
