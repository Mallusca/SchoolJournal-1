namespace SchoolJournal.Domain
{
    public class StudentJournalGridModel
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName {
            get {
                return string.Format("{0} {1}", LastName, FirstName);
            }
        }
    }
}
