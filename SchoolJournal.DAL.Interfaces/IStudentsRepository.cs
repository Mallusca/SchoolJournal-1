namespace SchoolJournal.DAL.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;

    public interface IStudentsRepository
    {
        IQueryable<StudentJournalGridModel> GetStudentsForJournalGrid();

        Task<bool> AddStudent(string studentFistName, string studentListName);
    }
}
