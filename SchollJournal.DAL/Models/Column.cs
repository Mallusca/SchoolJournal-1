namespace SchoolJournal.DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Column
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public ICollection<СolumnMark> ColumnMarks { get; set; }
    }
}