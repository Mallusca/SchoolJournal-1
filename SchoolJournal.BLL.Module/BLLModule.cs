namespace SchoolJournal.BLL.Module
{
    using Unity;
    using Interfaces;
    using BLL;

    public static class BLLModule
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<IStudentsService, StudentsService>();

            container.RegisterType<IJournalGridColumnsService, JournalGridColumnsService>();
        }
    }
}
