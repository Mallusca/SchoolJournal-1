namespace SchoolJournal.DAL.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Mapster;
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

        public async Task<bool> DeleteChosenStudent(long studentId)
        {

            DbContext.Marks.RemoveRange(DbContext.Marks.Where(stId => stId.StudentId == studentId));
            var dbStudent = DbContext.Students.Find(studentId);
            dbStudent = DbContext.Students.Remove(dbStudent);
            await DbContext.SaveChangesAsync();

            return DbContext.Students.Find(studentId) == null;
        }

        public Student StudentDetails (int id)
        {
          
            var studDetails = (from Student in DbContext.Students
                               where Student.Id == id
                               select Student).FirstOrDefault();

            return studDetails;
        }
    }
}

//studDetails.Marks = (from marks in DbContext.Marks
//                     where marks.StudentId == id
//                     select marks).ToList();

//List<int> marksChosenStud = new List<int>();
//var studMarks = (from marks in DbContext.Marks
//                 where marks.StudentId == id
//                 select marks);
//foreach (var marks in studMarks)
//{
//    marksChosenStud.Add(marks.Value);
//}

//            studStatistic.Adapt<Student>()

//var studStatistic = (from student in DbContext.Students
//                     join marks in DbContext.Marks on student.Id equals marks.StudentId into cmGroup
//                     select new Student
//                     {
//                         FirstName = studDetails.FirstName,
//                         LastName = studDetails.LastName,
//                         Marks = cmGroup.Select(x => new Mark
//                         {
//                             StudentId = x.StudentId,
//                             Value = x.Value
//                         }).ToList()
//                     });