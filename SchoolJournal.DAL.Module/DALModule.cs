namespace SchoolJournal.DAL.Module
{
    using Unity;
    using Unity.Lifetime;
    using DAL.Students;
    using DAL.JournalGrid;
    using Interfaces;
    using Unity.Injection;

    public static class DALModule
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<ApplicationDbContext>();

            container.RegisterType<IStudentsRepository, StudentsRepository>();

<<<<<<< HEAD
            container.RegisterType<IColumnsRepository, ColumnsRepository>();

            container.RegisterType<IColumnMarksRepository, ColumnMarksRepository>();

            container.RegisterType<IColumnTypeRepository, ColumnTypeRepository>();

=======
            container.RegisterType<IColumnMarksRepository, ColumnMarksRepository>();

            container.RegisterType<IColumnsRepository, ColumnsRepository>();

            container.RegisterType<IColumnTypeRepository, ColumnTypeRepository>();
>>>>>>> 04518fc36e324843c29f48ee63898427baf89a7c
        }
    }
}
