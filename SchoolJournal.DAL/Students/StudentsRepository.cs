namespace SchoolJournal.DAL.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using SchoolJournal.Domain;

    public class StudentsRepository : RepositoryBase, IStudentsRepository
    {
        public StudentsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IQueryable<StudentJournalGridModel> GetStudentsForJournalGrid()
        {

            var data = (from st in DbContext.Students
                        select new StudentJournalGridModel
                        {
                            Id = st.Id,
                            FirstName = st.FirstName,
                            LastName = st.LastName
                        });

            return data;
        }
    }
}
