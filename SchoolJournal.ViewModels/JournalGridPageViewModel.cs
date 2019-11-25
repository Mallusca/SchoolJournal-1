
namespace SchoolJournal.ViewModels
{
    using System.Collections.Generic;

    public class JournalGridPageViewModel
    {
        public JournalGridPageViewModel(List<JournalGridStudentViewModel> studentsForJournalGrid,
                                        List<JournalGridColumnViewModel> journalGridColumns)
        {
            Students = studentsForJournalGrid;
            Columns = journalGridColumns;
        }

        public List<JournalGridStudentViewModel> Students { get; set; }

        public List<JournalGridColumnViewModel> Columns { get; set; }
    }
}
