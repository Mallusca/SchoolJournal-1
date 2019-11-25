namespace SchoolJournal.DAL.Module
{
    using Unity;
    using Unity.Lifetime;
    using DAL.Students;
    using DAL.JournalGrid;
    using Interfaces;

    public static class DALModule
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<ApplicationDbContext>();

            container.RegisterType<IStudentsRepository, StudentsRepository>();

            container.RegisterType<IColumnMarksRepository, ColumnMarksRepository>();

            container.RegisterType<IColumnsRepository, ColumnsRepository>();

            container.RegisterType<IColumnTypeRepository, ColumnTypeRepository>();
        }
    }
}
