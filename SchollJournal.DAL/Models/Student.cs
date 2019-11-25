namespace SchoolJournal.DAL.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Collection<Mark> Marks { get; set; }
    }
}
