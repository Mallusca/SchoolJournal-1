namespace SchoolJournal.DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class СolumnMark
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Mark")]
        public long MarkId { get; set; }

        [ForeignKey("Column")]
        public long ColumnId { get; set; }

        public virtual Mark Mark { get; set; }

        public virtual Column Column { get; set; }

    }
} 
