namespace SchoolJournal.DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Mark
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [ForeignKey("Student")]
        public long StudentId { get; set; }

        public int Value { get; set; }

        public string Date { get; set; }

        public Student Student { get; set; }

        public ICollection<СolumnMark> ColumnMarks { get; set; }
    }
}

