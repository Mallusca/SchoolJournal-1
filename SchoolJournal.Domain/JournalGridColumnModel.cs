namespace SchoolJournal.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class JournalGridColumnModel
    {
        public long Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public DateTime Date { get; set; }

        public long StudentId { get; set; }

        public List<StudentMarkModel> Marks { get; set; }
    }
}
