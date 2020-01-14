namespace SchoolJournal.BLL.Interfaces
{
    using SchoolJournal.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels;

    public interface IStudentsService
    {
        List<JournalGridStudentViewModel> GetStudentsForJournalGrid();

        Task<bool> AddStudent(string studentFistName, string studentListName);

        Task<bool> DeleteChosenStudent(long studentId);
    }
}
