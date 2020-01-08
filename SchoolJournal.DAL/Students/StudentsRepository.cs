namespace SchoolJournal.DAL.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using SchoolJournal.DAL.Models;
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
        public async Task<bool> AddStudent(string studentFirstName, string studentLastName)
        {

            var dbAddStudent = DbContext.Students.Add(new Student
            {
                FirstName = studentFirstName,
                LastName = studentLastName,
            });

            await DbContext.SaveChangesAsync();
            return DbContext.Students.Count() >= 3;
        }
    }
}
