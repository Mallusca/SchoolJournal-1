using SchoolJournal.DAL.Interfaces;
using SchoolJournal.DAL.Models;
using SchoolJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal.DAL.JournalGrid
{
    public class ColumnMarksRepository : RepositoryBase, IColumnMarksRepository
    {
        public ColumnMarksRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public bool AddMarks(long columnId, IEnumerable<StudentMarkModel> marks)
        {

            var dbMarks = DbContext.Marks.AddRange(
                marks.Select(x =>
                new Mark
                {
                    Value = x.Value,
                    StudentId = x.StudentId,
                })
            );

            DbContext.ColumnMarks.AddRange(dbMarks.Select(
                x => new СolumnMark
                {
                    ColumnId = columnId,
                    MarkId = x.Id
                }
            ));

            throw new NotImplementedException();
        }
    }
}
