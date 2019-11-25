namespace SchoolJournal.DAL.Interfaces
{
    using System.Linq;
    using Domain;

    public interface IStudentsRepository
    {
        IQueryable<StudentJournalGridModel> GetStudentsForJournalGrid();
    }
}
