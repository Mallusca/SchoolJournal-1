namespace SchoolJournal.DAL.JournalGrid
{
    using SchoolJournal.DAL.Interfaces;
    using SchoolJournal.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mapster;
    using System.Data.Entity;

    public class ColumnTypeRepository : RepositoryBase, IColumnTypeRepository
    {
        public ColumnTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<ColumnType> FindByName(string typeName)
        {
            var columnType = await DbContext.ColumnsTypes
                .Where(ct => ct.TypeValue.Equals(typeName))
                .FirstOrDefaultAsync();


            return columnType.Adapt<ColumnType>();
        
        }
    }
}         