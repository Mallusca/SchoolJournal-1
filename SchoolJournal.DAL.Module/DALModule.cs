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

            container.RegisterType<IColumnsRepository, ColumnsRepository>();

            container.RegisterType<IColumnMarksRepository, ColumnMarksRepository>();

            container.RegisterType<IColumnTypeRepository, ColumnTypeRepository>();

        }
    }
}
