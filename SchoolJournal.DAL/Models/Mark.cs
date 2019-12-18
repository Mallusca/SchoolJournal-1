namespace SchoolJournal.DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Mark
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Student")]
        public long StudentId { get; set; }

        [ForeignKey("Column")]
        public long ColumnId { get; set; }

        public int Value { get; set; }

        public virtual Student Student { get; set; }

        public virtual Column Column { get; set; }
    }
}

