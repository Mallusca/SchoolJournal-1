
namespace SchoolJournal.BLL.Interfaces
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IJournalGridColumnsService
    {
        List<JournalGridColumnViewModel> GetJournalGridColumns();
    }
}
