namespace SchoolJournal.DAL
{

    public abstract class RepositoryBase
    {
        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;
        }
        
        public ApplicationDbContext DbContext { get; set; }
    }
}
