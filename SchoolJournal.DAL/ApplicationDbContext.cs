namespace SchoolJournal.DAL
{
    using SchoolJournal.DAL.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
            : base("name=WebJournal")
        {
        }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<СolumnMark> ColumnMarks { get; set; }

        public virtual DbSet<Column> Columns { get; set; }

        //TODOREAD
        protected override void OnModelCreating(DbModelBuilder modelBuilder) // read about override 
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);// read about base.methodName
        }
    }
}