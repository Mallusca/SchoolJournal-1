namespace SchoolJournal.BLL.Interfaces
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IStudentsService
    {
        List<JournalGridStudentViewModel> GetStudentsForJournalGrid();
    }
}
