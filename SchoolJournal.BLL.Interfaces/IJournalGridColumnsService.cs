
namespace SchoolJournal.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels;

    public interface IJournalGridColumnsService
    {
        List<JournalGridColumnViewModel> GetJournalGridColumns();

        Task<bool> AddJournalGridLessonColumn(IEnumerable<StudentMarkViewModel> marks, DateTime inputValue);

        Task<bool> DeleteJournalGridLessonColumnsAndMarks();
    }
}
