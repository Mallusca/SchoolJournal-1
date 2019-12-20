
namespace SchoolJournal.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels;

    public interface IJournalGridColumnsService
    {
        List<JournalGridColumnViewModel> GetJournalGridColumns();

<<<<<<< HEAD
        Task<bool> AddJournalGridLessonColumn(IEnumerable<StudentMarkViewModel> marks, DateTime inputValue);

        Task<bool> DeleteJournalGridLessonColumnsAndMarks();
=======
        bool AddJournalGridLessonColumn(IEnumerable<StudentMarkViewModel> marks);
>>>>>>> 04518fc36e324843c29f48ee63898427baf89a7c
    }
}
