
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
                        join m in DbContext.Marks on c.Id equals m.ColumnId into cmGroup
                        orderby c.Date
                        select new JournalGridColumnModel
                        {
                            Id = c.Id,
                            Date = c.Date,
                            Marks = cmGroup.Select(x => new StudentMarkModel
                            {
                                StudentId = x.StudentId,
                                Value = x.Value
                            }).ToList()
                        });

            return data;
        }

        public async Task<long> AddColumn(long columnTypeId, DateTime columnDate)
        {
            var dbColumn = DbContext.Columns.Add(new Column
            {
                Date = columnDate,
                ColumnTypeId = columnTypeId,
            });

            await DbContext.SaveChangesAsync();

            return dbColumn.Id;
        }

        public async Task<bool> DeleteAllColumns()
        {
            var dbColumns = DbContext.Columns.RemoveRange(DbContext.Columns);
            await DbContext.SaveChangesAsync();

            return DbContext.Columns.Count() == 0;
        }

    }
}
