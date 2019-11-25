
namespace SchoolJournal.DAL.JournalGrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using SchoolJournal.DAL.Models;
    using SchoolJournal.Domain;
    using SchoolJournal.ViewModels;

    public class ColumnsRepository : RepositoryBase, IColumnsRepository
    {
        public ColumnsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public IQueryable<JournalGridColumnModel> List()
        {
            var data = (from c in DbContext.Columns
                        join cm in DbContext.ColumnMarks on c.Id equals cm.ColumnId into cmGroup
                        orderby c.Date
                        select new JournalGridColumnModel
                        {
                            Id = c.Id,
                            Date = c.Date,
                            Marks = (from m in DbContext.Marks
                                     where cmGroup.Any(x => x.MarkId == m.Id)
                                     select new StudentMarkModel
                                     {
                                         StudentId = m.StudentId,
                                         Value = m.Value
                                     }).ToList()
                        });

            return data;
        }

        public long AddColumn(long columnTypeId, DateTime columnDate)
        {
            throw new NotImplementedException();
        }

    }
}
