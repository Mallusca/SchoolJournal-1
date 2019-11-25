namespace SchoolJournal.DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class СolumnMark
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public virtual Mark Mark { get; set; }

        public virtual Column Column { get; set; }

    }
}
