namespace SchoolJournal.DAL.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;
    using SchoolJournal.DAL.Models;

    public interface IStudentsRepository
    {
        IQueryable<StudentJournalGridModel> GetStudentsForJournalGrid();

        Task<bool> AddStudent(string studentFistName, string studentListName);

        Task<bool> DeleteChosenStudent(long studentId);

        Student StudentDetails(int id);
    }
}
