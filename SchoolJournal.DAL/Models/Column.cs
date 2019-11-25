namespace SchoolJournal.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Column
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("ColumnType")]
        public long ColumnTypeId { get; set; }

        public DateTime Date { get; set; }

        public ColumnType ColumnType { get; set; }

        public ICollection<СolumnMark> ColumnMarks { get; set; }
    }
}