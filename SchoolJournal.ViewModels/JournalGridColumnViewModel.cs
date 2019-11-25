
namespace SchoolJournal.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class JournalGridColumnViewModel
    {
        public DateTime Date { get; set; }

        public List<StudentMarkViewModel> Marks { get; set; }
    }
}
