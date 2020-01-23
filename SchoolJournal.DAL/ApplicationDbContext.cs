namespace SchoolJournal.DAL
{
    using SchoolJournal.DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=WebJournal")
        {
            Database.SetInitializer(new MyContextInitializer());
        }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Column> Columns { get; set; }

        public virtual DbSet<ColumnType> ColumnsTypes { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        //TODOREAD

        protected override void OnModelCreating(DbModelBuilder modelBuilder) // read about override 
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);// read about base.methodName

        }

        class MyContextInitializer : IDatabaseInitializer<ApplicationDbContext>
        {
            public void InitializeDatabase(ApplicationDbContext context)
            {
                if (!context.Database.Exists())
                {
                    context.Database.Delete();
                    context.Database.Create();
                }

                var envVar = Environment.GetEnvironmentVariable(AppEnvironment.ENV_VARIABLE_NAME);

                if (envVar == AppEnvironment.DEVELOMPENT_ENV)
                {
                    SeedTestStudents(context);
                }
                SeedColumnTypes(context);
            }

            private void SeedTestStudents(ApplicationDbContext context)
            {
                if (context.Students.Count() >= 3)
                    return;

                var studentsList = new List<Student>();

                studentsList.Add(new Student() { FirstName = "Лёха", LastName = "Прогер" });
                studentsList.Add(new Student() { FirstName = "Владик", LastName = "Обучаюшийся" });
                studentsList.Add(new Student() { FirstName = "Сеня", LastName = "Сениор" });           

                context.Students.AddRange(studentsList);
                context.SaveChanges();
            }

            private void SeedColumnTypes(ApplicationDbContext context)
            {
                if (context.ColumnsTypes.Count() >= 3)
                    return;

                var columnTypes = new List<ColumnType>();

                columnTypes.Add(new ColumnType() { TypeValue = "LESSON" });
                columnTypes.Add(new ColumnType() { TypeValue = "EXAM" });
                columnTypes.Add(new ColumnType() { TypeValue = "HOMEWORK" });

                context.ColumnsTypes.AddRange(columnTypes);
                context.SaveChanges();

            }

        }
    }

}