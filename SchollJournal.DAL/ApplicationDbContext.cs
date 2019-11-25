namespace SchoolJournal.DAL
{
    using SchoolJournal.DAL.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() 
            : base("name=WebJournal")
        {
        }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<СolumnMark> JournalRecords { get; set; }

        public virtual DbSet<Column> Columns { get; set; }

        //TODOREAD
        protected override void OnModelCreating(DbModelBuilder modelBuilder) // read about override 
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);// read about base.methodName
        }
    }
}