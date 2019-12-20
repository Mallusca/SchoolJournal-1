namespace SchoolJournal.DAL.Migrations
{
    using SchoolJournal.DAL.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(ApplicationDbContext context)
        //{
        //    var columnTypes = new List<ColumnType>
        //        {
        //            new ColumnType {TypeValue = "LESSON" },
        //            new ColumnType {  TypeValue = "EXAM"},
        //            new ColumnType { TypeValue = "HOMEWORK" },
        //        };
        //    columnTypes.ForEach(u => context.ColumnsTypes.AddOrUpdate(u));
        //    context.SaveChanges();
        //}
    }
}






//This method will be called after migrating to the latest version.

//  You can use the DbSet<T>.AddOrUpdate() helper extension method
//  to avoid creating duplicate seed data.