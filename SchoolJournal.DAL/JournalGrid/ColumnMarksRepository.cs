using SchoolJournal.DAL.Interfaces;
using SchoolJournal.DAL.Models;
using SchoolJournal.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<bool> AddMarks(long columnId, IEnumerable<StudentMarkModel> marks)
        {

            var dbMarks = DbContext.Marks.AddRange(
                marks.Select(x =>
                new Mark
                {
                    Value = x.Value,
                    StudentId = x.StudentId,
                    ColumnId = columnId
                })
            );

            await DbContext.SaveChangesAsync();

            return dbMarks.Count() > 0;
        }

        public async Task<bool> DeleteAllMarks()
        {
            var dbMarks = DbContext.Marks.RemoveRange(DbContext.Marks);
            await DbContext.SaveChangesAsync();

            return DbContext.Marks.Count() == 0;
        }
    }
}
